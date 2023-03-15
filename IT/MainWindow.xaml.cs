using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows;
using System.IO;
using System.Diagnostics;
using System;
using System.IO.Compression;



namespace IT
{

    public partial class MainWindow : Window
    {
        private readonly string localPath = @"E:\IT\IT";
        private readonly string gitHubPath = "https://github.com/moviefullframe/IT_1.git";


        public MainWindow()
        {
            InitializeComponent();
        }



        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            var Form1 = new Administrator_control();
            Form1.Show();
        }

        private void Update(object sender, RoutedEventArgs e)
        {

            var gitProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    Arguments = $"clone {gitHubPath} {localPath}",
                    UseShellExecute = true,
                    Verb = "runas"
                }
            };

            gitProcess.Start();
            gitProcess.WaitForExit();

            if (gitProcess.ExitCode == 0)
            {
                
            }
            else
            {
                MessageBox.Show("Update failed");
            }
        }


    }


    }
