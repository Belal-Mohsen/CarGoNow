using Assignment1.Models;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
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
        HttpClient client = new HttpClient();
        public Sales()
        {
            client.BaseAddress = new Uri("https://localhost:7120/Product/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        public static NpgsqlCommand cmd;
        public static NpgsqlConnection pg_connection;
        List<Product> cart = new List<Product>();
        public static object[] dataReadDB = new object[3];
        public static double total_price;
        public static bool isValidID;






        private async void BtnChkOut_Click(object sender, RoutedEventArgs e)
        {
            double total_price_sales = 0;
            if (cart.Count == 0)
            {
                MessageBox.Show("Your cart is empty!");
            }
            else
            {
                foreach (Product product in cart)
                {
                    await UpdateInventory(product.Id, product.Amount);
                    total_price_sales += total_price;
                    // MessageBox.Show("Product: " + product.Id + "  Amount: " + product.Amount);
                }
                lbl_total.Content = "$" + total_price_sales.ToString("F");
                cart.Clear();
            }
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TBProIdSr.Text, out int value1) && int.TryParse(TBProAm.Text, out int value2))
            {
                checkID(int.Parse(TBProIdSr.Text), () =>
                {
                    if (isValidID)
                    {
                        cart.Add(new Product { Id = int.Parse(TBProIdSr.Text), Amount = int.Parse(TBProAm.Text) });
                        TBProAm.Text = "";
                        TBProIdSr.Text = "";
                        MessageBox.Show("Product added to the cart!");
                    }
                });
            }
            else
            {
                MessageBox.Show("Invalid value for search ID or amount !");
            }

        }

        private async void BtnShowAll_Click(object sender, RoutedEventArgs e)
        {
            var server_response = await client.GetStringAsync("GetAllProducts");
            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);



            dataGrid.ItemsSource = response_JSON.products;
            DataContext = this;
        }


        private async Task UpdateInventory(int proId, int proAmount)
        {
            
                total_price = 0;
            Product product = new Product();
            readDB(proId, () =>
            {

                
                product.Id = proId;
                product.Name = (string)dataReadDB[2];
                product.Amount = (int)dataReadDB[0] - proAmount;
                product.Price = (double)dataReadDB[1];

                
            });

            var server_response = await client.PutAsJsonAsync("UpdateProduct", product);
            total_price += (double)dataReadDB[1] * proAmount;

        }
    

        private async void readDB(int id,  Action callback) {
            var server_response = await client.GetStringAsync("GetProductById/" + id);
            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

            if (response_JSON != null && response_JSON.product != null)
            {
                int pro_amount = response_JSON.product.Amount;
                double pro_price = response_JSON.product.Price;
                string pro_name = response_JSON.product.Name;

                dataReadDB[0] = pro_amount;
                dataReadDB[1] = pro_price;
                dataReadDB[2] = pro_name;
            }
            else

            {
                MessageBox.Show("No data with this ID found!");

            } 
            callback();
        }

        private async void checkID(int id, Action callback)
        {
            isValidID = false;

            var server_response = await client.GetStringAsync("GetProductById/" + id);
            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);
            if (response_JSON.statusCode == 200)
               {
                 isValidID = true;
               }
            if (!isValidID)
               {
                 MessageBox.Show("No data with this ID found!");

               }
            callback();
        }
        }
    }

