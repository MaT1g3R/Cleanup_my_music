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
        ///int for number missing of tag type [whatever]
        ///array list of song paths
        private int test;
        public int MyProperty { get; set; }
        ///takes in an array list
        public Manager(/*playlist string array*/) {
            //array list = playlist
        }

        //this is an example search for number of missing [x] tags
        public void findMissingX(/*[x]*/) {
            /* for (int i = 0;i<=arraylist.length;i++){
                    if(arraylist[i].tag == null
                        missingX++;
               }
            */
        }
    }
}
