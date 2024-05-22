using System;
using Vending_machine_5.Services;
using Vending_machine_5.Models;

namespace Vending_machine_5
{
    internal class Program
    {
        private static VendingMachineService vendingMachine = new VendingMachineService();

        static void Main(string[] args)
        {
            // Menu
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = LoopMenu();
            }
        }

        static bool LoopMenu()
        {
            Console.Clear();
            Console.WriteLine("Vending Machine");
            Console.WriteLine("Enter the selection you want to:");
            Console.WriteLine();
            Console.WriteLine("Press 1 to show products");
            Console.WriteLine("Press 2 to insert money");
            Console.WriteLine("Press 3 to buy a product");
            Console.WriteLine("Press 4 to end transaction and get change");
            Console.WriteLine();
            Console.WriteLine("Press 9 to exit");
            Console.Write("\r\nSelect an option: ");

            // Keypress
            switch (Console.ReadLine())
            {
                case "1":
                    ShowProducts();
                    break;
                case "2":
                    InsertMoney();
                    break;
                case "3":
                    Purchase();
                    break;
                case "4":
                    EndTransmition();
                    break;
                case "9":
                    return false;
                default:
                    break;
            }
            return true;
        }

        static void ShowProducts()
        {
            // Show all products
            Console.Clear();
            Console.WriteLine("Available products:");
            foreach (var product in vendingMachine.ShowAll())
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void InsertMoney()
        {
            // Insert money
            Console.Clear();
            Console.WriteLine("Insert money (valid denominations: 1, 5, 10, 20, 50, 100, 500, 1000):");
            if (int.TryParse(Console.ReadLine(), out int amount))
            {
                try
                {
                    vendingMachine.InsertMoney(amount);
                    Console.WriteLine($"Money inserted: {amount}kr");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void Purchase()
        {
            // Purchase a product
            Console.Clear();
            Console.WriteLine("Enter the product Id you want to purchase:");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                try
                {
                    var product = vendingMachine.Purchase(productId);
                    Console.WriteLine($"Purchased: {product.Name}");
                    Console.WriteLine(product.Use());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void EndTransmition()
        {
            // End transaction and get change
            Console.Clear();
            var change = vendingMachine.EndTransaction();
            Console.WriteLine("Change returned:");
            foreach (var coin in change)
            {
                Console.WriteLine($"{coin.Value} coins of {coin.Key}kr");
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
    }
}

