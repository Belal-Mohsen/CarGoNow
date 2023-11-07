using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGoNowApp.Models
{
    public class BillCalc
    {
        public double billAmount(int numOfDays, double price)
        {
            return numOfDays * price;
        }
    }
}
