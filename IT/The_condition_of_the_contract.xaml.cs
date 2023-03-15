using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace IT
{
    /// <summary>
    /// Логика взаимодействия для The_condition_of_the_contract.xaml
    /// </summary>
    public partial class The_condition_of_the_contract : Window
    {
        public The_condition_of_the_contract()
        {
            InitializeComponent();
        }

        private void shablon_save1(object sender, RoutedEventArgs e)
        {
            // Set the path to the document file
            string filePath = @"C:\Users\Олег\source\repos\IT\IT\resource\Изменение условий трудового договора и прекращение трудового договора\Заявление об изменении продолжительности рабочего времени (ставки).doc";

            // Create a SaveFileDialog instance
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Изменение условий трудового договора и прекращение трудового договора Заявление об изменении продолжительности рабочего времени (ставки)"; // Set the default file name
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
            string filePath = @"C:\Users\Олег\source\repos\IT\IT\resource\Изменение условий трудового договора и прекращение трудового договора\Образец заполнения заявления об изменении продолжительности рабочего времени (ставки).pdf";

            // Create a SaveFileDialog instance
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Изменение условий трудового договора и прекращение трудового договора_Образец заполнения заявления об изменении продолжительности рабочего времени (ставки)"; // Set the default file name
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
            string filePath = @"C:\Users\Олег\source\repos\IT\IT\resource\Изменение условий трудового договора и прекращение трудового договора\Заявление об увольнении.doc";

            // Create a SaveFileDialog instance
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Заявление об увольнении"; // Set the default file name
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
            string filePath = @"C:\Users\Олег\source\repos\IT\IT\resource\Изменение условий трудового договора и прекращение трудового договора\Образец заполнения заявления об увольнении.pdf";

            // Create a SaveFileDialog instance
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Образец заполнения заявления об увольнении"; // Set the default file name
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
            string filePath = @"C:\Users\Олег\source\repos\IT\IT\resource\Изменение условий трудового договора и прекращение трудового договора\Образец заполнения заявления об увольнении.pdf";

            // Create a SaveFileDialog instance
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Образец заполнения заявления об увольнении"; // Set the default file name
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
