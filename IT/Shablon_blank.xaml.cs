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
    /// Логика взаимодействия для Shablon_blank.xaml
    /// </summary>
    public partial class Shablon_blank : Window
    {
        public Shablon_blank()
        {
            InitializeComponent();
        }

        private void work_shablon_click(object sender, RoutedEventArgs e)
        {
            var form = new Work_Shablon();
            form.Show();
            this.Close();
        }

        private void back_document_click(object sender, RoutedEventArgs e)
        {
            var form = new Documents();
            form.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void The_condition_of_the_contract(object sender, RoutedEventArgs e)
        {
            var form = new The_condition_of_the_contract();
            form.Show();
            this.Close();
        }

        private void Auto_Doc(object sender, RoutedEventArgs e)
        {
            var form = new Fill_Doc();
            form.Show();
            this.Close();
        }
    }
}
