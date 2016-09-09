﻿using System;
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
            Int32 _basePages = default(Int32);
            Int32 _pageNumber = default(Int32);
            Boolean _lastPage = false;
            if (this.PurchaseBase.Count % 2 != 0)
            {
                _basePages = this.PurchaseBase.Count / 2 + 1;
                _lastPage = true;
            }
            else
            {
                _basePages = this.PurchaseBase.Count / 2;
            }
            Console.Clear();
            while (true)
            {
                Boolean _correct = false;
                Console.Clear();
                Console.WriteLine("Enter page number from 1 to {0} or x to return to main menu", _basePages);
                String _input = Console.ReadLine();
                if (_input == "x")
                {
                    break;
                }
                else
                {
                    while (!_correct)
                    {
                        while (Int32.TryParse(_input, out _pageNumber) == false)
                        {
                            Console.WriteLine("Not correct Symbols...");
                        }
                        if (_pageNumber < 1 || _pageNumber > _basePages)
                        {
                            Console.WriteLine("Not correct page number...");
                        }
                        else
                        {
                            _correct = true;
                        }
                    }
                    Console.WriteLine("Products on page {0}", _pageNumber);
                    if (_lastPage && _pageNumber == _basePages)
                    {
                        Console.WriteLine("Id: {0}, Name: {1}, Price: {2}, Discount: {3} %",
                                          this.PurchaseBase[_basePages * 2 - 2].Id,
                                          this.PurchaseBase[_basePages * 2 - 2].Name,
                                          this.PurchaseBase[_basePages * 2 - 2].Price,
                                          this.PurchaseBase[_basePages * 2 - 2].Discount
                                         );
                    }
                    else
                    {
                        Console.WriteLine("Id: {0}, Name: {1}, Price: {2}, Discount: {3} %",
                                          this.PurchaseBase[_pageNumber * 2 - 2].Id,
                                          this.PurchaseBase[_pageNumber * 2 - 2].Name,
                                          this.PurchaseBase[_pageNumber * 2 - 2].Price,
                                          this.PurchaseBase[_pageNumber * 2 - 2].Discount
                                         );
                        Console.WriteLine("Id: {0}, Name: {1}, Price: {2}, Discount: {3} %",
                                          this.PurchaseBase[_pageNumber * 2 - 1].Id,
                                          this.PurchaseBase[_pageNumber * 2 - 1].Name,
                                          this.PurchaseBase[_pageNumber * 2 - 1].Price,
                                          this.PurchaseBase[_pageNumber * 2 - 1].Discount
                                         );
                    }
                    Console.WriteLine("Press Enter to continue ....");
                    Console.ReadLine();
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