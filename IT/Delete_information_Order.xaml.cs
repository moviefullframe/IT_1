using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace IT
{
    /// <summary>
    /// Логика взаимодействия для Delete_information_Order.xaml
    /// </summary>
    public partial class Delete_information_Order : Window
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ITEntities"].ConnectionString;
        public Delete_information_Order()
        {
            InitializeComponent();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("DELETE FROM orders WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", txtID.Text);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 1)
                    {
                        txtStatus.Text = "The record has been successfully deleted.";
                        
                    }
                    else
                    {
                        txtStatus.Text = "Error deleting the record.";
                    }
                }
            }
        }

    }
}
