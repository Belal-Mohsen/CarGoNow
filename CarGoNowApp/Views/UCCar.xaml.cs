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
    /// Interaction logic for UCCar.xaml
    /// </summary>
    public partial class UCCar : UserControl
    {
        CarGoNowDBConnection dbConnection = new CarGoNowDBConnection();

        private void showData()
        {
            DataTable data = dbConnection.showAllCar();
            dataGrid.ItemsSource = data.DefaultView;
        }
        public UCCar()
        {
            InitializeComponent();
            showData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtModel.Text) && int.TryParse(txtAvailability.Text, out int inValue) &&
                !string.IsNullOrWhiteSpace(txtTType.Text) && double.TryParse(txtPPDay.Text, out double value) &&
                int.TryParse(txtYear.Text, out int result) && !string.IsNullOrWhiteSpace(txtColor.Text) &&
                !string.IsNullOrWhiteSpace(txtLPlate.Text) && !string.IsNullOrWhiteSpace(txtMHistory.Text) &&
                !string.IsNullOrWhiteSpace(txtIDetails.Text))

            {
                dbConnection.AddCar(txtModel.Text, int.Parse(txtAvailability.Text), int.Parse(txtYear.Text), txtColor.Text,
                    txtLPlate.Text, txtTType.Text, txtMHistory.Text, txtIDetails.Text, double.Parse(txtPPDay.Text));
                showData();
            }
            else
            {
                MessageBox.Show("Invalid Values for the Car!");
            }
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtCarID.Text, out int value) && !string.IsNullOrWhiteSpace(txtModel.Text) && int.TryParse(txtAvailability.Text, out int inValue) &&
                !string.IsNullOrWhiteSpace(txtTType.Text) && double.TryParse(txtPPDay.Text, out double xvalue) &&
                int.TryParse(txtYear.Text, out int result) && !string.IsNullOrWhiteSpace(txtColor.Text) &&
                !string.IsNullOrWhiteSpace(txtLPlate.Text) && !string.IsNullOrWhiteSpace(txtMHistory.Text) &&
                !string.IsNullOrWhiteSpace(txtIDetails.Text))

            {
                dbConnection.UpdateCar(int.Parse(txtCarID.Text), txtModel.Text, int.Parse(txtAvailability.Text), int.Parse(txtYear.Text), txtColor.Text,
                     txtLPlate.Text, txtTType.Text, txtMHistory.Text, txtIDetails.Text, double.Parse(txtPPDay.Text));
                showData();
            }
            else
            {
                MessageBox.Show("Invalid Values for the Car!");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtCarID.Text, out int value))
            {
                dbConnection.delete(int.Parse(txtCarID.Text), "car_id", "Car");
                showData();
            }
            else
            {
                MessageBox.Show("Please select a car!");
            }
        }
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)dataGrid.SelectedItem;
                txtCarID.Text = selectedRow["car_id"].ToString();
                txtModel.Text = selectedRow["model"].ToString();
                txtAvailability.Text = selectedRow["availability"].ToString();
                txtTType.Text = selectedRow["transmission_type"].ToString();
                txtPPDay.Text = selectedRow["price_per_day"].ToString();
                txtYear.Text = selectedRow["year"].ToString();
                txtColor.Text = selectedRow["color"].ToString();
                txtLPlate.Text = selectedRow["license_plate"].ToString();
                txtMHistory.Text = selectedRow["maintenance_history"].ToString();
                txtIDetails.Text = selectedRow["insurance_details"].ToString();



            }
            else
            {
                dataGrid.SelectedItem = null;
                MessageBox.Show("Please select a row!");
            }

        }


    }
}
