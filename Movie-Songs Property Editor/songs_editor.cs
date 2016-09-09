using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System.IO;

namespace Movie_Songs_Property_Editor
{
    public partial class songs_editor : UserControl
    {
        String _path;
        ShellObject mp3File;
        DataTable dt;
        public songs_editor()
        {
            InitializeComponent();
            dt = ds.Tables["songsEditor"];
            

            //fileLoader();

            //ShellObject picture = ShellObject.FromParsingName(@"D:\Music\Barfi\[DDR] Barfi - 01 - Main Kya Karoon.mp3");
            //Console.WriteLine(picture.Properties.GetProperty(SystemProperties.System.Title).ValueAsObject + "\n NEWLINE \n");


            //ShellPropertyWriter writer = picture.Properties.GetPropertyWriter();
            //writer.WriteProperty(SystemProperties.System.Title, "Main Kya Karoon");
            //writer.Close();
            //Console.WriteLine("\n NEWLINE \n" + picture.Properties.GetProperty(SystemProperties.System.Title).ValueAsObject);
        }

        private void fileLoader()
        {
            string[] songFiles = Directory.GetFiles(_path);
            //dt = new DataTable("songsTable");
            //dt.Columns.Add("Title");
            //dt.Columns.Add("Album");
            //dt.Columns.Add("AlbumArtist");
            //dt.Columns.Add("Year");
            //dt.Columns.Add("Genre");
            //dt.Columns.Add("Name");
            //ds.Tables.Add(dt);
            //BindingSource bs = new BindingSource();
            //bs.DataSource = ds;
            //bs.DataMember = "songsTable";

            //ShellObject picture = ShellObject.FromParsingName(@"D:\Music\Barfi\[DDR] Barfi - 01 - Main Kya Karoon.mp3");
            //Console.WriteLine(picture.Properties.GetProperty(SystemProperties.System.Title).ValueAsObject + "\n NEWLINE \n");

            
            //ShellPropertyWriter writer = picture.Properties.GetPropertyWriter();
            //writer.WriteProperty(SystemProperties.System.Title, "Main Kya Karoon");
            //writer.Close();
            //Console.WriteLine("\n NEWLINE \n" + picture.Properties.GetProperty(SystemProperties.System.Title).ValueAsObject);
           
                for (int i = 0; i < songFiles.Length; ++i)
                {
                     try
            {

                    mp3File = ShellObject.FromParsingName(@songFiles[i]);
                    label7.Text = songFiles[i];
                    dt.Rows.Add(mp3File.Properties.GetProperty(SystemProperties.System.Title).ValueAsObject, mp3File.Properties.GetProperty(SystemProperties.System.Music.AlbumTitle).ValueAsObject, mp3File.Properties.GetProperty(SystemProperties.System.Music.AlbumArtist).ValueAsObject, mp3File.Properties.GetProperty(SystemProperties.System.Media.Year).ValueAsObject, ((String[])mp3File.Properties.GetProperty(SystemProperties.System.Music.Genre).ValueAsObject)[0], mp3File.Properties.GetProperty(SystemProperties.System.FileName).ValueAsObject);
                    if(dt.Rows[i][0]!=null)
                    textBoxTitle.Text = dt.Rows[i][0].ToString();
                    if (dt.Rows[i][1] != null)
                    textBoxAlbum.Text = dt.Rows[i][1].ToString();
                    if (dt.Rows[i][2] != null)
                    textBoxAlbumArtist.Text = dt.Rows[i][2].ToString();
                    if (dt.Rows[i][3] != null)
                    textBoxYear.Text = dt.Rows[i][3].ToString();
                    if (dt.Rows[i][4] != null)
                    textBoxGenre.Text = dt.Rows[i][4].ToString();
                    if (dt.Rows[i][5] != null)
                    textBoxFileName.Text = dt.Rows[i][5].ToString();
            }
                     catch (Exception e)
                     {
                         MessageBox.Show(e.Message+" i="+i+songFiles[i]);
                     }

                }
            
        }

        public void setPath(String path)
        {
            _path = path;
            fileLoader();
        }

    }
}
