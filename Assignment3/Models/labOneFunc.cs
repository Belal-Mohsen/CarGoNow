using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class labOneFunc
    {
        public double monthlyFees(int parsed_n_checks, double parsed_acc_balance)
        {
            double total_fees = 10;
            if (parsed_n_checks < 20)
            {
                total_fees += parsed_n_checks * 0.1;
            }
            else if (parsed_n_checks < 40)
            {
                total_fees += parsed_n_checks * 0.08;
            }
            else if (parsed_n_checks < 60)
            {
                total_fees += parsed_n_checks * 0.06;
            }
            else
            {
                total_fees += parsed_n_checks * 0.1;
            }

            if (parsed_acc_balance < 400)
            {
                total_fees += 15;
            }

            return total_fees;
        }

        public double shippingCost(double weightPackage, double shippingDistance)
        {
            double totalCharges = 0;

            if (weightPackage <= 2)
            {
                totalCharges = 1.10;
            }
            else if (weightPackage <= 6)
            {
                totalCharges = 2.20;
            }
            else if (weightPackage <= 10)
            {
                totalCharges = 3.70;
            }
            else
            {
                totalCharges = 4.80;
            }

            totalCharges *= Math.Ceiling((shippingDistance / 500));

            return totalCharges;
        }

        public int calcDayPopulationRate(int daysPopulations, double incRate)
        {
            int dayPop = (int)(daysPopulations * incRate);
            return dayPop;
        }
    }
}
