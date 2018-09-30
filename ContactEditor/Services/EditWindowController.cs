using ContactEditor.EventArgs;
using ContactEditor.Views;
using GalaSoft.MvvmLight.Ioc;

namespace ContactEditor.Services
{
    public class EditWindowController : IEditWindowController
    {
        public bool? ShowDialog(OpenEditWindowArgs args)
        {
            // If the container contains the target type, then remove it or else an exception will be thrown here
            if (SimpleIoc.Default.ContainsCreated<OpenEditWindowArgs>())
                SimpleIoc.Default.Unregister<OpenEditWindowArgs>();

            SimpleIoc.Default.Register(() => args);

            EditWindow editWindow = new EditWindow();
            return editWindow.ShowDialog();
        }
    }
}
