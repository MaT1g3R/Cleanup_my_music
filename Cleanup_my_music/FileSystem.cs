using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Cleanup_my_music {
    /// <summary>
    /// The FileSystem class will get all paths of media files under a root folder.
    /// </summary>
    public static class FileSystem {
        /// <summary>
        /// The allowed format, can easily expand this later
        /// </summary>
        private static string allowedExtentions = "*.mp3,*.flac,*.m4a,*.wav";
        /// <summary>
        /// The allowed format in a list, used for another implemtation
        /// </summary>
        private static List<string> allowedExList = new List<string> { "*.mp3", "*.flac", "*.m4a", "*.wav" };

        /// <summary>
        /// Get the files from param "root", with correct filters applied.
        /// </summary>
        /// <param name="root">Valid path to a root folder.</param>
        /// <returns>
        /// A list containing all media file paths under the root folder
        /// </returns>
        public static List<string> getFiles(string root) {
            string[] directories = Directory.GetDirectories(root);
            //this will get all the files with the allowed extention
            List<string> files = allowedExtentions.Split(',').SelectMany(filter => Directory.GetFiles(root, filter)).ToList();

            if (directories.Length <= 0) {
                return files;
            } else {
                foreach (string d in directories) {
                    files.AddRange(getFiles(d));
                }
                return files;
            }
        }

        /// <summary>
        /// Another get files implementation
        /// </summary>
        /// <param name="root">Valid path to a root folder.</param>
        /// <returns>A list containing all media file paths under the root folder</returns>
        public static List<string> getFiles0(string root) {
            string[] directories = Directory.GetDirectories(root);

            //another implemtation
            List<string> files0 = new List<string> { };
            foreach (string ex in allowedExList) {
                files0.AddRange(Directory.GetFiles(root, ex));
            }

            if (directories.Length <= 0) {
                return files0;
            } else {
                foreach (string d in directories) {
                    files0.AddRange(getFiles(d));
                }
                return files0;
            }
        }
    }
}

