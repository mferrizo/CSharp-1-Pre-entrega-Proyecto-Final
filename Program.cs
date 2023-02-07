using CursoCoder.Controller;
using CursoCoder.Helper;
using CursoCoder.Models;

namespace Proyecto1
{
    internal class Program
    {
        static public SqlHandler sqlHandler = new SqlHandler();
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            Product product = new Product();
            List<User> users = new List<User>();
            User user = new User();

            List<Sale> sales = new List<Sale>();

            List<SoldProduct> productSales = new List<SoldProduct>();

            products = ProductController.GetProducts();
            Console.WriteLine(products[1].Description);
            product = ProductController.GetProduct(2);
            Console.WriteLine(product.Description);

            users = UserController.GetUsers();
            Console.WriteLine(users[1].Name);
            user = UserController.GetUser(1);
            Console.WriteLine(user.Name);

            sales = SaleController.GetSales("");
            sales = SaleController.GetSales("1");

            productSales = ProductSaleController.GetSales("2");

            string logIn = LoginController.LogIn("tcasazza", "123");
            Console.WriteLine(logIn);
            logIn = LoginController.LogIn("tcasazza", "SoyTobiasCasazza");
            Console.WriteLine(logIn);

            products = ProductController.GetProducts();

        }
    }
}