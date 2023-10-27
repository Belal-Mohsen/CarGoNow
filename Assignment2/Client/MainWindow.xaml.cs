﻿using Assignment1.Models;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
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
        HttpClient client = new HttpClient();
        public MainWindow()
        {
            client.BaseAddress = new Uri("https://localhost:7120/Product/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }


        private async void BtnShowAll_Click(object sender, RoutedEventArgs e)
        {
            var server_response = await client.GetStringAsync("GetAllProducts");
            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);



            dataGrid.ItemsSource = response_JSON.products;
            DataContext = this;

        }

        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Id = int.Parse(TBProID.Text);
            product.Name = TBProNm.Text;
            product.Amount = int.Parse(TBProAm.Text);
            product.Price = double.Parse(TBProPrc.Text);
            
            var server_response = await client.PutAsJsonAsync("UpdateProduct", product);
            MessageBox.Show("Product updated successfully!");

        }

        private async void BtnSlct_Click(object sender, RoutedEventArgs e)
        {
            var server_response = await client.GetStringAsync("GetProductById/" + int.Parse(TBProIdSr.Text));
            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

            TBProNm.Text = response_JSON.product.Name;
            TBProID.Text = response_JSON.product.Id.ToString();
            TBProAm.Text = response_JSON.product.Amount.ToString();
            TBProPrc.Text = response_JSON.product.Price.ToString();
        }

        private async void BtnInsrt_Click(object sender, RoutedEventArgs e)
        {

            Product product = new Product();
            //product.Id = int.Parse(TBProIdSr.Text);
            product.Name = TBProNm.Text;
            product.Amount = int.Parse(TBProAm.Text);
            product.Price = double.Parse(TBProPrc.Text);


            var server_response = await client.PostAsJsonAsync("AddProduct", product);

            //Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response.ToString());
            //MessageBox.Show(server_response.ToString());
            MessageBox.Show("Product inserted successfully!");

        }

        private async void BtnDlt_Click(object sender, RoutedEventArgs e)
        {
            var response_JSON = await client.DeleteAsync("DeleteProduct/" + int.Parse(TBProIdSr.Text));
            MessageBox.Show("Product Deleted successfully!");
            //MessageBox.Show(response_JSON.StatusCode.ToString());
            //MessageBox.Show(response_JSON.RequestMessage.ToString());

        }

        private void btnSales_Click(object sender, RoutedEventArgs e)
        {
            Sales sales = new Sales();
            sales.Show();
        }
    }
}