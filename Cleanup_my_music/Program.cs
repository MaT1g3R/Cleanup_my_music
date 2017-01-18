using System;
using System.Windows.Forms;

namespace Cleanup_my_music
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        static void Test() {
            //TEST COMMIT
            TagLib.File newfile = TagLib.File.Create("filename");
            newfile.Tag.Genres = new String[] { "some genre" };
            //this is a comment thats very useful
            //dont include
            // so this shit work now?
            //does this shit work?
            //dank ass memes ( ͡° ͜ʖ ͡°)

        }
    }
}