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
    /// Interaction logic for UCCustomer.xaml
    /// </summary>
    public partial class UCCustomer : UserControl
    {
        CarGoNowDBConnection dbConnection = new CarGoNowDBConnection();
        private void showData()
        {
            DataTable data = dbConnection.showAllCustomer();
            dataGrid.ItemsSource = data.DefaultView;
        }
        public UCCustomer()
        {
            InitializeComponent();
            showData();
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtCustomerID.Text, out int value) && !string.IsNullOrWhiteSpace(txtFirstName.Text) && !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                !string.IsNullOrWhiteSpace(txtPhone.Text) && !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                !string.IsNullOrWhiteSpace(txtDLicense.Text) && pickerDLicenseED.SelectedDate.HasValue)

            {
                dbConnection.UpdateCustomer(int.Parse(txtCustomerID.Text), txtFirstName.Text, txtLastName.Text, txtPhone.Text, txtEmail.Text,
                txtDLicense.Text, pickerDLicenseED.SelectedDate.Value);
                showData();
            }

            else
            {
                MessageBox.Show("Invalid Values for the Customer!");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFirstName.Text) && !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                !string.IsNullOrWhiteSpace(txtPhone.Text) && !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                !string.IsNullOrWhiteSpace(txtDLicense.Text) && pickerDLicenseED.SelectedDate.HasValue)
            {
                dbConnection.AddCustomer(txtFirstName.Text, txtLastName.Text, txtPhone.Text, txtEmail.Text,
                txtDLicense.Text, pickerDLicenseED.SelectedDate.Value);
                showData();
            }

            else
            {
                MessageBox.Show("Invalid Values for the Customer!");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtCustomerID.Text, out int value))
            {
                dbConnection.delete(int.Parse(txtCustomerID.Text), "cu_id", "Customer");
                showData();
            }
            else
            {
                MessageBox.Show("Please select a customer!");
            }
        }
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)dataGrid.SelectedItem;
                txtCustomerID.Text = selectedRow["cu_id"].ToString();
                txtFirstName.Text = selectedRow["f_name"].ToString();
                txtLastName.Text = selectedRow["l_name"].ToString();
                txtPhone.Text = selectedRow["phone_number"].ToString();
                txtEmail.Text = selectedRow["email"].ToString();
                txtDLicense.Text = selectedRow["driving_license"].ToString();
                pickerDLicenseED.SelectedDate = selectedRow["dl_expiry_date"] as DateTime?;

            }
            else
            {
                dataGrid.SelectedItem = null;
                MessageBox.Show("Please select a row!");
            }

        }


    }
}

