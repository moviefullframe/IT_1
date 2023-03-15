using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IT
{
    /// <summary>
    /// Логика взаимодействия для Documents.xaml
    /// </summary>
    public partial class Documents : Window
    {
        public Documents()
        {
            InitializeComponent();
        }

        

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            var form = new Administrator_control();
            form.Show();
            this.Close();
        }

        private void Button_Click_Shablon(object sender, RoutedEventArgs e)
        {
            var form = new Shablon_blank();
            form.Show();
            this.Close();
        }
    }
}
