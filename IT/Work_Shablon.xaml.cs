using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace IT
{
    /// <summary>
    /// Логика взаимодействия для Work_Shablon.xaml
    /// </summary>
    public partial class Work_Shablon : Window
    {
        public Work_Shablon()
        {
            InitializeComponent();
        }

        
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void shablon_save1(object sender, RoutedEventArgs e)
        {
            // Set the path to the document file
            string filePath = @"C:\Users\Oleg\source\repos\IT\IT\resource\Оформление на работу\Документы для приёма на работу.doc";

            // Create a SaveFileDialog instance
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Документы для приёма на работу"; // Set the default file name
            saveFileDialog.Filter = "Word Document (*.doc)|*.doc"; // Set the file filter

            // Show the SaveFileDialog and get the result
            bool? result = saveFileDialog.ShowDialog();

            // If the user clicked the "Save" button, save the file
            if (result == true)
            {
                // Get the selected file path from the SaveFileDialog
                string selectedFilePath = saveFileDialog.FileName;

                // Copy the document file to the selected file path
                File.Copy(filePath, selectedFilePath);

                // Show a message box to confirm that the file was saved
                MessageBox.Show("Фаил сохранён");
            }
        }

        

        private void shablon_save2(object sender, RoutedEventArgs e)
        {
            // Set the path to the document file
            string filePath = @"C:\Users\Олег\source\repos\IT\IT\resource\Оформление на работу\Госуслуга по выдаче справок о наличии (отсутствии) судимости.docx";

            // Create a SaveFileDialog instance
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Госуслуга по выдаче справок о наличии (отсутствии) судимости"; // Set the default file name
            saveFileDialog.Filter = "Word Document (*.doc)|*.doc"; // Set the file filter

            // Show the SaveFileDialog and get the result
            bool? result = saveFileDialog.ShowDialog();

            // If the user clicked the "Save" button, save the file
            if (result == true)
            {
                // Get the selected file path from the SaveFileDialog
                string selectedFilePath = saveFileDialog.FileName;

                // Copy the document file to the selected file path
                File.Copy(filePath, selectedFilePath);

                // Show a message box to confirm that the file was saved
                MessageBox.Show("Фаил сохранён");
            }
        }

        private void shablon_save3(object sender, RoutedEventArgs e)
        {
            // Set the path to the document file
            string filePath = @"C:\Users\Олег\source\repos\IT\IT\resource\Оформление на работу\Обязательство о неразглашении информации.docx";

            // Create a SaveFileDialog instance
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Обязательство о неразглашении информации"; // Set the default file name
            saveFileDialog.Filter = "Word Document (*.doc)|*.doc"; // Set the file filter

            // Show the SaveFileDialog and get the result
            bool? result = saveFileDialog.ShowDialog();

            // If the user clicked the "Save" button, save the file
            if (result == true)
            {
                // Get the selected file path from the SaveFileDialog
                string selectedFilePath = saveFileDialog.FileName;

                // Copy the document file to the selected file path
                File.Copy(filePath, selectedFilePath);

                // Show a message box to confirm that the file was saved
                MessageBox.Show("Фаил сохранён");
            }
        }

        private void shablon_save4(object sender, RoutedEventArgs e)
        {
            // Set the path to the document file
            string filePath = @"C:\Users\Олег\source\repos\IT\IT\resource\Оформление на работу\Образец заполнения обязательства о неразглашении информации.PDF";

            // Create a SaveFileDialog instance
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Образец заполнения обязательства о неразглашении информации.PDF"; // Set the default file name
            saveFileDialog.Filter = "Word Document (*.doc)|*.doc"; // Set the file filter

            // Show the SaveFileDialog and get the result
            bool? result = saveFileDialog.ShowDialog();

            // If the user clicked the "Save" button, save the file
            if (result == true)
            {
                // Get the selected file path from the SaveFileDialog
                string selectedFilePath = saveFileDialog.FileName;

                // Copy the document file to the selected file path
                File.Copy(filePath, selectedFilePath);

                // Show a message box to confirm that the file was saved
                MessageBox.Show("Фаил сохранён");
            }
        }

        private void shablon_save5(object sender, RoutedEventArgs e)
        {
            // Set the path to the document file
            string filePath = @"C:\Users\Олег\source\repos\IT\IT\resource\Оформление на работу\Заявление о приеме на работу.doc";

            // Create a SaveFileDialog instance
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Заявление о приеме на работу"; // Set the default file name
            saveFileDialog.Filter = "Word Document (*.doc)|*.doc"; // Set the file filter

            // Show the SaveFileDialog and get the result
            bool? result = saveFileDialog.ShowDialog();

            // If the user clicked the "Save" button, save the file
            if (result == true)
            {
                // Get the selected file path from the SaveFileDialog
                string selectedFilePath = saveFileDialog.FileName;

                // Copy the document file to the selected file path
                File.Copy(filePath, selectedFilePath);

                // Show a message box to confirm that the file was saved
                MessageBox.Show("Фаил сохранён");
            }
        }

        private void back_shablon_click(object sender, RoutedEventArgs e)
        {
            var Form = new Shablon_blank();
           
            Form.Show();
            this.Close();
        }
    }
}
