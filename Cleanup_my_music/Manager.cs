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

        private List<Song> songs = null;
        public List<Song> missingGenre { get; set; }
        public List<Song> missingArtist { get; set; }
        public List<Song> missingAlbum { get; set; }
        public List<Song> missingTitle { get; set; }


        ///takes in an array list
        public Manager(List<Song> playlist) {
            songs = playlist;

        }

        //this is an example search for number of missing tags, does this even need to return the value or just save it
        public void findMissing() {
            foreach (Song song in songs) {
                if (song.genre == "") {
                    missingGenre.Add(song);
                }
                if (song.artist == "") {
                    missingArtist.Add(song);
                }
                if (song.album == "") {
                    missingAlbum.Add(song);
                }
                if (song.title == "") {
                    missingTitle.Add(song);
                }
            }
            //is this literally all this class is supposed to do

        }

        public void massSet(List<Song> files, Tag tag, String content) {//hopefully this will actually be able to take a tag, or ill need to make a method for each type of tag
            //which is more code
            foreach (Song song in files) {
                song.Tag = content;
            }
        }
    }
}
