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
using CarGoNowApp.Data;

namespace CarGoNowApp.Views
{
    /// <summary>
    /// Interaction logic for UCEmployee.xaml
    /// </summary>
    public partial class UCEmployee : UserControl
    {
        CarGoNowDBConnection dbConnection = new CarGoNowDBConnection();
        private void showData()
        {
            DataTable data = dbConnection.showAllEmployees();
            dataGrid.ItemsSource = data.DefaultView;
        }
        public UCEmployee()
        {
            InitializeComponent();
            showData();
        }

       
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtEmployeeID.Text, out int value))
            {
                dbConnection.delete(int.Parse(txtEmployeeID.Text), "employee_id", "Employee");
                showData();
            }
            else
            {
                MessageBox.Show("Please select an employee!");
            }
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) && !txtFirstName.Text.Contains(" ") &&
                    string.IsNullOrWhiteSpace(txtLastName.Text) && !txtLastName.Text.Contains(" ") &&
                    string.IsNullOrWhiteSpace(txtRole.Text) && string.IsNullOrWhiteSpace(txtSIN.Text))
            {
                dbConnection.UpdateEmployee(txtFirstName.Text, txtLastName.Text, txtRole.Text, txtSIN.Text);
                showData();
            }
            else
            {
                MessageBox.Show("Invalid Values for the Employee!");
            }
        }
      

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) && !txtFirstName.Text.Contains(" ") && 
                    string.IsNullOrWhiteSpace(txtLastName.Text) && !txtLastName.Text.Contains(" ") && 
                    string.IsNullOrWhiteSpace(txtRole.Text) && string.IsNullOrWhiteSpace(txtSIN.Text))
            {
                dbConnection.AddEmployee(txtFirstName.Text, txtLastName.Text, txtRole.Text, txtSIN.Text);
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
                DataRowView selectedRow = (DataRowView)dataGrid.SelectedItem;
                txtEmployeeID.Text = selectedRow["employee_id"].ToString();
                txtFirstName.Text = selectedRow["f_name"].ToString();
                txtLastName.Text = selectedRow["l_name"].ToString();
                txtRole.Text = selectedRow["role"].ToString();
                txtSIN.Text = selectedRow["sin"].ToString();
            }
            else
            {
                dataGrid.SelectedItem = null;
                MessageBox.Show("Select a row!");

            }

        }
    }
}

