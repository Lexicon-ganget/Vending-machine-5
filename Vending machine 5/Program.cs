namespace Vending_machine_5
{
    internal class Program
    {
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
            Console.WriteLine("Enter the selection you want to");
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
            var vendingMachine = new VendingMachineService();
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
            var vendingMachine = new VendingMachineService();
            vendingMachine.InsertMoney(100);
            vendingMachine.InsertMoney(50);
            Console.WriteLine("Money inserted.");
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void Purchase()
        {
            // Purchase a product
            var vendingMachine = new VendingMachineService();
            Console.WriteLine("\nPurchasing product with Id 1:");
            var product1 = vendingMachine.Purchase(1);
            Console.WriteLine(product1.Use());
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void EndTransmition()
        {
            // End transaction and get change
            var vendingMachine = new VendingMachineService();
            Console.WriteLine("\nEnding transaction and getting change:");
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
