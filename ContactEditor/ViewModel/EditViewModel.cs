using ContactEditor.EventArgs;
using ContactEditor.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Models;
using System;

namespace ContactEditor.ViewModel
{
    public class EditViewModel : ViewModelBase
    {
        public Contact CurrentContact { get; set; }
        public IDataProvider DataProvider { get; }
        public IDialogService DialogService { get; set; }
        public RelayCommand SaveDataCommand { get; set; }
        protected OpenEditWindowArgs Args { get; }

        public EditViewModel(OpenEditWindowArgs args, IDataProvider dataProvider, IDialogService dialogService)
        {
            Args = args;
            DataProvider = dataProvider;
            DialogService = dialogService;

            switch (args.Type)
            {
                case ActionType.Add:
                    CurrentContact = new Contact { Id = Guid.NewGuid().ToString() };
                    break;
                case ActionType.Edit:
                    //Clone a new object
                    CurrentContact = new Contact
                    {
                        Id = args.Contact.Id,
                        FirstName = args.Contact.FirstName,
                        LastName = args.Contact.LastName,
                        Company = args.Contact.Company,
                        Email = args.Contact.Email,
                        Birthday = args.Contact.Birthday,
                        JobTitle = args.Contact.JobTitle,
                        Notes = args.Contact.Notes,
                        MobilePhone = args.Contact.MobilePhone,
                        Address = args.Contact.Address
                    };
                    break;
            }

            SaveDataCommand = new RelayCommand(SaveData);
        }

        private void SaveData()
        {
            if (string.IsNullOrWhiteSpace(CurrentContact.FirstName))
            {
                DialogService.Warning("First Name is required");
                return;
            }

            bool result = false;
            switch (Args.Type)
            {
                case ActionType.Add:
                    result = DataProvider.Insert(CurrentContact);
                    break;
                case ActionType.Edit:
                    result = DataProvider.Update(CurrentContact);
                    break;
            }

            if (!result)
            {
                DialogService.Warning($"Error occured, save data failed");
            }
            else
            {
                Messenger.Default.Send(new CloseWindowEventArgs());
            }
        }
    }
}
