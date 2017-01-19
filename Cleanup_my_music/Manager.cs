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

        List<string> files = FileSystem.getFiles("E://tixati");

        ///takes in an array list
        public Manager(/*playlist string array*/) {
            //array list = playlist
        }

        //this is an example search for number of missing [x] tags
        public void findMissingX(/*[x]*/) {
            foreach (string f in files) {
                //i honestly have no idea what im doing, but this should check if the f its looking has that tag
            }
        }
    }
}
