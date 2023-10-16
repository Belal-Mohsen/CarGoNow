using CarGoNowApp.Data;
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
    /// Interaction logic for UCEmCar.xaml
    /// </summary>
    public partial class UCEmCar : UserControl
    {
        CarGoNowDBConnection dbConnection = new CarGoNowDBConnection();

        private void showData()
        {
            DataTable data = dbConnection.showAllAvailableCar();
            dataGrid.ItemsSource = data.DefaultView;
        }
        public UCEmCar()
        {
            InitializeComponent();
            showData();
        }
    }
}
