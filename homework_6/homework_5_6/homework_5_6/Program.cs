using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_5_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Scout> _scoutsList = Camp.FillCampByScouts();
            Camp.Start(_scoutsList);
            Console.ReadKey();
        }
    }
    class Scout
    {
        public String Name { get; set; }
        public Boolean Gender { get; set; } //false girl;  true boy
        public List<Reward> RewardList = new List<Reward>();
        public static void AddSport(Scout _scoutArg)
        {
            Boolean _flagCorrect = false;
            UInt32 _indexSelect = default(UInt32);
            Console.Clear();
            Console.WriteLine("Select sport to add: ");
            if(_scoutArg.Gender)
            {
                 var _tempScout = (BoyScout)_scoutArg;
                 for (int i = 0; i < _tempScout._sportPool.Length; i++)
                    {
                        Console.WriteLine("{0}: {1}", i + 1, _tempScout._sportPool[i]);
                    }
                    while (!_flagCorrect)
                    {
                        while (UInt32.TryParse(Console.ReadLine(), out _indexSelect) == false)
                        {
                            Console.Write("Not correct symbols in selection...\r\nPlease enter correct!.. : ");
                        }
                        if (_indexSelect <= _tempScout._sportPool.Length && _indexSelect >= 1)
                        {
                            _indexSelect -= 1;
                            _flagCorrect = true;
                        }
                        else
                        {
                            Console.Write("Please enter correct id (from 1 to {0}): ", _tempScout._sportPool.Length);
                        }
                    }
                    _tempScout.SportList.Add(_tempScout._sportPool[_indexSelect]);
                }
                else
                {
                    var _tempScout = (GirlScout)_scoutArg;
                for (int i = 0; i < _tempScout._sportPool.Length; i++)
                {
                    Console.WriteLine("{0}: {1}", i + 1, _tempScout._sportPool[i]);
                }
                while (!_flagCorrect)
                {

                    while (UInt32.TryParse(Console.ReadLine(), out _indexSelect) == false)
                    {
                        Console.Write("Not correct symbols in selection...\r\nPlease enter correct!.. : ");
                    }
                    if (_indexSelect <= _tempScout._sportPool.Length && _indexSelect >= 1)
                    {
                        _indexSelect -= 1;
                        _flagCorrect = true;
                    }
                    else
                    {
                        Console.Write("Please enter correct id (from 1 to {0}): ", _tempScout._sportPool.Length);
                    }
                }
                _tempScout.SportList.Add(_tempScout._sportPool[_indexSelect]);
            }
        }
        public static void RemoveSport(Scout _scoutArg)
        {
            Console.Clear();
            Boolean _flagCorrect = false;
            Int32 _indexSelect = default(Int32);
            if (_scoutArg.Gender)
            {
                var _tempScout = (BoyScout)_scoutArg;
                if(_tempScout.SportList.Count>=1)
                {
                    Console.WriteLine("Select sport to remove: ");
                    for (int i = 0; i < _tempScout.SportList.Count; i++)
                    {
                        Console.WriteLine("{0}: {1}", i + 1, _tempScout.SportList[i]);
                    }
                    while (!_flagCorrect)
                    {
                        while (Int32.TryParse(Console.ReadLine(), out _indexSelect) == false)
                        {
                            Console.Write("Not correct symbols in selection...\r\nPlease enter correct!.. : ");
                        }
                        if (_indexSelect <= _tempScout.SportList.Count && _indexSelect >= 1)
                        {
                            _indexSelect -= 1;
                            _flagCorrect = true;
                        }
                        else
                        {
                            Console.Write("Please enter correct id (from 1 to {0}): ", _tempScout.SportList.Count);
                        }
                    }
                    _tempScout.SportList.RemoveAt(_indexSelect);
                }
                else
                {
                    Console.WriteLine("Selected scout boy has no sport skills...Any key to continue...");
                    Console.ReadKey();
                }
                
            }
            else
            {
                var _tempScout = (GirlScout)_scoutArg;
                if(_tempScout.SportList.Count>=1)
                {
                    Console.WriteLine("Select sport to remove: ");
                    for (int i = 0; i < _tempScout.SportList.Count; i++)
                    {
                        Console.WriteLine("{0}: {1}", i + 1, _tempScout.SportList[i]);
                    }
                    while (!_flagCorrect)
                    {
                        while (Int32.TryParse(Console.ReadLine(), out _indexSelect) == false)
                        {
                            Console.Write("Not correct symbols in selection...\r\nPlease enter correct!.. : ");
                        }
                        if (_indexSelect <= _tempScout.SportList.Count && _indexSelect >= 1)
                        {
                            _indexSelect -= 1;
                            _flagCorrect = true;
                        }
                        else
                        {
                            Console.Write("Please enter correct id (from 1 to {0}): ", _tempScout.SportList.Count);
                        }
                    }
                    _tempScout.SportList.RemoveAt(_indexSelect);
                }
                else
                {
                    Console.WriteLine("Selected scout girl has no sport skills...Any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        public static void AddReward(Scout _scoutArg)
        {
            Console.Clear();
            String _textString = default(String);
            Boolean _flagCorrect = false;
            Byte _bValue = default(Byte);
            Reward _tempReward = new Reward();
            Console.Write("Enter Award title (no more than 50 symbols):");
            while (!_flagCorrect)
            {
                _textString = Console.ReadLine();
                if(_textString.Length<=50)
                {
                    _flagCorrect = true;
                }
                else
                {
                    Console.WriteLine("To many symbols...Try again...");
                }
            }
            _flagCorrect = false;
            Console.Write("Enter value of Award: ");
            while (!_flagCorrect)
            {
                while (Byte.TryParse(Console.ReadLine(), out _bValue) == false)
                {
                    Console.Write("Not correct symbols in value...\r\nPlease enter correct!.. : ");
                }
                if(_bValue<=100 && _bValue>=1)
                {
                    _flagCorrect = true;
                }
                else
                {
                    Console.Write("Enter value from 1 to 100:");
                }
            }
            _tempReward.Title = _textString;
            _tempReward.Value = _bValue;
            _scoutArg.RewardList.Add(_tempReward);
        }
    }
    class GirlScout:Scout
    {
        public String[] _sportPool = new String[] { "Gymnastic", "Sport dance", "Choreography", "Yoga" };
        public List<String> SportList = new List<String>();
    }
    class BoyScout:Scout
    {
        public String[] _sportPool = new String[] { "Football", "Basketball", "Running", "Powerlifting" };
        public List<String> SportList = new List<String>();
    }
    class Camp
    {
        protected static void ShowMenu()
        {
            Console.WriteLine("Choose operation:");
            Console.WriteLine("1. Add Scout.\r\n2. Add sport to scout.\r\n3. Remove sport from scout.\r\n4. Show all scouts.\r\n5. Show boys.\r\n6. Show girls.\r\n7. Add award.\r\n8. Statistics.\r\n9. Exit");
        }
        public static List<Scout> FillCampByScouts()
            {
                String[] _namePoolBoys = new String[10] { "Ivan", "John", "Peter", "Andrey", "Sergey", "Bill", "Nick", "Arnold", "Bruce", "Anton" };
                String[] _namePoolGirls = new String[10] { "Helen", "Anna", "Irina", "Bella", "Kate", "Sara", "Lisa", "Tanya", "Sveta", "Tina" };
                List<Scout> _scoutList = new List<Scout>();
                for (int i = 0; i < 10; i++)
                {
                    Scout _tempScout = new BoyScout
                    {
                        Name = _namePoolBoys[i],
                        Gender = true
                    };
                    _scoutList.Add(_tempScout);
                    _tempScout = new GirlScout
                    {
                        Name = _namePoolGirls[i],
                        Gender = false
                    };
                    _scoutList.Add(_tempScout);

                }
                return _scoutList;
            }
        private static List<Scout> AddScout(ref List<Scout> _scoutList)
            {
                Console.Clear();
                String _charSelect = default(String);
                Boolean _flagCorrect = false;
                Console.Write("Boy - press 1, Girl - press 2: ");
                while (!_flagCorrect)
                {
                    _charSelect = Console.ReadLine();
                    if ((_charSelect != "1") && (_charSelect != "2"))
                    {
                        Console.Write("Not correct selection, press 1 for boy or 2 for girl: ");
                    }
                    else
                    {
                        _flagCorrect = true;
                    }
                }
                switch (_charSelect)
                    {
                        case "1":
                            Console.Write("Enter name: ");
                            Scout _tempScout = new BoyScout
                            {
                                Name = Console.ReadLine(),
                                Gender = true
                            };
                            _scoutList.Add(_tempScout);
                        break;
                        case "2":
                            Console.Write("Enter name: ");
                            Scout _tempScout1 = new GirlScout
                            {
                                Name = Console.ReadLine(),
                                Gender = false
                            };
                            _scoutList.Add(_tempScout1);
                        break;
                    }
                return _scoutList;
            }   
        private static void ShowAllScouts(List<Scout> _listArg)
        {
            Console.Clear();
            Console.WriteLine("All scouts in camp: ");
            for (int i = 0; i < _listArg.Count; i++)
            {
                Console.WriteLine("{0}: {1}",i+1,_listArg[i].Name);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private static void ShowBoys(List<Scout> _listArg)
        {
            Console.Clear();
            Console.WriteLine("Scout boys in camp:");
            UInt32 j = 0;
            for (int i = 0; i < _listArg.Count; i++)
            {
                if(_listArg[i].Gender)
                {
                    Console.WriteLine("{0}: {1}", j + 1, _listArg[i].Name);
                    j++;
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private static void ShowGirls(List<Scout> _listArg)
        {
            Console.Clear();
            Console.WriteLine("Scout girls in camp: ");
            UInt32 j = 0;
            for (int i = 0; i < _listArg.Count; i++)
            {
                if (!_listArg[i].Gender)
                {
                    Console.WriteLine("{0}: {1}", j + 1, _listArg[i].Name);
                    j++;
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private static Int32 SelectScout(List<Scout> _listArg)
        {
            Console.Clear();
            Boolean _flagCorrect = false;
            Int32 _indexOfScout = default(Int32);
            for (int i = 0; i < _listArg.Count; i++)
            {
                Console.WriteLine("{0}: {1}", i + 1, _listArg[i].Name);
            }
            Console.Write("Enter id of needed scout: ");
            while(!_flagCorrect)
            {
                while (Int32.TryParse(Console.ReadLine(), out _indexOfScout) == false)
                {
                    Console.Write("Not correct symbols in id value...\r\nPlease enter correct!.. : ");
                }
                if (_indexOfScout >= 0 && _indexOfScout <= _listArg.Count)
                {
                    _indexOfScout -= 1;
                    _flagCorrect = true;
                }
                else
                {
                    Console.WriteLine("Not correct id... Try again...");
                }
            }
            return _indexOfScout;
        }
        private static void Stats(List<Scout> _listArg)
        {
            Console.Clear();
            Console.WriteLine("Awards per scout:");
            Double _middleValue = default(Double);
            Double _middleValueCamp = default(Double);
            Double _maxValue = default(Double);
            Double _minValue = 100;
            String _bestScout = default(String);
            String _worstestScout = default(String);
            for (int i = 0; i < _listArg.Count; i++)
            {
                Console.Write("{0}. {1}: ",i+1,_listArg[i].Name);
                if (_listArg[i].RewardList.Count>=1)
                {
                    for (int j = 0; j < _listArg[i].RewardList.Count; j++)
                    {
                        _middleValue += _listArg[i].RewardList[j].Value;
                    }
                    _middleValue /= _listArg[i].RewardList.Count;
                    Console.WriteLine(_middleValue);
                    _middleValueCamp += _middleValue;
                    if(_middleValue>_maxValue)
                    {
                        _maxValue = _middleValue;
                        _bestScout = _listArg[i].Name;
                    }
                    if (_middleValue < _minValue)
                    {
                        _minValue = _middleValue;
                        _worstestScout = _listArg[i].Name;
                    }
                }
                else
                {
                    Console.WriteLine("No awards yet...");
                }
            }
            Console.Write("Middle Award value in camp: {0}\r\n",_middleValueCamp/_listArg.Count);
            Console.WriteLine("Best scout in camp: {0}",_bestScout);
            Console.WriteLine("Worstest scout in camp: {0}", _worstestScout);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public static void Start(List<Scout> _scoutList)
        {
            Boolean _flagExit = false;

            while (!_flagExit)
            {
                Console.Clear();
                ShowMenu();
                String _charSelect = Console.ReadLine();
                switch (_charSelect)
                {
                    case "1":
                        Camp.AddScout(ref _scoutList);
                        break;
                    case "2":
                        Scout.AddSport(_scoutList[Camp.SelectScout(_scoutList)]);
                        break;
                    case "3":
                        Scout.RemoveSport(_scoutList[Camp.SelectScout(_scoutList)]);
                        break;
                    case "4":
                        Camp.ShowAllScouts(_scoutList);
                        break;
                    case "5":
                        Camp.ShowBoys(_scoutList);
                        break;
                    case "6":
                        Camp.ShowGirls(_scoutList);
                        break;
                    case "7":
                        Scout.AddReward(_scoutList[Camp.SelectScout(_scoutList)]);
                        break;
                    case "8":
                        Camp.Stats(_scoutList);
                        break;
                    case "9":
                        _flagExit = true;
                        Console.WriteLine("Press any key to exit...");
                        break;
                    default:
                        Console.WriteLine("Wrong selection... Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
    class Reward
    {
        public String Title { get; set; }
        public Byte Value { get; set; }
    }
}
