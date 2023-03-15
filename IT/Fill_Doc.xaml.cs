using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using System.Windows;
using System.IO;

namespace IT
{
    public partial class Fill_Doc : System.Windows.Window
    {
        private Microsoft.Office.Interop.Word.Application app;

        public Fill_Doc()
        {
            InitializeComponent();
            app = new Microsoft.Office.Interop.Word.Application();
        }


        private void FillBookmarksButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the path of the original file
            string originalFilePath = @"C:\Users\\source\repos\IT\IT\resource\Шаблон документа заявления_1.doc";

            // Create a copy of the file
            string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetFileName(originalFilePath));
            File.Copy(originalFilePath, tempFilePath, true);

            // Open the copied file
            var doc = app.Documents.Open(tempFilePath);

            // Update bookmark values
            doc.Bookmarks["От_кого_заявление"].Range.Text = FromWhomTextBox.Text;
            doc.Bookmarks["Что_прошу"].Range.Text = CtoProshyTextBox.Text;
            doc.Bookmarks["В_связи_каких_остоятельствах"].Range.Text = ObstoetelstvaTextBox.Text;
            doc.Bookmarks["День"].Range.Text = DayTextBox.Text;
            doc.Bookmarks["Месяц"].Range.Text = YearTextBox.Text;
            doc.Bookmarks["Расшифровка_подписи"].Range.Text = DecryptionTextBox.Text;
            doc.Bookmarks["На_что_заявление"].Range.Text = OneTextBox.Text;

            // Show the save file dialog to choose the save location and format
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Word Document (*.docx)|*.docx|Word 97-2003 Document (*.doc)|*.doc";
            if (saveFileDialog.ShowDialog() == true)
            {
                // Save the document in the chosen format
                var fileFormat = saveFileDialog.FileName.EndsWith(".doc") ?
                    Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument :
                    Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatXMLDocument;
                doc.SaveAs2(saveFileDialog.FileName, fileFormat);

                // Close the document
                doc.Close();
            }
            else
            {
                // Close the document without saving
                doc.Close(false);
            }

            // Delete the temporary file
            File.Delete(tempFilePath);

            // Quit the application and release the object
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;
        }

        private void CompanyTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            var form = new Shablon_blank();
            form.Show();
            this.Close();
        }
    }
}
