using ContactEditor.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactEditor.Services
{
    public interface IEditWindowController
    {
        /// <summary>
        /// Show the edit window
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        bool? ShowDialog(OpenEditWindowArgs args);
    }
}
