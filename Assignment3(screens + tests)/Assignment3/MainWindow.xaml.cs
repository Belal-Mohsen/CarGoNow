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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void select_Click(object sender, RoutedEventArgs e)
        {
            if(bc_radio_btn.IsChecked == true)
            {
                BankCharges bankCharges = new BankCharges();
                bankCharges.Show();
            }
            else if(sc_radio_btn.IsChecked == true)
            {
                Problem2 pr2 = new Problem2();
                pr2.Show();

            }
            else if (pp_radio_btn.IsChecked == true)
            {
                Problem3 pr3 = new Problem3();
                pr3.Show();
            }
            else
            {
                MessageBox.Show("Please select a program!");
            }


        }
    }
}
