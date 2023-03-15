using System.Windows;


namespace IT
{
    /// <summary>
    /// Логика взаимодействия для Administrator_control.xaml
    /// </summary>
    public partial class Administrator_control : Window
    {
       
        public Administrator_control()
        {

            InitializeComponent();
           
           



    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back()
        {

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            

            
        }

        private void TextBox_Login_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {


        }

        private void Button_Click_Staff(object sender, RoutedEventArgs e)
        {
            var form = new dataEmploye();
            form.Show();
            this.Close();
        }

        private void Button_Click_Documents(object sender, RoutedEventArgs e)
        {
            var form = new Documents();
            form.Show();
            this.Close();
        }

        

        private void Button_Click_orders(object sender, RoutedEventArgs e)
        {
            var form = new orders();
            form.Show();
            this.Close();
        }

        private void Button_Click_Stats(object sender, RoutedEventArgs e)
        {

        }
    }
}
