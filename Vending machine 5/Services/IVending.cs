using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_machine_5.Services
{
    public interface IVending
    {
        void InsertMoney(int amount);
        Product Purchase(int productId);
        List<string> ShowAll();
        string Details(int productId);
        Dictionary<int, int> EndTransaction();
    }
}
