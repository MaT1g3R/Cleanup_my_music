using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleanup_my_music {

    ///<summary>
    ///This class should deal with meta data management things. 
    ///For example getting and setting genres. The exact implementation should be handled by [KingGuppie]. 
    ///Ideally [MaT1g3R] wants this to report the numbers and the list of songs missing metadata, and some sort of mass set options.
    ///</summary>
    class Manager {

        List<string> files = null;
        List<string> missingGenre = null;


        ///takes in an array list
        public Manager(List<string> playlist) {
            files = playlist;

        }

        //this is an example search for number of missing [x] tags
        public int findMissingGenre() {
            foreach (string f in files) {
                if (true) {//lmao
                    missingGenre.Add(f);
                }
            }

            return missingGenre.Count;
        }
    }
}
