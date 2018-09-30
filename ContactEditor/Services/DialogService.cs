using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactEditor.Services
{
    public class DialogService : IDialogService
    {
        public void Exception(Exception ex)
        {
            string message = $@"An exception throw: {ex.Message} {ex.ToString()}";
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
        public void Warning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
