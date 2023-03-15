using System.Data.SqlClient;
using System.Windows;

namespace IT
{
    /// <summary>
    /// Логика взаимодействия для DeleteInformation.xaml
    /// </summary>
    public partial class DeleteInformation : Window
    {
        public DeleteInformation()
        {
            InitializeComponent();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source = FEDYAKOV\\SQLEXPRESS; Initial Catalog = IT; Integrated Security = True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM employees WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", txtID.Text); int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    MessageBox.Show("Запись успешно удалена. ");
                    
                }
                else
                {
                    MessageBox.Show("Запись найдена. ");
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
           

            var form = new employees();
            this.Close();
        }
    }


}


