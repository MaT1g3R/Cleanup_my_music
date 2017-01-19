﻿using System;
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
            string testingDir = "C://Users//MaT1g3R//Desktop//Testing Directory";
            string myWholeLibrary = "A://Music";
            List<string> files = FileSystem.getFiles(myWholeLibrary);
            Application.Run(new mainWindow());
            //System.Diagnostics.Debug.Write("Or is this how you debug");
            //Actually tho please use the debugger
        }
    }
}