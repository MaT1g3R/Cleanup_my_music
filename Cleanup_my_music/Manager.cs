using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*This class should deal with meta data management things. 
For example getting and setting genres. The exact implementation should be handled by [KingGuppie]. 
Ideally [MaT1g3R] wants this to report the numbers and the list of songs missing metadata, and some sort of mass set options.*/
namespace Cleanup_my_music{

    class Manager{
        //int for number missing of tag type [whatever]
        //array list of song paths
        private int test;
        public int MyProperty { get; set; }
        /// <summary>
        /// <param name="some array list"> a playlist </param>
        /// </summary>
        public Manager(/*playlist string array*/) {
            //array list = playlist
        }

        /// <summary>
        /// <param name="[x]"> a tag to search for files which are missing this </param>
        /// </summary>
        public void findMissingX(/*[x]*/) {
            /* for (int i = 0;i<=arraylist.length;i++){
                    if(arraylist[i].tag == null
                        missingX++;
               }
            */
        }
    }
}
