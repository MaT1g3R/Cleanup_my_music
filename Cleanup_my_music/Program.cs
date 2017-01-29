using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace Cleanup_my_music {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new mainWindow()); //We dont need the window to show up, yet

            //Debug goes below this line------------------------------------------------------

            //Manager myManager = new Manager(FileSystem.getFiles("A://Music"));
            IEnumerable<string> files = FileSystem.getFiles("A://Music");
            //IEnumerable<string> files2 = FileSystem.getFiles("C://Users//MaT1g3R//Desktop//Testing Directory");
            //IEnumerable<string> files3 = FileSystem.getFiles("E://tixati");
            Manager myManager = new Manager(files);
            int i = 1;

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
                IEnumerable<string> files = FileSystem.getFiles("A://Music");
            }
            stopwatch.Stop();
            double total = stopwatch.ElapsedMilliseconds;
            return total / times;
        }
    }
}

