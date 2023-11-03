using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace CarGoNowDBServer.Models
{
    public class Application
    {
        public Response GetAllEmployees(MySqlConnection conn)
        {
            string Query = "select * from employee";
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlCommand cmd = new MySqlCommand(Query, conn);

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);
            Response response = new Response();
            List<Employee> employees = new List<Employee>();
            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i< dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["em_id"]);
                    employee.fName = (string)dt.Rows[i]["f_name"];
                    employee.lName = (string)dt.Rows[i]["l_name"];
                    employee.Role = (string)dt.Rows[i]["role"];
                    employee.Sin = (string)dt.Rows[i]["sin"];

                    employees.Add(employee);
                }    
            }
            if(employees.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successfully";
                response.employees = employees;

            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No Data found";
                response.employees = null;
            }
            conn.Close();
            return response;
        }

        public Response GetEmployeeById(MySqlConnection conn, int id)
        {
            string Query = "select * from employee where em_id='"+id+"'";
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlCommand cmd = new MySqlCommand(Query, conn);

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(dt.Rows[0]["em_id"]);
                employee.fName = (string)dt.Rows[0]["f_name"];
                employee.lName = (string)dt.Rows[0]["l_name"];
                employee.Role = (string)dt.Rows[0]["role"];
                employee.Sin = (string)dt.Rows[0]["sin"];

                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successfully";
                response.employee = employee;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No Data found";
                response.employees = null;
            }
            conn.Close();
            return response;
        }

        public Response AddEmployee(MySqlConnection con, Employee employee)
        {
            Response response = new Response();
            con.Open();
            string Query = "insert into employee(f_name, l_name, role, sin) Values(@fname, @lname, @role, @sin)";
            using (MySqlCommand cmd = new MySqlCommand(Query, con))
            {
                cmd.Parameters.AddWithValue("@ID", employee.Id);
                cmd.Parameters.AddWithValue("@fname", employee.fName);
                cmd.Parameters.AddWithValue("@lname", employee.lName);
                cmd.Parameters.AddWithValue("@role", employee.Role);
                cmd.Parameters.AddWithValue("@sin", employee.Sin);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    response.statusCode = 200;
                    response.statusMessage = "Data inserted successfully";
                    response.employee = employee;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMessage = "Data insertion faild";
                    response.employee = null;
                }
            }
            con.Close();
            return response;

        }

        public Response UpdateEmployee(MySqlConnection con, Employee employee)
        {
            Response response = new Response();
            con.Open();
            string Query = "Update employee set f_name=@fname, l_name=@lname, role=@role, sin=@sin where em_id=@ID";
            using (MySqlCommand cmd = new MySqlCommand(Query, con))
            {
                cmd.Parameters.AddWithValue("@ID", employee.Id);
                cmd.Parameters.AddWithValue("@fname", employee.fName);
                cmd.Parameters.AddWithValue("@lname", employee.lName);
                cmd.Parameters.AddWithValue("@role", employee.Role);
                cmd.Parameters.AddWithValue("@sin", employee.Sin);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    response.statusCode = 200;
                    response.statusMessage = "Data Updated successfully";
                    response.employee = employee;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMessage = "Data update faild";
                    response.employee = null;
                }
            }
            con.Close();
            return response;

        }

        public Response DeleteEmployee(MySqlConnection con, int id)
        {
            Response response = new Response();
            con.Open();
            string Query = "Delete from employee where em_id='" + id + "'";
            using (MySqlCommand cmd = new MySqlCommand(Query, con))
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    response.statusCode = 200;
                    response.statusMessage = "Data deleted successfully";
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMessage = "Data can't be deleted";
                }
            }
                

            
            con.Close();
            return response;
        }

    }
}
