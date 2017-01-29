using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TagLib;


namespace Cleanup_my_music {

    public partial class mainWindow : Form {
        private string filePath;
        FolderBrowserDialog dialog = new FolderBrowserDialog();

        public mainWindow() {
            InitializeComponent();
        }

        private void mainWindow_Load(object sender, EventArgs e) {


        }

        private void loadFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            //opens a folder browser dialog and saves the selected path
            dialog.ShowDialog();
            filePath = dialog.SelectedPath;

            //passes path into getFiles method and saves as a list
            IEnumerable<string> songs = FileSystem.getFiles(filePath);



            //initialize variables for file
            File file;

            //placeholder counter to see how many songs imported
            int x = 0;

            //initialize variable to hold the selected tab
            ListView cur = null;

            //looks which tab the user has selected and assigns that list to our current variable
            if (tabControl1.SelectedTab == tabPage1) {
                cur = listView1;
            } else {
                cur = listView2;
            }

            //loop through every song file that was grabbed from the directory
            foreach (string song in songs) {
                try {//try statement because lmao

                    //initialize a tag variable
                    Tag tag = null;
                    if (song.Contains("flac")) {
                        //flac has different metadata than other things
                        file = File.Create(song);
                        tag = file.GetTag(TagTypes.FlacMetadata);
                    } else if (song.Contains("mp3")) {
                        //i guess this is what mp3 uses
                        file = File.Create(song);
                        tag = file.GetTag(TagTypes.Id3v2, true);
                    }//should put stuff here for other file extensions that might exist

                    //error checking stuff for artists
                    String artist = null;
                    if (tag.AlbumArtists.Length <= 0) {
                        //artist is deprecated but some of my music still has it instead of album artist
                        //this makes it not crash if thats true
                        if (tag.Artists.Length > 0) {
                            artist = tag.Artists[0];
                        } else {
                            artist = "";
                        }
                        //this could probably also just overwrite albumartist with artist but meh
                    } else {
                        artist = tag.AlbumArtists[0];
                    }

                    //increment debug integer
                    x++;

                    //creates a new list item containing each of the columns we have
                    ListViewItem item = new ListViewItem(new[] { tag.Title, tag.Album, artist, tag.Genres[0], x.ToString() });

                    //tags it with the path so it is not lost 
                    item.Tag = song;

                    //adds it to the current selected list box
                    cur.Items.Add(item);


                } catch (Exception) { }//lol

            }

        }

        private void genreToolStripMenuItem_Click(object sender, EventArgs e) {
            //List<string> selected = listBox1.SelectedItems.Cast<string>().ToList();
            string newTag = null;
            //pass manager selected and newTag

            //TODO: Figure out how input boxes work or design another form thats my own homemade one
            MessageBox.Show("The selected files have had their genre changed to " + newTag);
        }

        private void artistToolStripMenuItem_Click(object sender, EventArgs e) {

        }


        private void listView1_ItemActivate(object sender, EventArgs e) {
            //if you double click on an item in the first list box it shows its directory
            //just debugging code, this will probably play it eventually
            //also it doesnt do anything for list box 2
            MessageBox.Show(listView1.SelectedItems[0].Tag.ToString());
        }
    }
}
