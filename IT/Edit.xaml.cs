
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace IT
{
    public partial class EditInformation : Window
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ITEntities"].ConnectionString;

        public EditInformation()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }





        private void back_Click(object sender, RoutedEventArgs e)
        {
            var Form = new dataEmploye();
            Form.Show();
            this.Close();
        }




      

        private void update_clixk(object sender, RoutedEventArgs e)
        {
            // Update the database based on the ID entered in texboxID
            string connectionString = ConfigurationManager.ConnectionStrings["ITEntities"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE employees SET first_name = @name, last_name = @last_name, patronymic = @patronymic, position = @position, phone_number = @phone_number, age = @age, direction_of_development = @direction_of_development WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", int.Parse(texboxID.Text));
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@last_name", txtSurname.Text);
                cmd.Parameters.AddWithValue("@patronymic", Patronymic.Text);
                cmd.Parameters.AddWithValue("@position", txtPosition.Text);
                cmd.Parameters.AddWithValue("@phone_number", txt_Phone_number.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(txtAge.Text));
                cmd.Parameters.AddWithValue("@direction_of_development", Otdel.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            // Retrieve data from the database based on the ID entered in textId
            string connectionString = ConfigurationManager.ConnectionStrings["ITEntities"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM employees WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", int.Parse(texboxID.Text));
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate the textboxes with the data retrieved from the database
                        txtName.Text = reader["first_name"].ToString();
                        txtSurname.Text = reader["last_name"].ToString();
                        Patronymic.Text = reader["patronymic"].ToString();
                        txtPosition.Text = reader["position"].ToString();
                        txt_Phone_number.Text = reader["phone_number"].ToString();
                        txtAge.Text = reader["age"].ToString();
                        Otdel.Text = reader["direction_of_development"].ToString();
                    }
                }
            }
        }


        private void txtPosition_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Patronymic_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
