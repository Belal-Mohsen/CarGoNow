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
using System.Windows.Shapes;

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        public Sales()
        {
            InitializeComponent();
        }

        public static NpgsqlCommand cmd;
        public static NpgsqlConnection pg_connection;
        List<Product> cart = new List<Product>();

        private void establishConnection()
        {
            try
            {
                pg_connection = new NpgsqlConnection(get_ConnectionString());
                MessageBox.Show("Connection is done");
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

        private void BtnChkOut_Click(object sender, RoutedEventArgs e)
        {
            
            foreach (Product product in cart)
            {
                // UpdateInventory(product.Id, product.Amount);
                MessageBox.Show("Product: " + product.Id + "  Amount: " + product.Amount);
            }

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            cart.Add(new Product {Id = int.Parse(TBProIdSr.Text), Amount = int.Parse(TBProAm.Text) });
            TBProAm.Text = "";
            TBProIdSr.Text = "";
            MessageBox.Show("Product added to the cart!");

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


        private double UpdateInventory(int proId, int proAmount)
        {
            int[] data;
            double total_price = 0;
            data = readDB(proId);
            try
            {
                establishConnection();
                pg_connection.Open();
                string Query = "Update products set  pro_amount=@amount where pro_id=@ID";
                cmd = new NpgsqlCommand(Query, pg_connection);
                cmd.Parameters.AddWithValue("@amount", (data[0] - proAmount));
                cmd.Parameters.AddWithValue("@ID", proId);
                cmd.ExecuteNonQuery();
                pg_connection.Close();
                total_price += data[1] * proAmount;
                return total_price;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        private int[] readDB(int id) {
            int[] data = new int[2];
            try
            {
                establishConnection();
                pg_connection.Open();
                string Query = "select * from products where pro_id=@id";
                cmd = new NpgsqlCommand(Query, pg_connection);
                cmd.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader dr = cmd.ExecuteReader(); // read line or more, dataadapter is good for the multi lines
                bool flag = false;
                while (dr.Read())
                {
                    flag = true;
                    data[0] = (int) dr["pro_amount"];
                    data[1] = (int)dr["pro_price"];
                }
                if (!flag)
                {
                    MessageBox.Show("No data with this ID found!");

                }
                pg_connection.Close();
                return data;
            }
            
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return data;
            }
        }
    }
}
