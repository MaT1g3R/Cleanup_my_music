using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TagLib;
using System.Reflection;

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

            // Manager myManager = new Manager(FileSystem.getFiles("A://Music"));
            IEnumerable<string> files = FileSystem.getFiles("A://Music");
            IEnumerable<string> files2 = FileSystem.getFiles("C://Users//MaT1g3R//Desktop//New folder");

            //@KingGuppie if you are looking at this, just be scared, it's fine. I spent like 3 hours to figure this shit out
            TagLib.File mySong = TagLib.File.Create(files2.ElementAt(0));
            var songType = mySong.GetType();
            var Tag = songType.GetProperty("Tag");
            var allTags = Tag.GetValue(mySong);
            Tag allTagsCast = (Tag)allTags;
            var tagType = allTagsCast.GetType();
            var tags = tagType.GetProperties();
            List<string> tagNames = new List<string> { };
            foreach (PropertyInfo info in tags) {
                if (info.GetSetMethod() != null && info.GetGetMethod() != null) {
                    tagNames.Add(info.Name);
                }
            }
            Dictionary<string, object> myDict = new Dictionary<string, object> { };
            foreach (string tagname in tagNames) {
                var tag = tagType.GetProperty(tagname);
                var mySongTag = tag.GetGetMethod().Invoke(allTagsCast, null);
                myDict.Add(tagname, mySongTag);
            }
            Dictionary<string, object> myDict2 = myDict;
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

