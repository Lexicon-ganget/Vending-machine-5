using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_machine_5.Models
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        protected Product(int id, string name, int cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }

        public abstract string Examine();
        public abstract string Use();
    }
}
