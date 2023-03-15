using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace IT
{
    /// <summary>
    /// Логика взаимодействия для Add_Information_order.xaml
    /// </summary>
    public partial class Add_Information_order : Window
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ITEntities"].ConnectionString;
        public Add_Information_order()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string productName = txtPatronymic.Text;
            int quantity = int.Parse(txt_qiantity.Text);
            decimal price = decimal.Parse(txtPrice.Text);
            DateTime orderDate = DateTime.Parse(order_date.Text);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("INSERT INTO Orders (customer, product, order_date, quantity, total_price) VALUES(ISNULL((SELECT customer_id FROM Customer WHERE first_name = @FirstName AND last_name = @LastName), 0), (SELECT product_id FROM Product WHERE product_name = @ProductName), @OrderDate, @Quantity, @TotalPrice)", connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@OrderDate", orderDate);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@TotalPrice", quantity * price);

                    command.ExecuteNonQuery();
                }
            }

            // Clear the textboxes after adding the data
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPatronymic.Text = "";
            txt_qiantity.Text = "";
            txtPrice.Text = "";
            order_date.Text = "";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var form = new orders();
            form.Show();
            this.Close();
        }

        private void txtFirstName_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
