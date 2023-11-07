using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
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

        //question.. do I need add a select button on employee/ car/ customer windows?

        public DataTable showAllEmployees()
        {
            try
            {
                DataTable dataTable = new DataTable();
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

                string Query = "insert into employee (f_name, l_name, role, sin) Values (@fname, @lname,@role, @sin )";
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
        public void UpdateEmployee(int id, string f_name, string l_name, string role, string sin)
        {
            try
            {
                establishConnection();
                conn.Open();

                string Query = "Update employee set f_name=@fname, l_name=@lname, role=@role, sin=@sin where em_id=@ID";
                using (cmd = new MySqlCommand(Query, conn))
                {
                    cmd = new MySqlCommand(Query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@fname", f_name);
                    cmd.Parameters.AddWithValue("@lname", l_name);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@sin", sin);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Employee  not found or no changes made.");
                    }
                }

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
        public DataTable showAllCar()
        {
            try
            {
                DataTable dataTable = new DataTable();
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

        public DataTable showAllAvailableCar()
        {
            try
            {
                DataTable dataTable = new DataTable();
                establishConnection();
                conn.Open();
                string Query = "select * from car where availability = 1";
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

                string Query = "insert into car (model,availability, year, color, " +
                    "license_plate, transmission_type, maintenance_history, " +
                    "insurance_details, price_per_day) Values (@model, @availability,@year, @color, @licenceplate, " +
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
        public void UpdateCar(int id, string model, int availability, int year, string color, string license_plate,
            string transmission_type, string maintenance_history, string insurance_details, double price_per_day)
        {
            try
            {
                establishConnection();
                conn.Open();

                string Query = "Update car set model=@model, availability=@availability,year=@year, " +
                    "color=@color, license_plate=@licenceplate, " +
                    "transmission_type=@transmissiontype, maintenance_history=@maintenancehistory, " +
                    "insurance_details=@insurancedetails, price_per_day=@priceperday where car_id=@ID";
                cmd = new MySqlCommand(Query, conn);

                cmd.Parameters.AddWithValue("@ID", id);
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
        public double SelectCar(int id)
        {

            try
            {
                double carData = 0;
                establishConnection();
                conn.Open();

                string selectQuery = "SELECT * from car where car_id=@ID";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            carData = (double) reader.GetDecimal("price_per_day");
                            
                        }
                    }
                }
                return carData;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally { conn.Close(); }
        }
        public DataTable showAllCustomer()
        {


            try
            {
                DataTable dataTable = new DataTable();
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


                string Query = "insert into customer  (f_name, l_name, phone_number, email, driving_license,dl_expiry_date ) Values (@fname, @lname,@phonenumber, @email, @drivinglicense, @dlexpirydate )";
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
        public void UpdateCustomer(int id, string f_name, string l_name, string phone_number, string email,
            string driving_license, DateTime dl_expiry_date)
        {
            try
            {
                establishConnection();
                conn.Open();

                string Query = "UPDATE customer SET f_name=@fname, l_name=@lname,phone_number=@phonenumber, email=@email, " +
                    "driving_license=@drivinglicense, dl_expiry_date=@dlexpirydate where cu_id=@ID";
                cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@ID", id);
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

        // Belal
        public void delete(int id,string tableId, string tableName)
        {
            try
            {
                establishConnection();
                conn.Open();
                string deleteQuery = $"DELETE FROM {tableName} WHERE {tableId} = @RowId";

                using (cmd = new MySqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@RowId", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Row with ID {id} deleted successfully from {tableName}.");
                    }
                    else
                    {
                        MessageBox.Show($"Row with ID {id} not found in {tableName}.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

        public DataTable ShowAllBills()
        {
            try
            {
                DataTable dataTable = new DataTable();
                establishConnection();
                conn.Open();

                string selectQuery = "SELECT bill_id, payment_method, amount, payment_date, r_id, created_at FROM bill";
                using (cmd = new MySqlCommand(selectQuery, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                return dataTable;


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { conn.Close(); }
        }

        public void UpdateBill(int billId, string paymentMethod, double amount, DateTime paymentDate, int rId)
        {
            try
            {
                establishConnection();
                conn.Open();

                string updateQuery = "UPDATE bill SET payment_method = @PaymentMethod, amount = @Amount, payment_date = @PaymentDate, r_id = @RId WHERE bill_id = @BillId";
                using (cmd = new MySqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@PaymentDate", paymentDate);
                    cmd.Parameters.AddWithValue("@RId", rId);
                    cmd.Parameters.AddWithValue("@BillId", billId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Bill with ID {billId} updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show($"Bill with ID {billId} not found or no changes made.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

        public void InsertBill(string paymentMethod, double amount, DateTime paymentDate, int rId)
        {
            try
            {
                establishConnection();
                conn.Open();

                string insertQuery = "INSERT INTO bill (payment_method, amount, payment_date, r_id) VALUES (@PaymentMethod, @Amount, @PaymentDate, @RId)";
                using (cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@PaymentDate", paymentDate);
                    cmd.Parameters.AddWithValue("@RId", rId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Bill inserted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Bill insertion failed.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

        public object[] GetBillById(int billId)
        {
            try
            {
                object[] billData = null;

                establishConnection();
                conn.Open();

                string selectQuery = "SELECT bill_id, payment_method, amount, payment_date, r_id, created_at FROM bill WHERE bill_id = @BillId";

                using (cmd = new MySqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BillId", billId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            billData = new object[]
                            {
                    reader.GetInt32("bill_id"),
                    reader.GetString("payment_method"),
                    reader.GetDecimal("amount"),
                    reader.GetDateTime("payment_date"),
                    reader.GetInt32("r_id"),
                    reader.GetDateTime("created_at")
                            };
                        }
                    }
                }
                return billData;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { conn.Close(); }
        }

        public DataTable ShowAllRentals()
        {
            try
            {
                DataTable dataTable = new DataTable();
                establishConnection();
                conn.Open();

                string selectQuery = "SELECT r_id, check_in, check_out, car_id, cu_id, em_id, created_at FROM rental";
                using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                return dataTable;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { conn.Close(); }
        }

        public void UpdateRental(int rentalId, DateTime checkIn, DateTime checkOut, int carId, int cuId, int emId)
        {
            try
            {
                establishConnection();
                conn.Open();
                string updateQuery = "UPDATE rental SET check_in = @CheckIn, check_out = @CheckOut, car_id = @CarId, cu_id = @CuId, em_id = @EmId WHERE r_id = @RentalId";

                using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CheckIn", checkIn);
                    cmd.Parameters.AddWithValue("@CheckOut", checkOut);
                    cmd.Parameters.AddWithValue("@CarId", carId);
                    cmd.Parameters.AddWithValue("@CuId", cuId);
                    cmd.Parameters.AddWithValue("@EmId", emId);
                    cmd.Parameters.AddWithValue("@RentalId", rentalId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Rental with ID {rentalId} updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show($"Rental with ID {rentalId} not found or no changes made.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

        public void InsertRental(DateTime checkIn, DateTime checkOut, int carId, int cuId, int emId)
        {
            try
            {
                establishConnection();
                conn.Open();

                string insertQuery = "INSERT INTO rental (check_in, check_out, car_id, cu_id, em_id) VALUES (@CheckIn, @CheckOut, @CarId, @CuId, @EmId)";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CheckIn", checkIn);
                    cmd.Parameters.AddWithValue("@CheckOut", checkOut);
                    cmd.Parameters.AddWithValue("@CarId", carId);
                    cmd.Parameters.AddWithValue("@CuId", cuId);
                    cmd.Parameters.AddWithValue("@EmId", emId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Rental inserted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Rental insertion failed.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
        }

        public object[] GetRentalById(int rentalId)
        {
            try
            {
                object[] rentalData = null;
                establishConnection();
                conn.Open();

                string selectQuery = "SELECT r_id, check_in, check_out, car_id, cu_id, em_id, created_at FROM rental WHERE r_id = @RentalId";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@RentalId", rentalId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rentalData = new object[]
                            {
                    reader.GetInt32("r_id"),
                    reader.GetDateTime("check_in"),
                    reader.GetDateTime("check_out"),
                    reader.GetInt32("car_id"),
                    reader.GetInt32("cu_id"),
                    reader.GetInt32("em_id"),
                    reader.GetDateTime("created_at")
                            };
                        }
                    }
                }
                return rentalData;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { conn.Close(); }
        }
        public bool login_c(string username, string password)
        {
            bool isCredentialsValid = false;
            try
            {
                establishConnection();
                conn.Open();

                string query = "SELECT * FROM Login WHERE user_name = @username";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPasswordHash = reader["password"].ToString();
                        if (password == storedPasswordHash)
                        {
                            isCredentialsValid = true;
                            App.UserID = Convert.ToInt32(reader["l_id"]);
                        }
                        else
                        {
                            MessageBox.Show("Invalid password.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("User not found.");
                    }
                }
                return isCredentialsValid;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return isCredentialsValid;
            }
            finally { conn.Close(); }
        }

        public void UpdateLogin(int loginId, string newUsername, string newPassword)
        {
            try
            {

                establishConnection();
                conn.Open();

                string query = "UPDATE Login SET user_name = @user_name, password = @password WHERE l_id = @l_id";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@l_id", loginId);
                cmd.Parameters.AddWithValue("@user_name", newUsername);
                cmd.Parameters.AddWithValue("@password", newPassword);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Your credentials updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update your credentials, please try again!");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }

        }
        public object[] SelectLoginById(int loginId)
        {
            try
            {
                object[] userData = null;
                establishConnection();
                conn.Open();

                string query = "SELECT user_name, password FROM Login WHERE l_id = @l_id";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@l_id", loginId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userData = new object[]
                            {
                    reader.GetString("user_name"),
                    reader.GetString("password"),
                            };
                    }
                }

                return userData;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { conn.Close(); }
        }


    }
}
