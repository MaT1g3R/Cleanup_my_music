using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace Cleanup_my_music {

    ///<summary>
    ///This class should deal with meta data management things. 
    ///For example getting and setting genres. The exact implementation should be handled by [KingGuppie]. 
    ///Ideally [MaT1g3R] wants this to report the numbers and the list of songs missing metadata, and some sort of mass set options.
    ///</summary>
    class Manager {

        /// <summary>
        /// The list of File instance for all songs
        /// </summary>
        private IEnumerable<File> songs = new File[] { };

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class with a given list of file paths.
        /// </summary>
        /// <param name="pathList">The path list.</param>
        /// <returns> An instance of the Manager class </returns>
        public Manager(IEnumerable<string> pathList) {
            foreach (string path in pathList) {
                try {
                    File pending = File.Create(path);
                    if (pending.Properties.MediaTypes == MediaTypes.Audio) {
                        this.songs = this.songs.Concat(new File[] { pending });//This will create a file object with each song path
                    }
                } catch { }
            }
        }

    }
}