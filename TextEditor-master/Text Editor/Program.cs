using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false); //here because of error report

            //main program object file
            //used by other classes if needed
            TextEditor mainProgramObj = new TextEditor();

            Application.EnableVisualStyles();
            Application.Run(mainProgramObj);
        }
    }
}
