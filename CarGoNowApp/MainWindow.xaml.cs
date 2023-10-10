using CarGoNowApp.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


namespace CarGoNowApp
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

        CarGoNowDBConnection dbConnection = new CarGoNowDBConnection();
        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = false;
            string username = user_name_input.Text;
            string password = password_input.Password;

            if (login_manager_btn.IsChecked == true)
            {
                isValid = dbConnection.login_c(username, password);
                if (isValid)
                {
                    ManagerProfile managerProfile = new ManagerProfile();
                    managerProfile.Show();
                    this.Close();
                }
            }
            else if (login_em_btn.IsChecked == true)
            {
                isValid = dbConnection.login_c(username, password);
                if (isValid)
                {
                    EmpolyeeProfile empolyeeProfile = new EmpolyeeProfile();
                    empolyeeProfile.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Select Your Role!");
            }
        }
    }
}
