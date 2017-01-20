using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

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
			//string macAnimes = "/Users/PeijunsMac/Desktop/Animu";
			//List<string> notVaildPathFiles = FileSystem.getFiles("some nonsense");
			//List<string> files = FileSystem.getFiles(myMusic);

			//MessageBox.Show(testCodeRunTime(200).ToString());
			//method 1 avg on mac is 9.575 over 200 runs on macAnimes dir
			//method 2 avg on mac is 10.23 over 200 runs on macAnimes dir
			//method 3 avg on mac is 2.7 over 200 runs on macAnimes dir
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
				List<string> files = FileSystem.getFiles3("nonesense");
            }
            stopwatch.Stop();
            double total = stopwatch.ElapsedMilliseconds;
            return total / times;
        }
    }
}