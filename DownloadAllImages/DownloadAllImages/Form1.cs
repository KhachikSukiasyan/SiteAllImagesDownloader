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
using System.Net.Http;

namespace DownloadAllImages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
           string html = await downloadHtml(textBox.Text);
           writeToFile(html, textBox.Text);
        }

        private void writeToFile(string content,string urlString)
        {

            string desctopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = desctopPath + @"\Downloaded images";
            string fileName = urlString;

            int i = fileName.Length - 1;
            while (fileName[i] != '/')
                i--;
            fileName = fileName.Substring(i + 1);

            string newFolderPath = folderPath + @"\" + fileName;
            string newFilePath = newFolderPath + @"\" + fileName + ".html";


            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            if (!Directory.Exists(newFolderPath))
                Directory.CreateDirectory(newFolderPath);

            
            FileStream file = new FileStream(newFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteAsync(content).Wait();
            writer.Close();
        }

        private Task<string> downloadHtml(string urlString)
        {
            return Task.Run(() =>
            {
                using (var client = new HttpClient())
                {
                    Task<string> task = client.GetStringAsync(urlString);
                    return task.Result;
                }
            });
        }
    }
}
