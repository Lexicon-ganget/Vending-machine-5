using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending_machine_5.Models;

namespace Vending_machine_5.Services
{

    public class VendingMachineService : IVending
    {
        private List<Product> _products = new List<Product>();
        private int _moneyPool = 0;

        public VendingMachineService()
        {
            // Initialize with some products
            _products.Add(new Drink(1, "Cola", 15, "Cola"));
            _products.Add(new Snack(2, "Chips", 10, 200));
            _products.Add(new Toy(3, "Action Figure", 50, "Plastic"));
        }

        public void InsertMoney(int amount)
        {
            if (Denominations.ValidDenominations.Contains(amount))
            {
                _moneyPool += amount;
            }
            else
            {
                throw new ArgumentException("Invalid denomination");
            }
        }

        public Product Purchase(int productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }

            if (_moneyPool >= product.Cost)
            {
                _moneyPool -= product.Cost;
                return product;
            }
            else
            {
                throw new InvalidOperationException("Not enough money");
            }
        }

        public List<string> ShowAll()
        {
            return _products.Select(p => $"Id: {p.Id}, Name: {p.Name}, Cost: {p.Cost}").ToList();
        }

        public string Details(int productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }

            return product.Examine();
        }

        public Dictionary<int, int> EndTransaction()
        {
            var change = new Dictionary<int, int>();
            foreach (var denomination in Denominations.ValidDenominations.OrderByDescending(d => d))
            {
                if (_moneyPool >= denomination)
                {
                    change[denomination] = _moneyPool / denomination;
                    _moneyPool %= denomination;
                }
            }

            return change;
        }
    }
}

