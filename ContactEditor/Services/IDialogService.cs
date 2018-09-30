using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactEditor.Services
{
    public interface IDialogService
    {
        void Warning(string message);

        void Exception(Exception ex);
    }
}
