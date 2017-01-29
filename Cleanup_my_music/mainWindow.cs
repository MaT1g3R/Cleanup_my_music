using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TagLib;


namespace Cleanup_my_music {

    public partial class mainWindow : Form {
        private string filePath;
        private Manager myManager;
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

            //initialize the manager 
            myManager = new Manager(songs);

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
            foreach (string path in myManager.MasterPathList) {


                //increment debug integer
                x++;

                //read data from manager @KingGuppie
                string[] artists = (string[])myManager.getSongAttributes(path, "Performers");
                string[] genres = (string[])myManager.getSongAttributes(path, "Genres");

                string artistsStr = string.Join(",", artists);
                string genresStr = string.Join(",", genres);
                string title = "null";
                string album = "null";

                title = myManager.getSongAttributes(path, "Title")?.ToString();
                album = myManager.getSongAttributes(path, "Album")?.ToString();

                //creates a new list item containing each of the columns we have
                ListViewItem item = new ListViewItem(new[] {
                        title,
                        album,
                        artistsStr,
                        genresStr,
                        x.ToString()
                    });

                //tags it with the path so it is not lost 
                item.Tag = path;

                //adds it to the current selected list box
                cur.Items.Add(item);



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
