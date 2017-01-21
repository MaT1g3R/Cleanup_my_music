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

        private IEnumerable<File> songs = new File[] { };

        public Manager(IEnumerable<string> songList) {
            foreach (string song in songList) {
                this.songs = this.songs.Concat(new File[] { File.Create(song) });//This will create a file object with each song path
            }
        }
    }
}