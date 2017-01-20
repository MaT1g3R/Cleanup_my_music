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
        private static string[] allowedFormat = { ".mp3", ".flac", ".m4a", ".wav" };

        /// <summary>
        /// Get all files with the allowed format under the root folder
        /// </summary>
        /// <param name="root">(hopefully) valid path to a root folder.</param>
        /// <returns>A list containing all media file paths under the root folder</returns>
        public static List<string> getFiles(string root) {
            try {
                string[] directories = Directory.GetDirectories(root);
                string[] files = Directory.GetFiles(root);

                var validFiles = new List<string> { };

                foreach (string f in files) {
                    if (isAllowedFormat(f)) {
                        validFiles.Add(f);
                    }
                }

                if (directories.Length <= 0) {
                    return validFiles;
                } else {
                    foreach (string d in directories) {
                        validFiles.AddRange(getFiles(d));
                    }
                    return validFiles;
                }

            } catch (System.IO.DirectoryNotFoundException) {
                MessageBox.Show("Please enter a valid Directory");
                return null;
            }
        }

		public static IEnumerable<string> getFiles2(string root) {
			try
			{
				IEnumerable<string> directories = Directory.EnumerateDirectories(root);
				IEnumerable<string> files = Directory.EnumerateFiles(root);

				IEnumerable<string> validFiles = new string[] { };

				foreach (string f in files)
				{
					if (isAllowedFormat(f))
					{
						validFiles.Concat(new[] {f});
					}
				}

				if (directories == null || !directories.Any()){
					return validFiles;
				}
				else {
					foreach (string d in directories)
					{
						validFiles.Concat(getFiles2(d));
					}
					return validFiles;
				}

			}
			catch (System.IO.DirectoryNotFoundException)
			{
				MessageBox.Show("Please enter a valid Directory");
				return null;
			}
		}

		public static IEnumerable<string> getFiles3(string root)
		{
			try
			{
				IEnumerable<string> directories = Directory.EnumerateDirectories(root);
				IEnumerable<string> files="*.mp3|*.flac|*.m4a|*.wav".Split('|').SelectMany(filter => System.IO.Directory.EnumerateFiles(root, filter));
				if(directories == null || !directories.Any()){
					return files;
				}
				else {
					foreach (string d in directories)
					{
						files.Concat(getFiles3(d));
					}
					return files;
				}
			}
			catch (System.IO.DirectoryNotFoundException)
			{
				MessageBox.Show("Please enter a valid Directory");
				return null;
			}
		}




        /// <summary>
        /// Determines whether a file has allowed format.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>
        ///   <c>true</c> if the file has allowed format; otherwise, <c>false</c>.
        /// </returns>
        private static bool isAllowedFormat(string file) {
            foreach (string ex in allowedFormat) {
                if (file.EndsWith(ex)) {
                    return true;
                }
            }
            return false;
        }
    }
}

