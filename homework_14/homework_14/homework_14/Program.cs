using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_14
{
    namespace homework_14
    {
        class Program
        {
            static void Main(string[] args)
            {
                ProductRepository _purchases = new ProductRepository();
                _purchases.CreatePurchaseBase();
                _purchases.Start();
            }
        }
    }
}



