using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;


namespace Cleanup_my_music {
    /// <summary>
    /// The FileSystem class will get all paths of files under a root folder.
    /// </summary>
    public static class FileSystem {
        /// <summary>
        /// Get all file paths under the root folder
        /// </summary>
        /// <param name="root">(hopefully) A valid folder path</param>
        /// <returns>An IEnumerable of all paths of files </returns>
        public static IEnumerable<string> getFiles(string root) {
            try {
                IEnumerable<string> directories = Directory.EnumerateDirectories(root);
                IEnumerable<string> files = Directory.EnumerateFiles(root);
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

