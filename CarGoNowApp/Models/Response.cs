using CarGoNowApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGoNowApp.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
        public Employee employee { get; set; }
        public List<Employee> employees { get; set; }
    }
}
