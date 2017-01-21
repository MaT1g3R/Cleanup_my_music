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
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new mainWindow()); We dont need the window to show up, yet

            //Debug goes below this line------------------------------------------------------

            //MessageBox.Show("this is how you debug");
            //System.Diagnostics.Debug.Write("Or is this how you debug");
            //Actually tho please use the debugger

            //Console.WriteLine("Avg: " + testCodeRunTime(100));
            //string myWholeLibrary = "E://tixati";
            //List<string> test = FileSystem.getFiles(myWholeLibrary);

            //MessageBox.Show("Avg: " + testCodeRunTime(100));

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

            //tests done on Justin-PC in E://tixati, 100 runs each
            //method 1 avg is 135
            //method 2 avg is 136.46
            //method 3 avg is 254.74 on my library (uses 30MB of RAM compared to 19MB on others?)

            //Windows machine testing

            //MessageBox.Show(testCodeRunTime(100).ToString());
            //method 1 avg is 170.99, 170.43
            //method 2 avg is 178.99, 181.26
            //method 3 avg is 160.25, 158.98
            //Final method avg is 61.66, holy shit IEnumerable is op

            Manager myManager = new Manager(FileSystem.getFiles("A://Music"));
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