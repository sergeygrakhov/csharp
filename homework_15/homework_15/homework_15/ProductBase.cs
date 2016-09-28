using System;
using System.Data.Entity;
using System.Linq;

namespace homework_15
{
    public class ProductBase : DbContext
    {
        public ProductBase() : base("ProductBaseHomework15") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sell> Purchases { get; set; }
        public static void AddProduct(ProductBase _baseArg)
        {
            Boolean _flagCorrect = false;
            Decimal _productPrice = default(Decimal);
            Console.Write("Enter product name:");
            String _ProductName = Console.ReadLine();
            Console.Write("Enter product price:");
            while (!_flagCorrect)
            {
                while (Decimal.TryParse(Console.ReadLine(), out _productPrice) == false)
                {
                    Console.Write("Not correct price value, please enter correct: ");
                }
                if (_productPrice <=0)
                {
                    Console.Write("Price of product must be greater then zero: ");
                }
                else
                {
                    _flagCorrect = true;
                }
            }
            _baseArg.Products.Add(new Product { ProductName = _ProductName, ProductPrice = _productPrice });
            _baseArg.SaveChanges();
            Console.WriteLine("Changes saved...Enter to continue...");
            Console.ReadLine();
        }
        public static void AddPurchase(ProductBase _baseArg)
        {
            Boolean _flagCorrect = false;
            Int32 _selectedId = default(Int32);
            Int32 _quantity = default(Int32);
            var _query = from item in _baseArg.Products.Include("SellProduct").ToList()
                         select item;
            if (_query.Count()<=0)
            {
                Console.WriteLine("There is no items in database, please, add first...Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Select product by ID to add sell or edit current ");
                Console.WriteLine(new String('-', 20));
                foreach (var product in _query)
                {
                    if (product.SellProduct != null)
                    {
                        Console.WriteLine("ID: {0}, ProductName: {1}  ProductPrice: {2} Purchase sum: {3}", product.Id, product.ProductName, product.ProductPrice, product.SellProduct.SellSum);
                    }
                    else
                    {
                        Console.WriteLine("ID: {0}, ProductName: {1}  ProductPrice: {2}", product.Id, product.ProductName, product.ProductPrice);
                    }
                }
                Console.WriteLine(new String('-', 20));
                while (!_flagCorrect)
                {
                    while (Int32.TryParse(Console.ReadLine(), out _selectedId) == false)
                    {
                        Console.Write("Not correct symbols in Id value, please enter correct: ");
                    }
                    if (_selectedId > _query.Count() || _selectedId < 0)
                    {
                        Console.Write("Not correct Id, please enter correct: ");
                    }
                    else
                    {
                        _flagCorrect = true;
                    }
                }
                _flagCorrect = false;
                var _selectedItem = _baseArg.Products.Find(_selectedId);
                Console.Write("Enter quantity of \"{0}\" to sell: ", _selectedItem.ProductName);
                while (!_flagCorrect)
                {
                    while (Int32.TryParse(Console.ReadLine(), out _quantity) == false)
                    {
                        Console.Write("Not correct quantity value, please enter correct: ");
                    }
                    if (_quantity <= 0)
                    {
                        Console.Write("Quantity value must be greater then zero:");
                    }
                    else
                    {
                        _flagCorrect = true;
                    }
                }
                _selectedItem.SellProduct = new Sell { Id = _selectedItem.Id, SellSum = _selectedItem.ProductPrice * _quantity };
                Console.WriteLine(new String('-', 20));
                Console.WriteLine("Sell sum of \"{0}\"  equals: {1} ", _selectedItem.ProductName, _selectedItem.SellProduct.SellSum);
                Console.WriteLine(new String('-', 20));
                _baseArg.SaveChanges();
                Console.WriteLine("Changes saved...Enter to continue...");
                Console.ReadLine();
            }
        }
        public static void ClearDataBase(ProductBase _baseArg)
        {
            foreach (var item in _baseArg.Products)
            {
                _baseArg.Products.Remove(item);
            }
            _baseArg.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Products', RESEED, 0)");
            Console.WriteLine("Database cleared...Enter to continue...");
            Console.ReadLine();
            _baseArg.SaveChanges();
        }
        public static void EditProductName(ProductBase _baseArg)
        {
            Boolean _flagCorrect = false;
            Int32 _selectedId = default(Int32);
            var _query = from item in _baseArg.Products.Include("SellProduct").ToList()
                         select item;
            if (_query.Count() <= 0)
            {
                Console.WriteLine("There is no items in database, please, add first...");
            }
            else
            {
                Console.WriteLine("Select product by ID to edit Name value");
                foreach (var product in _query)
                {
                        Console.WriteLine("ID: {0}, ProductName: {1} ", product.Id, product.ProductName);
                }
                while (!_flagCorrect)
                {
                    while (Int32.TryParse(Console.ReadLine(), out _selectedId) == false)
                    {
                        Console.Write("Not correct symbols in Id value, please enter correct: ");
                    }
                    if (_selectedId > _query.Count() || _selectedId < 0)
                    {
                        Console.Write("Not correct Id, please enter correct: ");
                    }
                    else
                    {
                        _flagCorrect = true;
                    }
                }
                _flagCorrect = false;
                var _selectedItem = _baseArg.Products.Find(_selectedId);
                Console.Write("Enter new Product name for \"{0}\": ", _selectedItem.ProductName);
                _selectedItem.ProductName = Console.ReadLine();
                _baseArg.SaveChanges();
                Console.WriteLine("Changes saved...Enter to continue...");
                Console.ReadLine();
            }
        }
        public static void EditProductPrice(ProductBase _baseArg)
        {
            Boolean _flagCorrect = false;
            Int32 _selectedId = default(Int32);
            Decimal _newPrice = default(Decimal);
            var _query = from item in _baseArg.Products.Include("SellProduct").ToList()
                         select item;
            if (_query.Count() <= 0)
            {
                Console.WriteLine("There is no items in database, please, add first...");
            }
            else
            {
                Console.WriteLine("Select product by ID to edit price ");
                foreach (var product in _query)
                {
                     Console.WriteLine("ID: {0}, ProductName: {1}  ProductPrice: {2} ", product.Id, product.ProductName, product.ProductPrice);
                }
                while (!_flagCorrect)
                {
                    while (Int32.TryParse(Console.ReadLine(), out _selectedId) == false)
                    {
                        Console.Write("Not correct symbols in Id value, please enter correct: ");
                    }
                    if (_selectedId > _query.Count() || _selectedId < 0)
                    {
                        Console.Write("Not correct Id, please enter correct: ");
                    }
                    else
                    {
                        _flagCorrect = true;
                    }
                }
                _flagCorrect = false;
                var _selectedItem = _baseArg.Products.Find(_selectedId);
                Console.Write("Enter new price of \"{0}\" : ", _selectedItem.ProductName);
                while (!_flagCorrect)
                {
                    while (Decimal.TryParse(Console.ReadLine(), out _newPrice) == false)
                    {
                        Console.Write("Not correct price value, please enter correct: ");
                    }
                    if (_newPrice <= 0)
                    {
                        Console.Write("Price value must be greater then zero:");
                    }
                    else
                    {
                        _flagCorrect = true;
                    }
                }
                _selectedItem.ProductPrice = _newPrice;
                Console.WriteLine("Changes saved...Enter to continue...");
                Console.ReadLine();
            }
        }
        public static void Show(ProductBase _baseArg)
        {
            var _query = from product in _baseArg.Products.Include("SellProduct").ToList()
                        where (product.SellProduct != null)
                        select product;
            Console.WriteLine(new String('-', 20));
            Console.WriteLine("Products with sells:");
            Console.WriteLine(new String('-', 20));
            if (_query.Count()==0)
            {
                Console.WriteLine("No products with sells...\r\n");
            }
            else
            {
                foreach (var product in _query)
                {
                    Console.WriteLine("ProductName: {0}  ProductPrice: {1} Purchase sum: {2} ", product.ProductName, product.ProductPrice, product.SellProduct.SellSum);
                }
            }
            var _query2 = from product in _baseArg.Products.Include("SellProduct").ToList()
                         where (product.SellProduct == null)
                         select product;
            Console.WriteLine(new String('-', 20));
            Console.WriteLine("Products without sells:");
            Console.WriteLine(new String('-', 20));
            if (_query.Count() == 0)
            {
                Console.WriteLine("No products without sells...\r\n");
            }
            else
            {
                foreach (var product in _query2)
                {
                    Console.WriteLine("ProductName: {0}  ProductPrice: {1} ", product.ProductName, product.ProductPrice);
                }
            }
            Console.WriteLine("Enter to continue...");
            Console.ReadLine();
        }
        public static void GetElementByKey(ProductBase _baseArg)
        {
            Boolean _flagCorrect = false;
            Int32 _selectedId = default(Int32);
            var _query = from item in _baseArg.Products.Include("SellProduct").ToList()
                         select item;
            if (_query.Count() <= 0)
            {

                Console.WriteLine("There is no items in database, please, add first...Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.Write("Enter ID from 1 to {0} to get proguct :",_query.Count());
                while (!_flagCorrect)
                {
                    while (Int32.TryParse(Console.ReadLine(), out _selectedId) == false)
                    {
                        Console.Write("Not correct symbols in Id value, please enter correct: ");
                    }
                    if (_selectedId > _query.Count() || _selectedId < 0)
                    {
                        Console.Write("Not correct Id, please enter correct: ");
                    }
                    else
                    {
                        _flagCorrect = true;
                    }
                }
                _flagCorrect = false;
                var _selectedItem = _baseArg.Products.Find(_selectedId);
                Console.WriteLine(new String('-', 20));
                Console.WriteLine("Selected product: Id - {0}, ProductName - {1}, ProductPrice - {2} ", _selectedItem.Id, _selectedItem.ProductName, _selectedItem.ProductPrice);
                if (_selectedItem.SellProduct!=null)
                {
                    Console.WriteLine("Product Sells - {0}",_selectedItem.SellProduct.SellSum);
                }
                Console.WriteLine(new String('-', 20));
                Console.WriteLine("Enter to continue...");
                Console.ReadLine();
            }
        }
        public static void Start(ProductBase _baseArg)
        {
            String _charSelect = default(String);
            Boolean _flagExit = false;
            while (!_flagExit)
            {
                Console.Clear();
                Console.WriteLine("Welcome, choose operation to execute, and press enter ");
                Console.WriteLine(new String('-', 20));
                Console.WriteLine("1. Add product");
                Console.WriteLine("2. Add sell to product or edit existing ");
                Console.WriteLine("3. Clear database tables");
                Console.WriteLine("4. Edit product name");
                Console.WriteLine("5. Edit product price");
                Console.WriteLine("6. Show database entries");
                Console.WriteLine("7. Get element by Key");
                Console.WriteLine(new String('-', 20));
                Console.WriteLine("x to exit...");
                Console.WriteLine(new String('-',20));
                _charSelect = Console.ReadLine();
                switch (_charSelect)
                {
                    case "1":
                        AddProduct(_baseArg);
                        break;
                    case "2":
                        AddPurchase(_baseArg);
                        break;
                    case "3":
                        ClearDataBase(_baseArg);
                        break;
                    case "4":
                        EditProductName(_baseArg);
                        break;
                    case "5":
                        EditProductPrice(_baseArg);
                        break;
                    case "6":
                        Show(_baseArg);
                        break;
                    case "7":
                        GetElementByKey(_baseArg);
                        break;
                    case "x":
                        _flagExit = true;
                        break;
                    default:
                        Console.WriteLine("Not correct operation Id entered");
                        break;
                }
            }
        }
    }
}
