using Lab1.Models;
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
using System.Windows.Shapes;

namespace Lab1
{
    /// <summary>
    /// Interaction logic for Problem2.xaml
    /// </summary>
    public partial class Problem2 : Window
    {
        public Problem2()
        {
            InitializeComponent();
        }

        private void calc_charges_Click(object sender, RoutedEventArgs e)
        {
            labOneFunc func = new labOneFunc();
            double totalCharges = 0;
            try
            {
                double weightPackage = double.Parse(w_package.Text);
                double shippingDistance = double.Parse(s_distance.Text);
                totalCharges = func.shippingCost(weightPackage, shippingDistance);
                s_charges.Content = "$" + (totalCharges.ToString("F"));
            }
            catch {
                MessageBox.Show("Invalid input, please enter valid numbers");
            } 
        }

        
    }
}
