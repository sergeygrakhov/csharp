using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3_var2
{
    class Program
    {
        static void Main(string[] args)
        {

            Byte _bWrongInputCount = 0;
            Boolean _userFind = false;
            Boolean _passwordCorrect = false;
            String _userName = default(String);
            String _userRole = default(String);
            String _userEnteredPassword = default(String);
            int _index = 0;
            int _iUserQwantity = 0;
            String[] _userRoles = new string[] {"Admin","Admin","Admin","Moderator","Moderator","User", "User", "User", "User", "User" };
            String[] _userNames = new string[] {"Superman", "Batman", "Ironman", "Andrew", "Jeffrey", "Ivan", "Peter", "Nick", "Russel", "John" };
            String[] _userPasswords = new string[] { "kriptonit", "gotham", "avenger", "dotnet", "csharp", "qwerty", "helloworld", "chupachups", "delldell", "snow" };
          
            Console.Write("Login: ");
            _userName = Console.ReadLine();
            for (int i = 0; i < _userNames.Length; i++)
            {
                if (_userName == _userNames[i])
                {
                    _index = i;
                    _userFind = true;
                    break;
                }
            }
            if (_userFind)
            {
                while (_bWrongInputCount < 3)
                {
                    Console.Write("Password: ");

                    _userEnteredPassword = Console.ReadLine();
                    if (_userEnteredPassword == _userPasswords[_index])
                    {
                        _userRole = _userRoles[_index];
                        _passwordCorrect = true;
                        break;
                    }
                    else
                    {
                        _bWrongInputCount++;
                        if (_bWrongInputCount == 3)
                        {
                            Console.WriteLine("You reach max tries, program will be finished!");
                        }
                        else
                        {
                            Console.WriteLine("Incorrect password!");
                        }
                    }
                }
                if (_passwordCorrect)
                {
                    switch (_userRole)
                    {
                        case "Admin":
                            Console.WriteLine("List of all users:");
                            for (int i = 0; i < _userNames.Length; i++)
                            {
                                Console.WriteLine("{0,3}: Username {1,10}, Password {2,10}, Role {3,10} ", i + 1, _userNames[i], _userPasswords[i], _userRoles[i]);
                            }
                            break;
                        case "Moderator":
                            Console.WriteLine("Quantity of all users: {0} ", _userNames.Length);
                            break;
                        case "User":
                            Console.WriteLine("Name of users:");
                            for (int i = 0; i < _userNames.Length; i++)
                            {
                                if (_userRoles[i] == "User")
                                {
                                    Console.WriteLine("{0,3}: {1,10}", _iUserQwantity + 1, _userNames[i]);
                                    _iUserQwantity++;
                                }
                            }
                            Console.WriteLine("Quantity: {0}", _iUserQwantity);
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("User with entered login not found!!!");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
    
}
