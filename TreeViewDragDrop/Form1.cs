using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TreeViewDragDrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.sourceTree.ExpandAll();
        }

        private void sourceTree_MouseDown(object sender, MouseEventArgs e)
        {
            TreeView tree = (TreeView)sender;
            TreeNode node = tree.GetNodeAt(e.X, e.Y);
            tree.SelectedNode = node;
            if (node != null)
            {
                tree.DoDragDrop(node, DragDropEffects.Copy);
            }
        }

        private void destinationTree_DragOver(object sender, DragEventArgs e)
        {
            TreeView tree = (TreeView)sender;
            e.Effect = DragDropEffects.Copy;
        }

        private void destinationTree_DragDrop(object sender, DragEventArgs e)
        {
            if (this.sourceTree.SelectedNodes != null && this.sourceTree.SelectedNodes.Count > 0)
            {
                foreach (TreeNode node in this.sourceTree.SelectedNodes)
                {
                    this.destinationTree.AddNodeToTree(node);
                }
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderPath.Text = folderDialog.SelectedPath;
                this.sourceTree.Nodes.Clear();
                this.sourceTree.SelectedNodes.Clear();
                this.destinationTree.Nodes.Clear();
                this.sourceTree.CreateTree(folderDialog.SelectedPath);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> filepaths = this.destinationTree.GetAllFilesWithPath();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.destinationTree.Nodes.Clear();
        }
    }
}
