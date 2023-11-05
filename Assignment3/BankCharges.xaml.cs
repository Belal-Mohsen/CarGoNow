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
    /// Interaction logic for BankCharges.xaml
    /// </summary>
    public partial class BankCharges : Window
    {
        public BankCharges()
        {
            InitializeComponent();
        }

        private void calc_fees_Click(object sender, RoutedEventArgs e)
        {
            labOneFunc func = new labOneFunc();
            double totalMonthlyFees = 0;
            
            try
            {
                int parsed_n_checks = int.Parse(n_checks.Text);
                double parsed_acc_balance = double.Parse(acc_balance.Text);
                totalMonthlyFees = func.monthlyFees(parsed_n_checks, parsed_acc_balance);
                bs_total_fees.Content = "$" + (totalMonthlyFees.ToString("F"));
            }
            catch
            {
                MessageBox.Show("Invalid input, please enter valid numbers");
            }
        }

        
    }
}
