using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows;
using System.IO;
using System.Diagnostics;
using System;
using System.IO.Compression;
using Newtonsoft.Json;

namespace IT
{
    
    public partial class MainWindow : Window
    {

        private const string gitHubUrl = "https://github.com/moviefullframe/IT_1.git";
        private const string authToken = "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";
        private const string localPath = "E:\\IT\\IT";

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
            try
            {
                string latestCommit = GetLastestCommit();
                string currentCommit = GetCurrentCommit();
                if (latestCommit != currentCommit)
                {
                    DownloadFiles();
                    RestartApplication();
                }
                else
                {
                    MessageBox.Show("Обновлений нет"); 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обнолвений");
            }
        }
        private string GetLastestCommit()
        {
            string apiUrl = $"https://api.github.com/repos/moviefullframe/IT_1/git/refs/heads/main?access_token={authToken}";
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("User-Agent", "request");
                client.Headers.Add("Authorization", $"token {authToken}");
                responseString = client.DownloadString(apiUrl);
            }
            dynamic responseJson = Newtonsoft.Json.JsonConvert.DeserializeObject(responseString);
            string latestCommit = responseJson?.@object?.sha;
            return latestCommit;
           
        }


        private string GetCurrentCommit()
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "git";
                process.StartInfo.Arguments = $"rev-parse HEAD";
                process.StartInfo.WorkingDirectory = localPath;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd().Trim();
                process.WaitForExit();

                return output;
            }
        }


        private void DownloadFiles()
        {
            string downloadUrl = $"https://github.com/moviefullframe/IT_1/archive/refs/heads/main.zip";
            string tempPath = Path.Combine(Path.GetTempPath(), "IT_1.zip");

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("User-Agent", "request");
                client.Headers.Add("Authorization", $"token {authToken}");
                client.DownloadFile(downloadUrl, tempPath);
            }

            string extractPath = Path.Combine(Path.GetTempPath(), "IT_1");
            if (Directory.Exists(extractPath))
            {
                Directory.Delete(extractPath, true);
            }

            ZipFile.ExtractToDirectory(tempPath, extractPath);
            string sourcePath = Path.Combine(extractPath, "IT_1-main");
            CopyFiles(sourcePath, localPath);
        }

        private void CopyFiles(string sourcePath, string targetPath)
        {
            foreach (string file in Directory.GetFiles(sourcePath))
            {
                string fileName = Path.GetFileName(file);
                string targetFile = Path.Combine(targetPath, fileName);
                File.Copy(file, targetFile, true);
            }

            foreach (string directory in Directory.GetDirectories(sourcePath))
            {
                string directoryName = Path.GetFileName(directory);
                string targetDirectory = Path.Combine(targetPath, directoryName);
                CopyFiles(directory, targetDirectory);
            }
        }

        private void RestartApplication()
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}

