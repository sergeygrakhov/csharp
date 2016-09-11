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
            "new Tv Sony",
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
            "new Book CLR via C#",
            "Windows 10"
        };
        private Decimal[] _arrayOfPrices = new Decimal[] { 1500, 300, 60, 32, 20, 70, 50, 400, 500, 450, 130, 500, 134 };
        private Int32[] _arayOfQwantity = new Int32[] { 5, 12, 4, 6, 11, 18, 1, 7, 22, 5, 5, 8, 2 };
        private Decimal[] _arrayOfDiscount = new Decimal[] { 10, 20, 40, 33, 0, 15, 5, 10, 30, 50, 30, 12, 0 };
        public void CreatePurchaseBase()
        {
            this.PurchaseBase = new List<Product>();
            for (int i = 0; i < this._arrayOfName.Length; i++)
            {
                Product _temp = new Product();
                _temp.Id = i + 1;
                _temp.Name = _arrayOfName[i];
                _temp.Price = _arrayOfPrices[i];
                _temp.Qwantity = _arayOfQwantity[i];
                _temp.Discount = _arrayOfDiscount[i];
                _temp.PurchaseSum = _temp.Price * _temp.Qwantity - _temp.Price * _temp.Qwantity * _temp.Discount / 100;
                this.PurchaseBase.Add(_temp);
            }
        }
        public void FirstTaskMethod()
        {
            Console.Clear();
            var _query = from _var in this.PurchaseBase
                         where (_var.Discount > 0 && _var.Price <= 1000 && _var.Qwantity > 2 && _var.Name.ToLower().Contains("new"))
                         select new
                         {
                             ID = _var.Id,
                             Summ = _var.PurchaseSum
                         };
            Console.WriteLine("Query result: ");
            foreach (var element in _query)
            {
                {
                    Console.WriteLine("ID: {0}, Summ: {1}", element.ID, element.Summ);
                }
            }
            Console.WriteLine("Press Enter to continue ....");
            Console.ReadLine();
        }
        public void SecondTaskMethod()
        {
            Int32 _basePages = this.PurchaseBase.Count % 2 != 0 ? this.PurchaseBase.Count / 2 + 1 : this.PurchaseBase.Count / 2;
            Int32 _pageNumber = default(Int32);
            Boolean _flagMainMenu = false;
            Console.Clear();
            while (!_flagMainMenu)
            {
                Boolean _correct = false;
                while (!_correct)
                {
                    Console.Clear();
                    Console.WriteLine("Enter page number from 1 to {0}", _basePages);
                    while (Int32.TryParse(Console.ReadLine(), out _pageNumber) == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Not correct Symbols...");
                        Console.WriteLine("Enter page number from 1 to {0}", _basePages);
                    }
                    if (_pageNumber < 1 || _pageNumber > _basePages)
                    {
                        Console.WriteLine("Not correct page number...");
                        Console.WriteLine("Press Enter to continue ....");
                        Console.ReadLine();
                    }
                    else
                    {
                        _correct = true;
                    }
                }
                Console.WriteLine("Products on page {0}", _pageNumber);
                var _query = from _var in this.PurchaseBase
                             where (_var.Id > _pageNumber * 2 - 2) && (_var.Id <= _pageNumber * 2)
                             select _var;
                foreach (var element in _query)
                {
                    Console.WriteLine("Id: {0}, Name: {1}, Price: {2}, Discount: {3} %",
                                      element.Id,
                                      element.Name,
                                      element.Price,
                                      element.Discount
                                     );
                }
                Console.WriteLine("Press Enter to continue .... or x to exit to main menu");
                String _select = Console.ReadLine();
                if (_select == "x")
                {
                    _flagMainMenu = true;
                }
            }
        }
        public void ThirdTaskMethod()
        {
            Console.Clear();
            Console.WriteLine("Enter words to search in Products : ");
            String _userinput = Console.ReadLine().ToLower();
            var _query = from _var in this.PurchaseBase
                         where _var.Name.ToLower().Split(' ').Any(word => _userinput.Split(' ').Contains(word))
                         select _var;
            if (_query.Count() != 0)
            {
                Console.WriteLine("Search results: ");
                foreach (var element in _query)
                {
                    {
                        Console.WriteLine("ID: {0}, Product name: {1}, Price: {2}", element.Id, element.Name, element.Price);
                    }
                }
                Console.WriteLine("Press Enter to continue ....");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No matches found...");
                Console.WriteLine("Press Enter to continue ....");
                Console.ReadLine();
            }

        }
        public void Start()
        {
            Boolean _flagExit = false;
            while (!_flagExit)
            {
                Console.Clear();
                Console.WriteLine("Select id of operation that you want to execute and press Enter");
                Console.WriteLine("1: Get product list that have discount,prise not bigger than 1000, sell qwantity more than 2 and product name contains word (new) ");
                Console.WriteLine("2: Pagination task ");
                Console.WriteLine("3: Search product name containing one of word entered by user");
                Console.WriteLine("To exit press x and hit Enter");
                Console.Write("Your input: ");
                String _charSelect = Console.ReadLine();
                switch (_charSelect)
                {
                    case "1":
                        FirstTaskMethod();
                        break;
                    case "2":
                        SecondTaskMethod();
                        break;
                    case "3":
                        ThirdTaskMethod();
                        break;
                    case "x":
                        _flagExit = true;
                        break;
                    default:
                        Console.WriteLine("Not correct id. Press Enter to try again");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}