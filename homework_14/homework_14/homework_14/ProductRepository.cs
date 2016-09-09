using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_14
{
    class ProductRepository
    {
        public List<Product> PurchaseBase { get; set; }
        private String[] _arrayOfName = new String[]
        {
            "new Tv",
            "New home theater",
            "New mac book",
            "Intel Core i7 new",
            "Microwawe oven",
            "Cisco router",
            "New iphone",
            "Dell alienware",
            "Table",
            "Keyboard",
            "Wall Clock",
            "new Book CLR via C#"
        };
        private Decimal[] _arrayOfPrices = new Decimal[] { 1500, 300, 60, 32, 20, 70, 50, 400, 500, 450, 130, 500 };
        private Int32[] _arayOfQwantity = new Int32[] { 5, 12, 4, 6, 11, 18, 1, 7, 22, 5, 5, 8 };
        private Decimal[] _arrayOdDiscount = new Decimal[] { 0.1M, 0.2M, 0.4M, 0.33M, 1, 0.15M, 0.05M, 0.01M, 0.03M, 0.5M, 0.3M, 0.12M };
        public  void CreatePurchaseBase()
        {
            this.PurchaseBase = new List<Product>();
            for (int i = 0; i < this._arrayOfName.Length; i++)
            {
                Product _temp = new Product();
                _temp.Id = i+1;
                _temp.Name = _arrayOfName[i];
                _temp.Price = _arrayOfPrices[i];
                _temp.Qwantity = _arayOfQwantity[i];
                _temp.Discount = _arrayOdDiscount[i];
                _temp.PurchaseSum = _temp.Price * _temp.Qwantity - _temp.Price * _temp.Qwantity * _temp.Discount;
                this.PurchaseBase.Add(_temp);
            }
        }
        public void FirstTaskMethod()
        {
            var _query = from _var in this.PurchaseBase
                              where (_var.Discount < 1 && _var.Price <= 1000 && _var.Qwantity > 2 && _var.Name.ToLower().Contains("new"))
                              select new
                              {
                                  ID = _var.Id,
                                  Summ = _var.PurchaseSum
                              };
            foreach (var element in _query)
            {
                {
                    Console.WriteLine(element.ID + "   " + element.Summ);
                }
            }
        }
        public void ThirdTaskMethod()
        {
            Console.WriteLine("Enter words to search in Products names: ");
            String _userinput = Console.ReadLine();
            String[] _words = _userinput.Split(' ');
            List<String> _wordList = new List<String>();
            foreach (var _item in _words)
            {
                _wordList.Add(_item);
            }
            var _query = from _var in this.PurchaseBase

                         where (_var.Name => Intersect(_wordList).Any() _var.Name.ToArray().Intersect(_words);
        }
    }       
}
