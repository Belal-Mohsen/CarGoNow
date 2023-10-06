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

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = false;
            string username = user_name_input.Text;
            string password = password_input.Password;


            if (login_manager_btn.IsChecked == true)
            {


                // check database for log-in /////
                isValid = checkCredentials(username, password);

                if (isValid)
                {
                    ManagerProfile managerProfile = new ManagerProfile();
                    managerProfile.Show();
                    this.Close();
                }

            }
            else if (login_em_btn.IsChecked == true)
            {

                // check database for log-in /////
                isValid = checkCredentials(username, password);

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

        private bool checkCredentials(string username, string password)
        {
            bool isCredentialsValid = false;
            string server = "localhost";
            string database = "cargonowdb";
            string uid = "root";
            string pass = "devdiana2210";

            string constring = "Server=" + server + "; database=" + database + "; uid=" + uid + "; pwd=" + pass;
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                conn.Open();

                string query = "SELECT * FROM Login WHERE user_name = @username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPasswordHash = reader["password"].ToString();
                        if (password == storedPasswordHash)
                        {
                            isCredentialsValid = true;
                        }
                        else
                        {
                            MessageBox.Show("Invalid password.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("User not found.");
                    }
                }
            }
            return isCredentialsValid;
        }
    }
}
