using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_machine_5.Models
{
   
        public class Toy : Product
        {
            public string Material { get; set; }

            public Toy(int id, string name, int cost, string material) : base(id, name, cost)
            {
                Material = material;
            }

            public override string Examine()
            {
                return $"Id: {Id}, Name: {Name}, Cost: {Cost}, Material: {Material}";
            }

            public override string Use()
            {
                return $"You play with the {Name}. It's made of {Material}.";
            }
        }
    }

