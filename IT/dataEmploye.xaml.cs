using System.Data.SqlClient;
using System.Windows;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using System.Windows.Controls;
using System.Configuration;
using System.Runtime.InteropServices;
using System;
using System.Data;
using System.Drawing;

namespace IT
{
    public partial class dataEmploye : System.Windows.Window
    {

        string connectionString = ConfigurationManager.ConnectionStrings["ITEntities"].ConnectionString;

       
        public dataEmploye()
        {
            InitializeComponent();
            LoadData();
            
        }

        private void LoadData()
        {
            string query = "SELECT " +
                           "id AS 'Идентификатор', " +
                           "first_name AS 'Имя', " +
                           "last_name AS 'Фамилия', " +
                           "patronymic AS 'Отчество', " +
                           "position AS 'Должность', " +
                           "phone_number AS 'Номер телефона', " +
                           "age AS 'Возраст', " +
                           "direction_of_development AS 'Отдел' " +
                           "FROM employees";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);

                    dataEmployeGrid.ItemsSource = dataTable.DefaultView;

                    // set column headers in Russian
                    string[] columnHeaders = { "Идентификатор", "Имя", "Фамилия", "Отчество", "Должность", "Номер телефона", "Возраст", "Отдел" };
                    for (int i = 0; i < columnHeaders.Length; i++)
                    {
                        if (i < dataEmployeGrid.Columns.Count)
                        {
                            dataEmployeGrid.Columns[i].Header = columnHeaders[i];
                        }
                    }
                }
            }
        }



        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteInformation deleteInformation = new DeleteInformation();
            deleteInformation.ShowDialog();

            if (deleteInformation.DialogResult.HasValue && deleteInformation.DialogResult.Value)
            {
                int id = int.Parse(deleteInformation.txtID.Text);

              
                string query = "DELETE FROM employees WHERE id = @id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Запись успешно удалена");
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при удалении записи, запись не найдена");
                        }
                    }
                }

                LoadData();

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var form = new EditInformation();
            form.Show();
            this.Close();
        }



        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM employees WHERE first_name LIKE '%' + @searchValue + '%' OR last_name LIKE '%' + @searchValue + '%' OR patronymic LIKE '%' + @searchValue + '%' OR position LIKE '%' + @searchValue + '%' OR phone_number LIKE '%' + @searchValue + '%' OR age LIKE '%' + @searchValue + '%' OR direction_of_development LIKE '%' + @searchValue + '%'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchValue", searchValue.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);

                    dataEmployeGrid.ItemsSource = dataTable.DefaultView;
                }
            }
        }




        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = new AddInformation();
            form.Show();
            this.Close();
        }


        private void btnComposeReport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Excel Documents (.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.FileName = "Report";

            if (saveFileDialog.ShowDialog() == true)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["ITEntities"].ConnectionString;

                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                var workbook = excelApp.Workbooks.Add(Type.Missing);
                var worksheet = (Worksheet)workbook.ActiveSheet;

                worksheet.Range["A1:H1"].Value = new object[] { "ID", "Имя", "Фамилия", "Очество", "Должность", "Номер телефона", "Возраст", "Отдел" };
                worksheet.Columns[1].ColumnWidth = 5;
                worksheet.Columns[2].ColumnWidth = 15;
                worksheet.Columns[3].ColumnWidth = 15;
                worksheet.Columns[4].ColumnWidth = 15;
                worksheet.Columns[5].ColumnWidth = 20;
                worksheet.Columns[6].ColumnWidth = 20;
                worksheet.Columns[7].ColumnWidth = 10;
                worksheet.Columns[8].ColumnWidth = 25;
                worksheet.Cells.Font.Name = "Helvetica";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                    var employeeCount = (int)command.ExecuteScalar();

                    worksheet.Range["J1:K1"].Value = new object[] { "Количество сотрудников:", employeeCount };

                    command = new SqlCommand("SELECT * FROM Employees", connection);
                    var adapter = new SqlDataAdapter(command);
                    var dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);

                    var row = 2;
                    var column = 1;

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        worksheet.Cells[row, column].Value = dataRow["id"].ToString();
                        worksheet.Cells[row, column + 1].Value = dataRow["first_name"].ToString();
                        worksheet.Cells[row, column + 2].Value = dataRow["last_name"].ToString();
                        worksheet.Cells[row, column + 3].Value = dataRow["patronymic"].ToString();
                        worksheet.Cells[row, column + 4].Value = dataRow["position"].ToString();
                        worksheet.Cells[row, column + 5].Value = dataRow["phone_number"].ToString();
                        worksheet.Cells[row, column + 6].Value = dataRow["age"].ToString();
                        worksheet.Cells[row, column + 7].Value = dataRow["direction_of_development"].ToString();

                        if (dataRow["direction_of_development"].ToString() == "NTT DATA")
                        {
                            worksheet.Cells[row, column + 7].Font.Bold = true;
                        }

                        row++;
                    }

                    workbook.SaveAs(saveFileDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();
                }

                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(excelApp);

                MessageBox.Show("Report saved successfully!");
            }
        }



            private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_back(object sender, RoutedEventArgs e)
        {
            var Form = new Administrator_control();
            Form.Show();
            this.Close();
        }
    }
}