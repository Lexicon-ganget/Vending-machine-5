using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Snack : Product
    {
        public int Calories { get; set; }

        public Snack(int id, string name, int cost, int calories) : base(id, name, cost)
        {
            Calories = calories;
        }

        public override string Examine()
        {
            return $"Id: {Id}, Name: {Name}, Cost: {Cost}, Calories: {Calories}";
        }

        public override string Use()
        {
            return $"You eat the {Name}. It has {Calories} calories.";
        }
    }
}


