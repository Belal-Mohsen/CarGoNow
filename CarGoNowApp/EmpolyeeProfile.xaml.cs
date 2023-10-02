using CarGoNowApp.Views;
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

namespace CarGoNowApp
{
    /// <summary>
    /// Interaction logic for EmpolyeeProfile.xaml
    /// </summary>
    public partial class EmpolyeeProfile : Window
    {
        public EmpolyeeProfile()
        {
            InitializeComponent();
        }
        private void signout_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void manage_settings_btn_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UCSettings();

        }

        private void manage_bill_btn_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UCBill();

        }

        private void manage_rs_btn_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UCReservation();
        }

        private void manage_cu_btn_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UCCustomer();
        }

        private void manage_car_btn_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UCEmCar();
        }


    }
}
