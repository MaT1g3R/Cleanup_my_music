using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;


namespace Cleanup_my_music {
    /// <summary>
    /// The FileSystem class will get all paths of media files under a root folder.
    /// </summary>
    public static class FileSystem {
        /// <summary>
        /// The arrary of allowed format
        /// </summary>
        private static string[] allowedFormat = { "*.mp3", "*.flac", "*.m4a", "*.wav" };

        /// <summary>
        /// Gets file with allowd format under the root folder.
        /// </summary>
        /// <param name="root">(hopefully) A vaild folder path</param>
        /// <returns>A IEnumerable of all paths of files with allowed format under the root folder</returns>
        public static IEnumerable<string> getFiles(string root) {
            try {
                IEnumerable<string> directories = Directory.EnumerateDirectories(root);
                IEnumerable<string> files = allowedFormat.SelectMany(filter => System.IO.Directory.EnumerateFiles(root, filter));
                if (directories == null || !directories.Any()) {
                    return files;
                } else {
                    foreach (string d in directories) {
                        files = files.Concat(getFiles(d));
                    }
                    return files;
                }
            } catch (System.IO.DirectoryNotFoundException) {
                MessageBox.Show("Please enter a valid Directory");
                return null;
            }
        }
    }
}

