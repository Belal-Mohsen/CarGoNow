using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarGoNowApp.Data
{
    public class CarGoNowDBConnection
    {
        private void establishConnection()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(get_ConnectionString()))
                {
                    conn.Open();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DataBase cannot be connected! " + ex.Message);
            }
        }
        private string get_ConnectionString()
        {
            string server = "localhost";
            string database = "cargonowdb";
            string uid = "root";
            string pass = "Pass4Desk";

            string constring = "Server=" + server + "; database=" + database + "; uid=" + uid + "; pwd=" + pass;
            return constring;
        }
        // Deadline: Wed 11/Oct/2023
        // for car, clients,employee, => Diana
        // bill, res, login, delete for all => Belal
        // showAll(whole table), update(row), insert(row), select(row)
        // for all tables
        // on delete
        public void delete (int id, string tableName)
        {

        }
        public void showAllEmployees()
        {

        }
        public void AddEmployee(string name)
        {

        }
        public void showAllCars()
        {

        }


    }
}
