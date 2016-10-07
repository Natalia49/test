using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dao.open();
            char operation = 'L';
            while (operation != 'Q')
            {
                Console.WriteLine("Enter l - list of products; a - add feedback g - get feedback by product id, b - buy the product Q - quit.");
                operation = char.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 'l': getAllProducts(); break;
                    case 'a': addFeedback(); break;
                    case 'g': getAllFeedbackByProduct(); break;
                    case 'b': buyProduct();break;
                    default: Console.WriteLine("Inpout incorrect!"); break;
                }
            }
            Console.ReadKey();
        }
        private static void getAllProducts()
        {
            List<Product> result = Dao.getProducts();
            foreach (Product p in result)
            {
                Console.WriteLine(p.ToString());
            }
        }
        private static void addFeedback()
        {
            Console.WriteLine("Enter id of product");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Type your feedback");
            string text = Console.ReadLine();
            Dao.addFeedback(new Feedback(new User().setId(1), new Product().setId(id), text));
            Console.WriteLine("Added");
        }
        private static void getAllFeedbackByProduct()
        {
            Console.WriteLine("Enter id of product");
            int id = int.Parse(Console.ReadLine());
            List<Feedback> list = Dao.getAllFeedbackByProduct(id);
            foreach (Feedback f in list)
            {
                Console.WriteLine(f.ToString());
            }
        }
        private static void buyProduct()
        {
            Console.WriteLine("Enter id of product which you whant to buy");
            int id = int.Parse(Console.ReadLine());
            if (Dao.buyProductById(id))
            {
                Console.WriteLine("Congratulations, you bought it");
            }
        }
    }
}
