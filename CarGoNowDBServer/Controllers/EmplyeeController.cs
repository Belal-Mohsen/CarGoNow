using CarGoNowDBServer.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;
using Application = CarGoNowDBServer.Models.Application;

namespace CarGoNowDBServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmplyeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EmplyeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public Response GetAllEmployees()
        {
            string connectionString = _configuration.GetConnectionString("employeeConnection").ToString();
            MySqlConnection connection = new MySqlConnection(connectionString);
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetAllEmployees(connection);
            return response;
        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]

        public Response GetemployeeById(int id)
        {
            string connectionString = _configuration.GetConnectionString("employeeConnection").ToString();
            MySqlConnection connection = new MySqlConnection(connectionString);
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetEmployeeById(connection, id);
            return response;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public Response AddEmployee(Employee employee)
        {
            string connectionString = _configuration.GetConnectionString("employeeConnection").ToString();
            MySqlConnection connection = new MySqlConnection(connectionString);
            Response response = new Response();
            Application apl = new Application();
            response = apl.AddEmployee(connection, employee);
            return response;
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public Response UpdateEmployee(Employee employee)
        {
            string connectionString = _configuration.GetConnectionString("employeeConnection").ToString();
            MySqlConnection connection = new MySqlConnection(connectionString);
            Response response = new Response();
            Application apl = new Application();
            response = apl.UpdateEmployee(connection, employee);
            return response;
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public Response DeleteEmployee(int id)
        {
            string connectionString = _configuration.GetConnectionString("employeeConnection").ToString();
            MySqlConnection connection = new MySqlConnection(connectionString);
            Response response = new Response();
            Application apl = new Application();
            response = apl.DeleteEmployee(connection, id);
            return response;
        }

    }
}
