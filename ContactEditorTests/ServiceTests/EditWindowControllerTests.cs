using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactEditor.EventArgs;
using ContactEditor.Services;
using NUnit.Framework;

namespace ContactEditorTests.ServiceTests
{
    [TestFixture]
    class EditWindowControllerTests
    {
        EditWindowController editWindowController = new EditWindowController();

        //Not sure how to test this or if I should
        
        //[Test]
        //public void ShowDialogTestWithEditEventArgs()
        //{
        //    OpenEditWindowArgs openEditWindow = new OpenEditWindowArgs { Type = ActionType.Edit };
        //    bool? result = editWindowController.ShowDialog(openEditWindow);

        //    Assert.AreEqual(true, result);
        //}

        //[Test]
        //public void ShowDialogTestWithAddEventArgs()
        //{
        //    OpenEditWindowArgs openEditWindow = new OpenEditWindowArgs { Type = ActionType.Add };
        //    bool? result = editWindowController.ShowDialog(openEditWindow);

        //    Assert.AreEqual(null, result);
        //}
    }
}
