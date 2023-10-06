using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CarGoNowApp.Data
{
    public class CarGoNowDBConnection
    {
        public static MySqlConnection conn;
        public static MySqlCommand cmd;
        private void establishConnection()
        {
            try
            {

                conn = new MySqlConnection(get_ConnectionString());

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
            string pass = "devdiana2210";

            string constring = "Server=" + server + "; database=" + database + "; uid=" + uid + "; pwd=" + pass;
            return constring;
        }
        // Deadline: Wed 11/Oct/2023
        // for car, clients,employee, => Diana
        // bill, res, login, delete for all => Belal
        // showAll(whole table), update(row), insert(row), select(row)
        // for all tables
        // on delete

        //question.. do I need add a select button on employee/ car/ customer windows?
        
        public DataTable showAllEmployees(string f_name, string l_name, string role, string sin)
        {
            try
            {
                establishConnection();
                conn.Open();
                string Query = "select * from employee";
                cmd = new MySqlCommand(Query, conn);

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                dataAdapter.Fill(dt);
                //dataGrid.ItemsSource = dt.AsDataView();
                //DataContext = dataAdapter;
                conn.Close();
                return dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public void AddEmployee(string f_name, string l_name, string role, string sin)
        {
            try
            {
                establishConnection();
                conn.Open();

                string Query = "add into employee  values(default, @fname, @lname,@role, @sin )";
                cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@fname", f_name);
                cmd.Parameters.AddWithValue("@lname", l_name);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@sin", sin);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Created Successfully!");
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateEmployee(string f_name, string l_name, string role, string sin)
        {
            try
            {
                establishConnection();
                conn.Open();
                string Query = "Update employee set f_name=@fname, l_name=@lname, role=@role, sin=@sin where em_id=@ID";
                cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@fname", f_name);
                cmd.Parameters.AddWithValue("@lname", l_name);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@sin", sin);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Update successful");
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void SelectEmployee(int id, string f_name, string l_name, string role, string sin) 
        {
            try
            {
                establishConnection();
                conn.Open();
                string Query = "select * from employee where em_id=@id";
                cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr = cmd.ExecuteReader(); // read line or more, dataadapter is good for the multi lines
                //bool flag = false;
                while (dr.Read())
                {
                    //flag = true;
                    //TBProNm.Text = dr["pro_name"].ToString();
                    //TBProID.Text = dr["pro_id"].ToString();
                    //TBProAm.Text = dr["pro_amount"].ToString();
                    //TBProPrc.Text = dr["pro_price"].ToString();
                }
                //if (!flag)
                //{
                    //TBProNm.Text = "";
                    //TBProID.Text = "";
                    //TBProAm.Text = "";
                    //TBProPrc.Text = "";
                    MessageBox.Show("No data with this ID found!");

                //}
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable showAllCar(string model, int availability, int year, string color, string license_plate, 
            string transmission_type, string maintenance_history, string insurance_details, double price_per_day)
        {
            try
            {
                establishConnection();
                conn.Open();
                string Query = "select * from car";
                cmd = new MySqlCommand(Query, conn);

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                dataAdapter.Fill(dt);
                //dataGrid.ItemsSource = dt.AsDataView();
                //DataContext = dataAdapter;
                conn.Close();
                return dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public void AddCar(string model, int availability, int year, string color, string license_plate,
            string transmission_type, string maintenance_history, string insurance_details, double price_per_day)
        {
            try
            {
                establishConnection();
                conn.Open();

                string Query = "add into car  values(default, @model, @availability,@year, @color, @licenceplate, " +
                    "@transmissiontype, @maintenancehistory, @insurancedetails, @priceperday )";
                cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@availability", availability);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@licenceplate", license_plate);
                cmd.Parameters.AddWithValue("@transmissiontype", transmission_type);
                cmd.Parameters.AddWithValue("@maintenancehistory", maintenance_history);
                cmd.Parameters.AddWithValue("@insurancedetails", insurance_details);
                cmd.Parameters.AddWithValue("@priceperday", price_per_day);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Car Created Successfully!");
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateCar(string model, int availability, int year, string color, string license_plate,
            string transmission_type, string maintenance_history, string insurance_details, double price_per_day)
        {
            try
            {
                establishConnection();
                conn.Open();
                string Query = "Update car set model=@model, availability=@availability,year=@year, color=@color, licence_plate@licenceplate, " +
                    "transmission_type=@transmissiontype, maintenance_history=@maintenancehistory, insurance_details=@insurancedetails, price_per_day=@priceperday where em_id=@ID";
                cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@availability", availability);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@licenceplate", license_plate);
                cmd.Parameters.AddWithValue("@transmissiontype", transmission_type);
                cmd.Parameters.AddWithValue("@maintenancehistory", maintenance_history);
                cmd.Parameters.AddWithValue("@insurancedetails", insurance_details);
                cmd.Parameters.AddWithValue("@priceperday", price_per_day);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Update successful");
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SelectCar(int id,string model, int availability, int year, string color, string license_plate,
            string transmission_type, string maintenance_history, string insurance_details, double price_per_day)
        {
            try
            {
                establishConnection();
                conn.Open();
                string Query = "select * from car where em_id=@id";
                cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr = cmd.ExecuteReader(); // read line or more, dataadapter is good for the multi lines
                //bool flag = false;
                while (dr.Read())
                {
                    //flag = true;
                    //TBProNm.Text = dr["pro_name"].ToString();
                    //TBProID.Text = dr["pro_id"].ToString();
                    //TBProAm.Text = dr["pro_amount"].ToString();
                    //TBProPrc.Text = dr["pro_price"].ToString();
                }
                //if (!flag)
                //{
                //TBProNm.Text = "";
                //TBProID.Text = "";
                //TBProAm.Text = "";
                //TBProPrc.Text = "";
                MessageBox.Show("No data with this ID found!");

                //}
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable showAllCustomer(string f_name, string l_name, string phone_number, string email, 
            string driving_license, DateTime dl_expiry_date)
        {
            try
            {
                establishConnection();
                conn.Open();
                string Query = "select * from customer";
                cmd = new MySqlCommand(Query, conn);

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                dataAdapter.Fill(dt);
                //dataGrid.ItemsSource = dt.AsDataView();
                //DataContext = dataAdapter;
                conn.Close();
                return dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public void AddCustomer(string f_name, string l_name, string phone_number, string email,
            string driving_license, DateTime dl_expiry_date)
        {
            try
            {
                establishConnection();
                conn.Open();

                string Query = "add into customer  values(default, @fname, @lname,@phonenumber, @email, @drivinglicense, @dlexpirydate )";
                cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@fname", f_name);
                cmd.Parameters.AddWithValue("@lname", l_name);
                cmd.Parameters.AddWithValue("@phonenumber", phone_number);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@drivinglicense", driving_license);
                cmd.Parameters.AddWithValue("@dlexpirydate", dl_expiry_date);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Created Successfully!");
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void UpdateCustomer(string f_name, string l_name, string phone_number, string email,
            string driving_license, DateTime dl_expiry_date)
        {
            try
            {
                establishConnection();
                conn.Open();
                string Query = "Update customer set f_name=@fname, l_name=@lname,phone_number=@phonenumber, email=@email, " +
                    "driving_license=@drivinglicense, dl_expry_date=@dlexpirydate where em_id=@ID";
                cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@fname", f_name);
                cmd.Parameters.AddWithValue("@lname", l_name);
                cmd.Parameters.AddWithValue("@phonenumber", phone_number);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@drivinglicense", driving_license);
                cmd.Parameters.AddWithValue("@dlexpirydate", dl_expiry_date);
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update successful");
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void SelectCustomer(int id, string f_name, string l_name, string phone_number, string email,
            string driving_license, DateTime dl_expiry_date)
        {
            try
            {
                establishConnection();
                conn.Open();
                string Query = "select * from customer where em_id=@id";
                cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr = cmd.ExecuteReader(); // read line or more, dataadapter is good for the multi lines
                //bool flag = false;
                while (dr.Read())
                {
                    //flag = true;
                    //TBProNm.Text = dr["pro_name"].ToString();
                    //TBProID.Text = dr["pro_id"].ToString();
                    //TBProAm.Text = dr["pro_amount"].ToString();
                    //TBProPrc.Text = dr["pro_price"].ToString();
                }
                //if (!flag)
                //{
                //TBProNm.Text = "";
                //TBProID.Text = "";
                //TBProAm.Text = "";
                //TBProPrc.Text = "";
                MessageBox.Show("No data with this ID found!");

                //}
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
