using ContactEditor.EventArgs;
using ContactEditor.Services;
using ContactEditor.ViewModel;
using Models;
using Moq;
using NUnit.Framework;

namespace ContactEditorTests
{
    [TestFixture]
    public class EditVMTests
    {
        private Mock<IDataProvider> dataProvider;
        private OpenEditWindowArgs openEditWindowArgs;
        private Mock<IDialogService> dialogService;

        [SetUp]
        public void setup()
        {
            dataProvider = new Mock<IDataProvider>();

            openEditWindowArgs = new OpenEditWindowArgs();

            dialogService = new Mock<IDialogService>();
        }

        //I made this file then realized all my functions are private
        //I was told not to write tests for private functions, but maybe I should?
    }
}
