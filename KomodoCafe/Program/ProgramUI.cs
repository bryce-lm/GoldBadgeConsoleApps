using CafeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class UI
    {
        private Repository _orderRepo = new Repository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine
                    (
                    "Hello, welcome to Komodo cafe.\n" +
                    "------------------------------\n" +
                    "     1. List all orders       \n" +
                    "       2. Add an order        \n" +
                    "     3. Remove an order       \n"
                    );

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        List();
                        break;
                    case "2":
                        CreateOrder();
                        break;
                    case "3":
                        RemoveOrderFromList();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                }
            }
        }

        public void List()
        {
            List<Menu> ItemList = _orderRepo.ListOrders();

            foreach (Menu content in ItemList)
            {
                Console.WriteLine($"#{content.ItemNumber} {content.Name}\n" +
                    $"Description: {content.Description}\n" +
                    $"Ingredients: {content.Ingredients}\n" +
                    $"Price: {content.Price}\n");
            }

            Console.WriteLine("Press any key followed by enter to continue please.");
            Console.ReadKey();

            Console.ReadLine();
        }

        public void CreateOrder()
        {
            Menu content = new Menu();

            Console.Clear();
            Console.WriteLine("(ID) (Name) (Description) (Ingrediants) (Price)\n");

            Console.WriteLine("Enter the new item's item number: ");
            content.ItemNumber = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) (Name) (Description) (Ingrediants)\n");

            Console.WriteLine("Enter the item's name: ");
            content.Name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) ({content.Name}) (Description) (Ingrediants)\n");

            Console.WriteLine($"Enter a description for {content.Name}: ");
            content.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ItemNumber}) ({content.Name}) ({content.Description}) (Ingrediants)\n");

            Console.WriteLine($"Enter the ingrediants for {content.Name}: ");
            content.Ingredients = Console.ReadLine();
            Console.Clear();

            Console.WriteLine($"Enter the price for {content.Name}.");
            content.Price = Console.ReadLine();
            Console.Clear();


            Console.WriteLine("Order Summary:\n");

            Console.WriteLine
                (
                $"Item Number: {content.ItemNumber}\n" +
                $"Name: {content.Name}\n" +
                $"Description: {content.Description}\n" +
                $"Ingrediants: {content.Ingredients}\n" +
                $"Price: {content.Price}\n"
                );

            Console.WriteLine("Press any key followed by enter to continue please.");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("The item was added, press any key followed by enter to continue please.");
            Console.ReadKey();

            _orderRepo.AddOrder(content);

        }

        public void RemoveOrderFromList()
        {
            Console.WriteLine("Please input what item you would like to delete.");

            List<Menu> ItemList = _orderRepo.ListOrders();

            foreach (Menu order in ItemList)
            {
                Console.WriteLine($"#{order.ItemNumber} - {order.Name}\n");
            }

            int numRemove = int.Parse(Console.ReadLine());

            Menu menuObject = _orderRepo.FindOrderByID(numRemove);

            _orderRepo.RemoveOrder(menuObject);

            Console.WriteLine("The order was deleted, press any key followed by enter to continue please.");
            Console.ReadKey();

        }
        public void SeedContent()
        {
            Menu hawaiianPizza = new Menu(1, "Hawaiian Pizza", "A twist on traditional pizza that provides a hint from the aloha state.", "12-inch pizza crusts, traditional pizza sauce, 3-cheese blend, ham, and pinapple.","Price: $12.00");
            Menu florentienGnocchi = new Menu(2, "Florentien Gnocchi", "An itialian inspired Gnocchi dish.", "2 buns, 1 chicken breast", "Price: $14.00");
            Menu spaghetti = new Menu(3, "Spaghetti", "A traditional itialian dish consiting of pasta and our house signature tomato sauce.", "Penne noodles and tomato sauce.", "Price: $8.00");

            _orderRepo.AddOrder(hawaiianPizza);
            _orderRepo.AddOrder(florentienGnocchi);
            _orderRepo.AddOrder(spaghetti);
        }
    }
}