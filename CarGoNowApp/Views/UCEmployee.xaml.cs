using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
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
using CarGoNowApp.Data;
using CarGoNowApp.Models;
using MySqlX.XDevAPI;
using Newtonsoft.Json;

namespace CarGoNowApp.Views
{
    /// <summary>
    /// Interaction logic for UCEmployee.xaml
    /// </summary>
    public partial class UCEmployee : UserControl
    {
        HttpClient client = new HttpClient();
        //CarGoNowDBConnection dbConnection = new CarGoNowDBConnection();
        private async void showData()
        {
            //DataTable data = dbConnection.showAllEmployees();
            //dataGrid.ItemsSource = data.DefaultView;

            var server_response = await client.GetStringAsync("GetAllEmployees");
            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);



            dataGrid.ItemsSource = response_JSON.employees;
            DataContext = this;
        }
        public UCEmployee()
        {
            client.BaseAddress = new Uri("https://localhost:7289/Emplyee/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
            showData();
        }


        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtEmployeeID.Text, out int value))
            {
                //dbConnection.delete(int.Parse(txtEmployeeID.Text), "em_id", "Employee");
                var response_JSON = await client.DeleteAsync("DeleteEmployee/" + int.Parse(txtEmployeeID.Text));
                MessageBox.Show("Employee Deleted successfully!");
                showData();
            }
            else
            {
                MessageBox.Show("Please select an employee!");
            }
        }


        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtEmployeeID.Text, out int value) && !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                    !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                    !string.IsNullOrWhiteSpace(txtRole.Text) && !string.IsNullOrWhiteSpace(txtSIN.Text))
            {
                //dbConnection.UpdateEmployee(int.Parse(txtEmployeeID.Text), txtFirstName.Text, txtLastName.Text, txtRole.Text, txtSIN.Text);
                Employee employee = new Employee();
                employee.Id = int.Parse(txtEmployeeID.Text);
                employee.fName = txtFirstName.Text;
                employee.lName = txtLastName.Text;
                employee.Role = txtRole.Text;
                employee.Sin = txtSIN.Text;


                var server_response = await client.PutAsJsonAsync("UpdateEmployee", employee);
                MessageBox.Show("Product updated successfully!");
                showData();
            }
            else
            {
                MessageBox.Show("Invalid Values for the Employee!");
            }
        }


        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                    !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                    !string.IsNullOrWhiteSpace(txtRole.Text) && !string.IsNullOrWhiteSpace(txtSIN.Text))
            {
                //dbConnection.AddEmployee(txtFirstName.Text, txtLastName.Text, txtRole.Text, txtSIN.Text);
                Employee employee = new Employee();
                employee.Id = int.Parse(txtEmployeeID.Text);
                employee.fName = txtFirstName.Text;
                employee.lName = txtLastName.Text;
                employee.Role = txtRole.Text;
                employee.Sin = txtSIN.Text;
                var server_response = await client.PostAsJsonAsync("AddEmployee", employee);

                //Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response.ToString());
                //MessageBox.Show(server_response.ToString());
                MessageBox.Show("Employee inserted successfully!");
                showData();
            }
            else
            {
                MessageBox.Show("Invalid Values for the Employee!");
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Employee selectedEmployee = (Employee)dataGrid.SelectedItem;
                txtEmployeeID.Text = selectedEmployee.Id.ToString();
                txtFirstName.Text = selectedEmployee.fName;
                txtLastName.Text = selectedEmployee.lName;
                txtRole.Text = selectedEmployee.Role;
                txtSIN.Text = selectedEmployee.Sin;

            }
            else
            {
                dataGrid.SelectedItem = null;
                MessageBox.Show("Select a row!");

            }

        }
    }
}

