using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_machine_5.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Vending_machine_5
    {
        
        public class VendingMachineService : IVending
        {
            private static readonly int[] denominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
            private List<Product> products = new List<Product>();
            private int moneyPool = 0;
            public int BankBalance { get; private set; }

            public VendingMachineService()
            {
                // PRODUKTER
                products.Add(new Drink { Id = 1, Name = "Fanta", Cost = 15, Volume = 330 });
                products.Add(new Snack { Id = 2, Name = "Daim", Cost = 20, Calories = 300 });
                products.Add(new Toy { Id = 3, Name = "Superman Leksak", Cost = 50, Material = "Plast" });

                // BANKSALDO RANDOM MELLAN 100-1000 varje gång man kör programmet så är det olika saldon
                Random rand = new Random();
                BankBalance = rand.Next(100, 1001);
            }

            public void InsertMoney(int amount)
            {
                if (!denominations.Contains(amount))
                {
                    throw new ArgumentException("Ogiltig valör!");
                }
                if (amount > BankBalance)
                {
                    throw new InvalidOperationException("Det saknas pengar i banksaldot");
                }
                BankBalance -= amount;
                moneyPool += amount;
            }

            public Product Purchase(int productId)
            {
                Product product = products.FirstOrDefault(p => p.Id == productId);
                if (product == null)
                {
                    throw new ArgumentException("Produkt ej tillgänglig!");
                }
                if (moneyPool < product.Cost)
                {
                    throw new InvalidOperationException("Inte tillräckligt med pengar!");
                }
                moneyPool -= product.Cost;
                return product;
            }

            public List<string> ShowAll()
            {
                return products.Select(p => $"{p.Id}. {p.Name}, Kostnad: {p.Cost}kr").ToList();
            }

            public string Details(int productId)
            {
                Product product = products.FirstOrDefault(p => p.Id == productId);
                if (product == null)
                {
                    throw new ArgumentException("Produkt ej tillgänglig!");
                }
                return product.Examine();
            }

            public Dictionary<int, int> EndTransaction()
            {
                Dictionary<int, int> change = new Dictionary<int, int>();
                int remainingAmount = moneyPool;
                for (int i = denominations.Length - 1; i >= 0; i--)
                {
                    int coinValue = denominations[i];
                    if (remainingAmount >= coinValue)
                    {
                        int numCoins = remainingAmount / coinValue;
                        change[coinValue] = numCoins;
                        remainingAmount -= coinValue * numCoins;
                    }
                }
                // Återställ moneyPool efter transaktionen
                moneyPool = 0;
                return change;
            }

            public void DisplayStatus()
            {
                Console.WriteLine($"Nuvarande pengapool: {moneyPool}kr");
                Console.WriteLine($"Banksaldo: {BankBalance}kr");
            }
        }

    }

}
