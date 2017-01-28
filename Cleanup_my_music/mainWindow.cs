using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;


namespace Cleanup_my_music {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
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



            //adds all files in directory to list box
            File file;
            ListViewItem albumList = new ListViewItem("Album");
            ListViewItem artistList = new ListViewItem("Artist");
            ListViewItem titleList = new ListViewItem("Title");
            int x = 0;

            foreach (string song in songs) {
                try {


                    file = File.Create(song);
                    Tag tag = file.GetTag(TagTypes.Id3v2);

                    x++;
                    ListViewItem item = new ListViewItem(new[] { tag.Title, tag.Album, tag.AlbumArtists[0], tag.Genres[0], x.ToString() });
                    listView1.Items.Add(item);


                } catch (Exception) { }

            }

        }

        private void genreToolStripMenuItem_Click(object sender, EventArgs e) {
            //List<string> selected = listBox1.SelectedItems.Cast<string>().ToList();
            string newTag = null;
            //pass manager selected and newTag
            MessageBox.Show("The selected files have had their genre changed to " + newTag);
        }

        private void artistToolStripMenuItem_Click(object sender, EventArgs e) {

        }
    }
}
