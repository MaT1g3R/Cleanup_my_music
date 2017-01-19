using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Cleanup_my_music {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //MessageBox.Show("this is how you debug");
            // string testingDir = "C://Users//MaT1g3R//Desktop//Testing Directory";
            string myWholeLibrary = "E://tixati";

            //Still needs further testing
            List<string> files = FileSystem.getFiles(myWholeLibrary); //168ms, 168ms, avg 172.6
            List<string> files0 = FileSystem.getFiles0(myWholeLibrary); //166ms, 165ms, avg 240
            List<string> files1 = FileSystem.getFiles1(myWholeLibrary); //242ms, avg 240.3

            Application.Run(new mainWindow());
            //System.Diagnostics.Debug.Write("Or is this how you debug");
            //Actually tho please use the debugger
        }
    }
}