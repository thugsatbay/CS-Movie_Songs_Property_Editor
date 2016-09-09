using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Movie_Songs_Property_Editor
{
    public partial class Form1 : Form
    {
        String key;
        songs_editor se;
        public Form1()
        {
            InitializeComponent();
            key = "treeViewSubDirectory";
            se = new songs_editor();
            se.Name = "songsEditor";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void songsEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contentPanel.Controls.Contains(se) == false)
            {
               try
               {
                    if (treeViewSubDirectory.SelectedNode.FullPath.ToString() != null)
                    {
                        contentPanel.Controls.RemoveByKey(key);
                        key = "songsEditor";
                        se.setPath(treeViewSubDirectory.SelectedNode.FullPath.ToString());
                        contentPanel.Controls.Add(se);
                        
                    }
               }
                catch(NullReferenceException nre)
               {
                    MessageBox.Show("Please Select A SubFolder To Search For Songs List", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
            
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr=folderBrowserDialogLoad.ShowDialog();
            if (dr == DialogResult.OK)
            {
                String path = folderBrowserDialogLoad.SelectedPath;
                MessageBox.Show(path, "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                string[] subFolders = Directory.GetDirectories(path);
                
                TreeNode [] subTrees=new TreeNode[subFolders.Length];
                int x=0;
                foreach(String s in subFolders)
                {
                    subTrees[x++] = new TreeNode(s.Substring(path.Length+1));
                }
                TreeNode temp = new TreeNode(path,subTrees);
                treeViewSubDirectory.Nodes.Add(temp);
                
            }
            else
            {
                MessageBox.Show("Path Not Selected", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void subDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contentPanel.Controls.Contains(treeViewSubDirectory) == false)
            {
                MessageBox.Show(key);
                contentPanel.Controls.RemoveByKey(key);
                key = "treeViewSubDirectory";
                contentPanel.Controls.Add(treeViewSubDirectory);
            }
            //MessageBox.Show(treeViewSubDirectory.SelectedNode.FullPath.ToString());
        }


    }
}
