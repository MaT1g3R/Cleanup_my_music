using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Cleanup_my_music {
    /// <summary>
    /// The FileSystem class will get all paths of media files under a root folder.
    /// </summary>
    class FileSystem {
        /// <summary>
        /// The folder path
        /// </summary>
        private string folderPath;

        ///Initialize the FileSystem object from a valid folder path
        ///<param> name="folderPath" a valid folder path on the computer </param>
        ///<returns> A object containing all media files under the path </returns>
        public FileSystem(String folderPath) {
            this.folderPath = folderPath;
        }
    }
}
