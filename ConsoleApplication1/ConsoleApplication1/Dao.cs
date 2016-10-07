using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Dao
    {
        private static string con_str = "server=localhost;database=pz;uid=root;pwd=root;";
        private static readonly MySqlConnection con = new MySqlConnection(con_str);


        public static void open()
        {
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't connect!");
            }
        }
        public static List<Product> getProducts()
        {
            List<Product> products = new List<Product>();
            using (MySqlCommand command = con.CreateCommand())
            {
                command.CommandText = "SELECT *  FROM pz.goods";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product();
                        product.setId(int.Parse(reader["id"].ToString()));
                        product.setName(reader["name"].ToString());
                        product.setDetails(reader["details"].ToString());
                        product.setPotoUrl(reader["photo_url"].ToString());
                        product.setPrice(decimal.Parse(reader["price"].ToString()));
                        product.setNumber(int.Parse(reader["number"].ToString()));
                        products.Add(product);
                    }
                }
            }
            return products;
        }
        private static bool buyProduct(Product product)
        {
            bool result;
            if (product.getNumber() > 0)
            {
                product.setNumber(product.getNumber() - 1);
                using (MySqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "update goods set number = @number where id=@id";
                    command.Parameters.Add(new MySqlParameter("@number", product.getNumber()));
                    command.Parameters.Add(new MySqlParameter("@id", product.getId()));
                    command.ExecuteNonQuery();
                }
                result = true;
            }
            else
            {
                Console.WriteLine("Sory, no product");
                result = false;
            }
            return result;
        }
        public static bool buyProductById(int id)
        {
            Product product = selectProduct(id);
            return buyProduct(product);
        }
        private static Product selectProduct(int id)
        {
            Product product = new Product();
            using (MySqlCommand command = con.CreateCommand())
            {
                command.CommandText = "SELECT *  FROM pz.goods where goods.id = @Id";
                command.Parameters.Add(new MySqlParameter("@Id", id));
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product.setId(int.Parse(reader["id"].ToString()));
                        product.setName(reader["name"].ToString());
                        product.setDetails(reader["details"].ToString());
                        product.setPotoUrl(reader["photo_url"].ToString());
                        product.setPrice(decimal.Parse(reader["price"].ToString()));
                        product.setNumber(int.Parse(reader["number"].ToString()));
                    }
                }
            }
            return product;
        }
        public static void addFeedback(Feedback feedback)
        {
            using (MySqlCommand command = con.CreateCommand())
            {
                command.CommandText = "insert into feedback(user_id, goods_id, text) values(@idUser, @idGoods, @text)";
                command.Parameters.Add(new MySqlParameter("@idUser", feedback.getUser().getId()));
                command.Parameters.Add(new MySqlParameter("@idGoods", feedback.getGoods().getId()));
                command.Parameters.Add(new MySqlParameter("@text", feedback.getText()));
                command.ExecuteNonQuery();
            }
        }
        public static List<Feedback> getAllFeedbackByProduct(int productId)
        {
            List<Feedback> list = new List<Feedback>();
            using (MySqlCommand command = con.CreateCommand())
            {
                command.CommandText = "SELECT *  FROM pz.feedback inner join pz.user on user.id = feedback.user_id inner join goods on feedback.goods_id = goods.id where feedback.goods_id = @id";
                command.Parameters.Add(new MySqlParameter("@id", productId));
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var feedback = new Feedback();
                        feedback.setId(int.Parse(reader["id"].ToString()));
                        int t = int.Parse(reader["user_id"].ToString());
                        var user = new User();
                        using (MySqlCommand comm = con.CreateCommand())
                        {
                            comm.CommandText = "SELECT *  FROM pz.user where user.id = @id";
                            comm.Parameters.Add(new MySqlParameter("@id", t));
                            user.setId(int.Parse(reader["id"].ToString()));
                            user.setEmail(reader["email"].ToString());
                            user.setFirstName(reader["first_name"].ToString());
                            user.setLastName(reader["last_name"].ToString());
                            user.setPass(reader["password"].ToString());
                        }
                        feedback.setUser(user);
                        int tt = int.Parse(reader["goods_id"].ToString());
                        var prod = new Product();
                        using (MySqlCommand comm = con.CreateCommand())
                        {
                            comm.CommandText = "SELECT *  FROM pz.goods where goods.id = @id";
                            comm.Parameters.Add(new MySqlParameter("@id", tt));
                            prod.setId(int.Parse(reader["id"].ToString()));
                            prod.setName(reader["name"].ToString());
                            prod.setDetails(reader["details"].ToString());
                            prod.setPotoUrl(reader["photo_url"].ToString());
                            prod.setNumber(int.Parse(reader["number"].ToString()));
                        }
                        feedback.setGoods(prod);
                        feedback.setText(reader["text"].ToString());
                        list.Add(feedback);
                    }
                }
            }
            return list;
        }
    }
}

