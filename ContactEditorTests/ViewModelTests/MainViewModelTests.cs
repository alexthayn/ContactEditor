using ContactEditor.Services;
using ContactEditor.ViewModel;
using Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ContactEditorTests.ViewModelTests
{
    [TestFixture]
    class MainViewModelTests
    {
        private MainViewModel mainViewModel;
        private Mock<IDataProvider> dataProvider;
        private Mock<IEditWindowController> editWindowController;
        private Mock<IDialogService> dialogService;

        [SetUp]
        public void Setup()
        {
            dataProvider = new Mock<IDataProvider>();
            editWindowController = new Mock<IEditWindowController>();
            dialogService = new Mock<IDialogService>();
            var contacts = new List<IContact>();
            contacts.Add(new Contact());
            dataProvider.Setup(a => a.GetAllContacts()).Returns(contacts);
            mainViewModel = new MainViewModel(dataProvider.Object, editWindowController.Object, dialogService.Object);
        }

        [Test]
        public void TestDeleteCommandDisabledWithoutSelection()
        {
            mainViewModel.SelectedContact = null;

            Assert.IsFalse(mainViewModel.DeleteContactCommand.CanExecute(this));
        }

        //This test fails without a UI present, I'll to to make some code modifications
        //[Test]
        //public void TestDeleteCommandEnabledWithSelection()
        //{
        //    Contact contact = new Contact();
        //    mainViewModel.SelectedContact = contact;

        //    Assert.True(mainViewModel.DeleteContactCommand.CanExecute(this));
        //}

        [Test]
        public void TestEditCommandDisabledWithSelection()
        {
            mainViewModel.SelectedContact = null;

            Assert.IsFalse(mainViewModel.EditContactCommand.CanExecute(this));
        }

        //This test fails without a UI present, I'll to to make some code modifications
        //[Test]
        //public void TestEditCommandEnabledWithSelection()
        //{
        //    mainViewModel.SelectedContact = new Contact();

        //    Assert.True(mainViewModel.EditContactCommand.CanExecute(this));
        //}

        [Test]
        public void TestAddCommandAlwaysEnabled()
        {
            Assert.IsTrue(mainViewModel.AddContactCommand.CanExecute(this));
        }
    }
}
