using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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

           

            //adds all files in directory to list box
            foreach (string song in songs) {
                listBox1.Items.Add(song);
            }
        }

        private void genreToolStripMenuItem_Click(object sender, EventArgs e) {
            List<string> selected = listBox1.SelectedItems.Cast<string>().ToList();
            string newTag = null;
            //pass manager selected and newTag
            MessageBox.Show("The selected files have had their genre changed to " + newTag);
        }

        private void artistToolStripMenuItem_Click(object sender, EventArgs e) {

        }
    }
}
