using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_5
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductRepository _firstShop = new ProductRepository();
            Product[] _firstShopProducts = _firstShop.FillByProducts();
            Purchase[] _firstPurchase = _firstShop.GeneratePurchase(_firstShopProducts);
            ProductRepository.HelloUser();
            ProductRepository.ShowPrices(_firstShopProducts);
            _firstShop.SelectProduct( ref _firstPurchase, ref _firstShopProducts);
        }
    }
    class Product
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
    }

    class Purchase
    {
        public UInt32 Qwantity { get; set; }
        public String Name { get; set; }
    }

    class ProductRepository
    {
        public Purchase[] GeneratePurchase(Product[] _argArray)
        {
            Purchase[] _purchaseArray = new Purchase[5];
            for (int i = 0; i < _purchaseArray.Length; i++)
            {
                var _tempPurchase = new Purchase
                {
                    Qwantity = 0,
                    Name = _argArray[i].Name
                };
                _purchaseArray[i] = _tempPurchase;
            }
            return _purchaseArray;
        }
        public Product[] FillByProducts()
        {
            Product[] _productArray = new Product[5];
            for (int i = 0; i < _productArray.Length; i++)
            {
                var _tempProduct = new Product
                {
                    Id = i + 1
                };
                _productArray[i] = _tempProduct;
            }
            _productArray[0].Name = "Apple".PadRight(8);
            _productArray[0].Price = 33.30M;
            _productArray[1].Name = "Banana".PadRight(8);
            _productArray[1].Price = 56.80M;
            _productArray[2].Name = "Coffee".PadRight(8);
            _productArray[2].Price = 86.25M;
            _productArray[3].Name = "Milk".PadRight(8);
            _productArray[3].Price = 15.65M;
            _productArray[4].Name = "Cola".PadRight(8);
            _productArray[4].Price = 18.75M;
            return _productArray;
        }
        public static void ShowPrices(Product[] _argArray)
        {
            Console.WriteLine("Choose what do you want to buy by pressing appropriate number:\r\n");
            Console.WriteLine(" Id  Name     Price");
            Console.WriteLine("----------------------");
            for (int i = 0; i < _argArray.Length; i++)
            {
                Console.WriteLine("{0,2}:  {1:8} $ {2,4}",_argArray[i].Id,_argArray[i].Name,_argArray[i].Price );
            }
            Console.WriteLine(" 6:  Finish");
            Console.WriteLine("----------------------");
        }
        public static Decimal ShowPurchase(Purchase[] _argArray1, Product[] _argArray2)
        {
            String _stringYesNo = default(String);
            Boolean _flagCorrect = false;
            Boolean _flagCorrectDiscount = false;
            Decimal _decDiscount = default(Decimal);
            Decimal _decTotal = default(Decimal);
            Console.Write("Do you have discount? (yes/no): ");
            while (!_flagCorrect)
            {
                _stringYesNo = Console.ReadLine();
                if((_stringYesNo != "yes") && (_stringYesNo != "no"))
                {
                    Console.Write("Write \"yes\" or \"no\": ");
                }
                else
                {
                    _flagCorrect = true;
                }

            }
            switch (_stringYesNo)
            {
                case "yes":
                    Console.Write("Enter a value of discount (in persentage): ");
                    while(!_flagCorrectDiscount)
                    {
                        while (Decimal.TryParse(Console.ReadLine(), out _decDiscount) == false)
                        {
                            Console.Write("Not correct symbols in discount value...\r\nPlease enter correct!.. : ");
                        }
                        if (_decDiscount<100 && _decDiscount>=1)
                        {
                            _decDiscount =_decDiscount / 100;
                            _flagCorrectDiscount = true;
                        }
                        else
                        {
                            Console.Write("Please enter correct discount (from 100 to 1 %): ");
                        }
                    }
                    break;
                case "no":
                    _decDiscount = 1;
                    break;
            }
            Console.WriteLine("\r\n-----------Check------------");
                for (int i = 0; i < _argArray1.Length; i++)
                {
                    if (_argArray1[i].Qwantity > 0)
                    {
                        _decTotal += _argArray1[i].Qwantity * _argArray2[i].Price;
                        Console.WriteLine("{0,8} x  {1,3} = $ {2,4}", _argArray1[i].Name, _argArray1[i].Qwantity, _argArray1[i].Qwantity * _argArray2[i].Price);
                    }
                }
                Console.WriteLine("----------------------------");
            if(_decDiscount==1)
            {
                Console.WriteLine("Total  payment: {0:0.00}\r\n", _decTotal * _decDiscount);
            }
            else
            {
                Console.WriteLine("Total discount: {0:0.00}", _decTotal * _decDiscount);
                Console.WriteLine("Total payment: {0:0.00}\r\n", _decTotal - (_decDiscount * _decTotal));
            }
            return _decTotal;
        }
        public static void HelloUser()
        {
            Console.Write("Enter your name: ");
            String _stringArg = Console.ReadLine();
            Console.WriteLine("Hello, {0}!",_stringArg);
        }
        private UInt32 ReadValue()
        {
            UInt32 _uintVal;
            Console.Write("Enter qwantity of selected Product: ");
            while (UInt32.TryParse(Console.ReadLine(), out _uintVal) == false)
            {
                Console.Write("Not correct value...Please enter correct!..: ");
            }
            return _uintVal;
        }
        public void SelectProduct(ref Purchase[] _argArray1, ref Product[] _argArray2)
        {
            Boolean _flagExit = false;
            while(!_flagExit)
            {
                Console.Write("Select Id: ");
                String _charSelect = Console.ReadLine();
                switch (_charSelect)
                {
                    case "1":
                        _argArray1[0].Qwantity += ReadValue();
                        break;
                    case "2":
                        _argArray1[1].Qwantity += ReadValue();
                        break;
                    case "3":
                        _argArray1[2].Qwantity += ReadValue();
                        break;
                    case "4":
                        _argArray1[3].Qwantity += ReadValue();
                        break;
                    case "5":
                        _argArray1[4].Qwantity += ReadValue();
                        break;
                    case "6":
                        ShowPurchase(_argArray1, _argArray2);
                        _flagExit = true;
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("Error: Not valid id!!! Try again\r\n");
                        break;
                }
            }
        }
    }
}
