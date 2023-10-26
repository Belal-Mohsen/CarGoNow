using Assignment2_Server.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Assignment2_Server.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllProducts")]

        public Response GetAllProducts()
        {
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("productConnection").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetAllProducts(connection);
            return response;
        }

        [HttpGet]
        [Route("GetProductById/{id}")]

        public Response GetProductById(int id)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("productConnection").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetProductById(connection, id);
            return response;
        }

        [HttpPost]
        [Route("AddProduct")]
        public Response AddProduct(Product product)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("productConnection").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.AddProduct(connection, product);
            return response;
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public Response UpdateProduct(Product product)
        {
            Console.WriteLine(product.Name + product.Price + product.Amount);
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("productConnection").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.UpdateProduct(connection, product);
            return response;
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public Response DeleteProduct(int id)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("productConnection").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.DeleteProduct(connection, id);
            return response;
        }
    }
}
