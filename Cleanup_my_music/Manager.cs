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

		private Dictionary<string, object> songDict = new Dictionary<string, object> { };
		
        public Manager(IEnumerable<string> pathList) {
            foreach (string path in pathList) {
				try
				{
					File pending = File.Create(path);
					if (pending.Properties.MediaTypes == MediaTypes.Audio)
					{
						//Add it to the dict somehow
						//The dict struceture should be like:
						// {"Genre": {"Rock": [ ] , "Pop" : [ ]} , "Artist" : {"dude1" : [ ], "dude2": [ ] } ..........}
						// So how the fuck do i add these

						//Get the property types first
						Type FileType = pending.GetType();


						//Then read the actual property


						//Then add the file object to the approiate sub dicts? And it needs to be added multiple times




					}
				}
				catch (TagLib.UnsupportedFormatException) { }
            }
        }

    }
}