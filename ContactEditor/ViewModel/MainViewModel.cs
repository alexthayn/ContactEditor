using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using Models;
using GalaSoft.MvvmLight.Command;
using ContactEditor.Services;
using System.Linq;
using ContactEditor.EventArgs;

namespace ContactEditor.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Contact> _allContacts;
        private Contact _selectedContact;

        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                Set(ref _selectedContact, value);

                //If selected contact property changed, check if Edit and Delete commands can execute
                DeleteContactCommand.RaiseCanExecuteChanged();
                EditContactCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataProvider dataProvider, IEditWindowController editWindowController, IDialogService dialogService)
        {
            DataProvider = dataProvider;
            EditWindowController = editWindowController;
            DialogService = dialogService;

            AddContactCommand = new RelayCommand(AddContact);
            EditContactCommand = new RelayCommand<Contact>(EditContact, contact => SelectedContact != null);
            DeleteContactCommand = new RelayCommand<Contact>(DeleteContact, contact => SelectedContact != null);

            AllContacts = new ObservableCollection<Contact>(dataProvider.GetAllContacts().OfType<Contact>());
        }
        
        public RelayCommand AddContactCommand { get; set; }
        public RelayCommand<Contact> EditContactCommand { get; set; }
        public RelayCommand<Contact> DeleteContactCommand { get; set; }

        public IEditWindowController EditWindowController { get; }
        public IDialogService DialogService { get; }
        public IDataProvider DataProvider { get; }

        public ObservableCollection<Contact> AllContacts
        {
            get { return _allContacts; }
            set { Set(ref _allContacts, value); }
        }


        private void AddContact()
        {
            var result = EditWindowController.ShowDialog(new OpenEditWindowArgs { Type = ActionType.Add });
            if (result.HasValue && result.Value)
                AllContacts = new ObservableCollection<Contact>(DataProvider.GetAllContacts().OfType<Contact>());
        }

        private void DeleteContact(Contact contact)
        {
            AllContacts.Remove(contact);
            DataProvider.Delete(contact);
        }

        private void EditContact(Contact contact)
        {
            var result = EditWindowController.ShowDialog(new OpenEditWindowArgs { Type = ActionType.Edit, Contact = SelectedContact });
            if(result.HasValue && result.Value)
            {
                //remember the users selection
                int index = AllContacts.IndexOf(SelectedContact);
                AllContacts = new ObservableCollection<Contact>(DataProvider.GetAllContacts().OfType<Contact>());

                //re-selected the original item
                SelectedContact = AllContacts[index];
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}