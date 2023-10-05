using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;

namespace Assignment1
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

        public static NpgsqlCommand cmd;
        public static NpgsqlConnection pg_connection;

        private void establishConnection()
        {
            try
            {
                pg_connection = new NpgsqlConnection(get_ConnectionString());
                //MessageBox.Show("Connection is done");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("DataBase cannot be connected! " + ex.Message);
            }
        }
        private string get_ConnectionString()
        {
            string host = "Host=localhost;";
            string port = "Port=5432;";
            string dbName = "Database=farmDB;";
            string userName = "Username=postgres;";
            string password = "Password=Pass4Desk;";

            string conn = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
            return conn;
        }


        private void BtnShowAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnection();
                pg_connection.Open();
                string Query = "select * from products";
                cmd = new NpgsqlCommand(Query, pg_connection);

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                dataAdapter.Fill(dt);
                dataGrid.ItemsSource = dt.AsDataView();
                DataContext = dataAdapter;
                pg_connection.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TBProID.Text, out int value))
            {

                try
                {
                    establishConnection();
                    pg_connection.Open();
                    string Query = "Update products set pro_name=@name, pro_amount=@amount, pro_price=@price where pro_id=@ID";
                    cmd = new NpgsqlCommand(Query, pg_connection);
                    cmd.Parameters.AddWithValue("@name", TBProNm.Text);
                    cmd.Parameters.AddWithValue("@amount", int.Parse(TBProAm.Text));
                    cmd.Parameters.AddWithValue("@price", double.Parse(TBProPrc.Text));
                    cmd.Parameters.AddWithValue("@ID", int.Parse(TBProIdSr.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update successful");
                    pg_connection.Close();
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid value for product ID!");
            }

        }

        private void BtnSlct_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TBProIdSr.Text, out int value))
            {
                try
                {
                    establishConnection();
                    pg_connection.Open();
                    string Query = "select * from products where pro_id=@id";
                    cmd = new NpgsqlCommand(Query, pg_connection);
                    cmd.Parameters.AddWithValue("@id", int.Parse(TBProIdSr.Text));
                    NpgsqlDataReader dr = cmd.ExecuteReader(); // read line or more, dataadapter is good for the multi lines
                    bool flag = false;
                    while (dr.Read())
                    {
                        flag = true;
                        TBProNm.Text = dr["pro_name"].ToString();
                        TBProID.Text = dr["pro_id"].ToString();
                        TBProAm.Text = dr["pro_amount"].ToString();
                        TBProPrc.Text = dr["pro_price"].ToString();
                    }
                    if (!flag)
                    {
                        TBProNm.Text = "";
                        TBProID.Text = "";
                        TBProAm.Text = "";
                        TBProPrc.Text = "";
                        MessageBox.Show("No data with this ID found!");

                    }
                    pg_connection.Close();
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid value for search ID!");
            }

        }

        private void BtnInsrt_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TBProID.Text, out int value))
            {

                try
                {
                    establishConnection();
                    pg_connection.Open();

                    string Query = "insert into products  values(default, @name, @amount,@price)";
                    cmd = new NpgsqlCommand(Query, pg_connection);
                    cmd.Parameters.AddWithValue("@name", TBProNm.Text);
                    cmd.Parameters.AddWithValue("@amount", int.Parse(TBProAm.Text));
                    cmd.Parameters.AddWithValue("@price", double.Parse(TBProPrc.Text));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Created Successfully!");
                    pg_connection.Close();
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid value for product ID!");
            }

        }

        private void BtnDlt_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TBProID.Text, out int value))
            {
                try
                {
                    establishConnection();
                    pg_connection.Open();
                    string Query = "delete from products where pro_id=@ID";
                    cmd = new NpgsqlCommand(Query, pg_connection);
                    cmd.Parameters.AddWithValue("@ID", int.Parse(TBProIdSr.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Successful");
                    pg_connection.Close();
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid value for product ID!");
            }

        }

        private void btnSales_Click(object sender, RoutedEventArgs e)
        {
            Sales sales = new Sales();
            sales.Show();
        }
    }
}
