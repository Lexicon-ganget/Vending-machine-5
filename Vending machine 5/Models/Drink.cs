using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_machine_5.Models
{
    
        public class Drink : Product
        {
            public string Flavor { get; set; }

            public Drink(int id, string name, int cost, string flavor) : base(id, name, cost)
            {
                Flavor = flavor;
            }

            public override string Examine()
            {
                return $"Id: {Id}, Name: {Name}, Cost: {Cost}, Flavor: {Flavor}";
            }

            public override string Use()
            {
                return $"You drink the {Name}. It's {Flavor} flavored.";
            }
        }
    }

