using System;
using System.Collections.Generic;
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
        public UCEmployee()
        {
            InitializeComponent();
        }

        CarGoNowDBConnection dbConnection = new CarGoNowDBConnection();
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}