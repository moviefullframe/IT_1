using System.Configuration;
using System.Data.SqlClient;
using System.Windows;



namespace IT
{
    /// <summary>
    /// Логика взаимодействия для AddInformation.xaml
    /// </summary>
    public partial class AddInformation : Window
    {
        private string role;
        string connectionString = ConfigurationManager.ConnectionStrings["ITEntities"].ConnectionString;
        public AddInformation()
        {
            InitializeComponent();
            
        }

       

        private void btnSave_Click(object sender, RoutedEventArgs e)

        {
            
            string query = "INSERT INTO employees(first_name, last_name, patronymic, position, phone_number, age, direction_of_development) " +
                           "VALUES (@first_name, @last_name, @patronymic, @position, @phone_number, @age, @direction_of_development)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@first_name", txtFirstName.Text);
                    command.Parameters.AddWithValue("@last_name", txtLastName.Text);
                    command.Parameters.AddWithValue("@patronymic", txtPatronymic.Text);
                    command.Parameters.AddWithValue("@position", txtPosition.Text);
                    command.Parameters.AddWithValue("@phone_number", txtPhoneNumber.Text);
                    command.Parameters.AddWithValue("@age", int.Parse(txtAge.Text));
                    command.Parameters.AddWithValue("@direction_of_development", txtDirectionOfDevelopment.Text);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        var form = new dataEmploye();
                        form.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Запись не добавлена.");
                    }
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var form = new dataEmploye();
            form.Show();
            this.Close();
        }

        private void txtAge_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
