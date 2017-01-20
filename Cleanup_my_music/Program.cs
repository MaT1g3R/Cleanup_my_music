using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Cleanup_my_music {
    static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new mainWindow()); We dont need the window to show up, yet

			//Debug goes below this line------------------------------------------------------

			//MessageBox.Show("this is how you debug");
			//System.Diagnostics.Debug.Write("Or is this how you debug");
			//Actually tho please use the debugger

			//string testingDir = "C://Users//MaT1g3R//Desktop//Testing Directory";
			//string myWholeLibrary = "E://tixati";
			//string myMusic = "A://Music";
			//string macMusic = "SSD://Users//PeijunsMac";
			//List<string> notVaildPathFiles = FileSystem.getFiles("some nonsense");
			//List<string> files = FileSystem.getFiles(myMusic);
			MessageBox.Show(testCodeRunTime(100).ToString());
		}

        /// <summary>
        /// Tests the code run time.
        /// </summary>
        /// <param name="times">The number of times you want to run the code</param>
        /// <returns>
        /// returns the average runtime in ms
        /// </returns>
        static double testCodeRunTime(int times) {

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < times; i++) {
				List<string> files = FileSystem.getFiles("/Users/PeijunsMac");
				files.Clear();
            }
            stopwatch.Stop();
            double total = stopwatch.ElapsedMilliseconds;
            return total / times;
        }
    }
}