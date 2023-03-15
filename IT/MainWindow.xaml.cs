using System.Data;
using System.Data.SqlClient;
using System.Windows;




namespace IT
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            var Form1 = new Administrator_control();
            Form1.Show();
        }

       

        private void Vissable_pass(object sender, RoutedEventArgs e)
{
    if (txtPassword.PasswordChar == '\0')
    {
        // Show password characters
        txtPassword.PasswordChar = '•';
    }
    else
    {
        // Hide password characters
        txtPassword.PasswordChar = '\0';
    }
}

    }
}
