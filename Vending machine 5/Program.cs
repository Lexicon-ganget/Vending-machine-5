using System;
using Vending_machine_5.Services;
using Vending_machine_5.Models;

namespace Vending_machine_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var vendingMachine = new VendingMachineService();

            // Insert money
            vendingMachine.InsertMoney(100);
            vendingMachine.InsertMoney(50);

            // Show all products
            Console.WriteLine("Available products:");
            foreach (var product in vendingMachine.ShowAll())
            {
                Console.WriteLine(product);
            }

            // Purchase a product
            Console.WriteLine("\nPurchasing product with Id 1:");
            var product1 = vendingMachine.Purchase(1);
            Console.WriteLine(product1.Use());

            // End transaction and get change
            Console.WriteLine("\nEnding transaction and getting change:");
            var change = vendingMachine.EndTransaction();
            Console.WriteLine("Change returned:");
            foreach (var coin in change)
            {
                Console.WriteLine($"{coin.Value} coins of {coin.Key}kr");
            }
        }
    }
}
