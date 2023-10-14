using CarGoNowApp.Data;
using Org.BouncyCastle.Asn1.Ocsp;
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

namespace CarGoNowApp.Views
{
    /// <summary>
    /// Interaction logic for UCReservation.xaml
    /// </summary>
    public partial class UCReservation : UserControl
    {
        CarGoNowDBConnection dbConnection = new CarGoNowDBConnection();
        private void showData()
        {
            DataTable data = dbConnection.ShowAllRentals();
            dataGrid.ItemsSource = data.DefaultView;
        }
        public UCReservation()
        {
            InitializeComponent();
            txtEmployeeId.Text = App.UserID.ToString();
            showData();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)dataGrid.SelectedItem;
                txtRentalID.Text = selectedRow["r_id"].ToString();
                txtCarId.Text = selectedRow["car_id"].ToString();
                txtCustomerId.Text = selectedRow["cu_id"].ToString();
                txtEmployeeId.Text = selectedRow["em_id"].ToString();
                pickerCheckin.SelectedDate = selectedRow["check_in"] as DateTime?;
                pickerCheckout.SelectedDate = selectedRow["check_out"] as DateTime?;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (pickerCheckin.SelectedDate.HasValue &&
                pickerCheckout.SelectedDate.HasValue &&
                int.TryParse(txtRentalID.Text, out int reValue) && int.TryParse(txtCarId.Text, out int carValue) &&
                int.TryParse(txtCustomerId.Text, out int cusValue) && int.TryParse(txtEmployeeId.Text, out int emValue))
            {
                dbConnection.UpdateRental(int.Parse(txtRentalID.Text), pickerCheckin.SelectedDate.Value, pickerCheckout.SelectedDate.Value
                    , int.Parse(txtCarId.Text), int.Parse(txtCustomerId.Text), int.Parse(txtEmployeeId.Text));
                showData();
            }
            else
            {
                MessageBox.Show("Invalid Values for the Reservation!");
            }
        }

        private void btnDlt_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtRentalID.Text, out int value))
            {
                dbConnection.delete(int.Parse(txtRentalID.Text), "r_id", "Rental");
                showData();
            }
            else
            {
                MessageBox.Show("Please select a reservation!");
            }
        }

        private void btnMakeRes_Click(object sender, RoutedEventArgs e)
        {
            if (pickerCheckin.SelectedDate.HasValue &&
               pickerCheckout.SelectedDate.HasValue &&
               int.TryParse(txtCarId.Text, out int carValue) &&
               int.TryParse(txtCustomerId.Text, out int cusValue) && int.TryParse(txtEmployeeId.Text, out int emValue))
            {
                dbConnection.InsertRental(pickerCheckin.SelectedDate.Value, pickerCheckout.SelectedDate.Value
                    , int.Parse(txtCarId.Text), int.Parse(txtCustomerId.Text), int.Parse(txtEmployeeId.Text));
                showData();
            }
            else
            {
                MessageBox.Show("Invalid Values for the Reservation!");
            }
        }
    }
}
