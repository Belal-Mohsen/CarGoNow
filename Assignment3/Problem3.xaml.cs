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
    /// Interaction logic for Problem3.xaml
    /// </summary>
    public partial class Problem3 : Window
    {
        public Problem3()
        {
            InitializeComponent();
        }

        private void pop_growth_Click(object sender, RoutedEventArgs e)
        {
            labOneFunc func = new labOneFunc();
            int populationSize = int.Parse(population.Text);
            double incRate = double.Parse(rate.Text)/100;
            int noOfDays = n_days.SelectedIndex + 1;
            int daysPopulations = populationSize;

            if(populationSize < 2 )
            {
                MessageBox.Show("Invalid population size value, please enter a number bigger or equals to 2!");
            } else if(incRate < 0)
            {
                MessageBox.Show("Negative values are not allowed for the increase rate !");
            }

            else
            {
                for (int i = 1; i <= noOfDays; i++)
                {
                    daysPopulations += func.calcDayPopulationRate(daysPopulations,incRate);
                    MessageBox.Show("Day no " + i + " & predicted population: " + daysPopulations);
                }

            }
           
        }
    }
}
