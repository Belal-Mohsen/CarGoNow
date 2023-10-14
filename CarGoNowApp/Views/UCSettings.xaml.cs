using CarGoNowApp.Data;
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

namespace CarGoNowApp.Views
{
    /// <summary>
    /// Interaction logic for UCSettings.xaml
    /// </summary>
    public partial class UCSettings : UserControl
    {
        CarGoNowDBConnection dbConnection = new CarGoNowDBConnection();
        public UCSettings()
        {
            InitializeComponent();
            showData();
        }

        private void showData()
        {
            object[] data =  dbConnection.SelectLoginById(App.UserID);
            txtUsername.Text = data[0].ToString();
            txtPassword.Text = data[1].ToString();

        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username.Length >= 3 && password.Length >= 8)
            {
                dbConnection.UpdateLogin(App.UserID, username, password);
            }
            else
            {
                MessageBox.Show("Username must be at least 3 characters and password must be at least 8 characters.");
            }
        }
    }
}
