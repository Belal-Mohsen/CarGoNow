using CarGoNowApp.Data;
using CarGoNowApp.Models;
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
    /// Interaction logic for UCBill.xaml
    /// </summary>
    public partial class UCBill : UserControl
    {
        CarGoNowDBConnection dbConnection = new CarGoNowDBConnection();
        BillCalc BillCalc = new BillCalc();
        private void showData()
        {
            DataTable data = dbConnection.ShowAllBills();
            dataGrid.ItemsSource = data.DefaultView;
        }
        public UCBill()
        {
            InitializeComponent();
            showData();
            
        }

        private void btn_add_Bill_Click(object sender, RoutedEventArgs e)
        {
            if( boxPaymentMethod.SelectedIndex>=0 &&
                pickerPaymentDate.SelectedDate.HasValue && int.TryParse(txtRentalID.Text, out int inValue))
            {
                object[] rentalInfo = dbConnection.GetRentalById(int.Parse(txtRentalID.Text));
                DateTime  start_day = (DateTime) rentalInfo[1];
                DateTime end_day = (DateTime)rentalInfo[2];
                TimeSpan timeDifference = end_day - start_day;
                int numberOfDays = (int)timeDifference.TotalDays;
                int car_renal = (int) rentalInfo[3];
                double car_price = dbConnection.SelectCar(car_renal);
                double amount = BillCalc.billAmount(numberOfDays, car_price);

                dbConnection.InsertBill(boxPaymentMethod.Text, amount, pickerPaymentDate.SelectedDate.Value, int.Parse(txtRentalID.Text));
                showData();
            }
            else
            {
                MessageBox.Show("Invalid Values for the Bill!");
            }
            
            
        }
        

        private void btn_updt_Bill_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtTotalAmount.Text, out double value) && boxPaymentMethod.SelectedIndex >= 0 &&
                pickerPaymentDate.SelectedDate.HasValue && int.TryParse(txtRentalID.Text, out int inValue))
            {
                dbConnection.UpdateBill(int.Parse(txtPayID.Text),boxPaymentMethod.Text, double.Parse(txtTotalAmount.Text), pickerPaymentDate.SelectedDate.Value, int.Parse(txtRentalID.Text));
                showData();
            }
            else
            {
                MessageBox.Show("Invalid Values for the Bill!");
            }

        }

        private void btn_dlt_Bill_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(txtPayID.Text, out int value))
            {
                dbConnection.delete(int.Parse(txtPayID.Text),"bill_id", "Bill");
                showData();
            }
            else
            {
                MessageBox.Show("Please select a bill!");
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)dataGrid.SelectedItem;
                txtPayID.Text = selectedRow["bill_id"].ToString();
                txtTotalAmount.Text = selectedRow["amount"].ToString();
                txtRentalID.Text = selectedRow["r_id"].ToString();
                pickerPaymentDate.SelectedDate = selectedRow["payment_date"] as DateTime?;
                string comboBoxValue = selectedRow["payment_method"] as string;

                // Set the ComboBox selected item
                if (!string.IsNullOrEmpty(comboBoxValue))
                {
                    foreach (ComboBoxItem item in boxPaymentMethod.Items)
                    {
                        if (item.Content.ToString() == comboBoxValue)
                        {
                            boxPaymentMethod.SelectedItem = item;
                            break;
                        }
                    }
                }
                else
                {
                    boxPaymentMethod.SelectedItem = null;
                }
            }
        }
    }
}
