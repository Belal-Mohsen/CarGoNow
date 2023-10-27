using Npgsql;
using System.Data;

namespace Assignment2_Server.Models
{
    public class Application
    {
       public Response GetAllProducts(NpgsqlConnection con)
        {
            string Query = "select * from products";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            List<Product> listOfProducts = new List<Product>();
            if(dt.Rows.Count > 0)
            {
                for(int i =0; i < dt.Rows.Count; i++)
                {
                    Product product = new Product();
                    product.Id = (int)dt.Rows[i]["pro_id"];
                    product.Name = (string)dt.Rows[i]["pro_name"];
                    product.Amount = (int)dt.Rows[i]["pro_amount"];
                    product.Price = (double)dt.Rows[i]["pro_price"];

                    listOfProducts.Add(product);

                }
            }
            if(listOfProducts.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successfully";
                response.products = listOfProducts;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No Data found";
                response.products = null;
            }
            return response;
        }

        public Response GetProductById(NpgsqlConnection con, int id)
        {
            string Query = "select * from products where pro_id='"+id+"'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                Product product = new Product();
                product.Id = (int)dt.Rows[0]["pro_id"];
                product.Name = (string)dt.Rows[0]["pro_name"];
                product.Amount = (int)dt.Rows[0]["pro_amount"];
                product.Price = (double)dt.Rows[0]["pro_price"];

                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successfully";
                response.product = product;

            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No Data found";
                response.product = null;
            }
            return response;
        }

        public Response AddProduct(NpgsqlConnection con, Product product)
        {
            Response response = new Response();
            con.Open();
            string Query = "insert into products values(default, @pro_name, @pro_amount, @pro_price)";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@pro_name", product.Name);
            cmd.Parameters.AddWithValue("@pro_amount", product.Amount);
            cmd.Parameters.AddWithValue("@pro_price", product.Price);
           

            int i = cmd.ExecuteNonQuery();
            if(i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data inserted successfully";
                response.product = product;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "Data insertion faild";
                response.product = null;
            }
            con.Close();
            return response;

        }

        public Response UpdateProduct(NpgsqlConnection con, Product product)
        {
            Response response = new Response();
            string Query = "update products set pro_name=@pro_name, pro_amount=@pro_amount, pro_price=@pro_price where pro_id=@ID";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@ID", product.Id);
            cmd.Parameters.AddWithValue("@pro_name", product.Name);
            cmd.Parameters.AddWithValue("@pro_amount", product.Amount);
            cmd.Parameters.AddWithValue("@pro_price", product.Price);
            con.Open();

            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data Updated successfully";
                response.product = product;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "Data update faild";
                response.product = null;
            }
            con.Close();
            return response;

        }
        public Response DeleteProduct(NpgsqlConnection con, int id)
        {
            Response response = new Response();
            string Query = "Delete from products where pro_id='"+id+"'";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            con.Open();

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
            con.Close();
            return response;

        }

    }
}
