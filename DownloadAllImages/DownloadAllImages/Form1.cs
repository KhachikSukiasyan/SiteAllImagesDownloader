using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DownloadAllImages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            downloadHtmlToFile(textBox.Text);
        }




        private void downloadHtmlToFile(string urlString)
        {

            string desctopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = desctopPath + @"\Downloaded images";

            string newFolderPath = folderPath + @"\" + textBox.Text;
            string newFilePath = newFolderPath + @"\" + textBox.Text + ".html";


            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            if (!Directory.Exists(newFolderPath))
                Directory.CreateDirectory(folderPath);

            FileStream file = new FileStream(newFilePath, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteAsync("aaaaaaaaaaaaa");
            writer.Close();
        }
    }
}
