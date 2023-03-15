
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace IT
{
    public partial class orders : Window
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ITEntities"].ConnectionString;

        public orders()
        {
            InitializeComponent();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT o.id AS 'Идентификатор заказа', o.order_date AS 'Дата заказа', " +
    "c.first_name AS 'Имя клиента', c.last_name AS 'Фамилия клиента', p.product_name AS 'Название продукта', " +
    "o.quantity AS 'Количество', o.total_price AS 'Общая стоимость' " +
    "FROM customer c LEFT JOIN orders o ON c.customer_id=o.customer_id " +
    "JOIN product p ON o.product_id = p.product_id ", connection))
                {
                    

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        order_Grid.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
        }



        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var Form = new Add_Information_order();
            Form.Show();
                this.Close();
        }



        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var Form = new Delete_information_Order();
            Form.Show();
            this.Close();
        }
      
        

                   
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }


        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_back(object sender, RoutedEventArgs e)
        {
            var form = new Administrator_control();
            form.Show();
            this.Close();
        }
    }
}
