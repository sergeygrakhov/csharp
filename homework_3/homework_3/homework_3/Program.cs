using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_3
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
            String[,] _arrayUsers = new String[,]
                {
                    {"Admin","Superman","kriptonit"},
                    {"Admin","Batman","gotham"},
                    {"Admin","Ironman","avenger"},
                    {"Moderator","Andrew","dotnet"},
                    {"Moderator","Jeffrey","csharp"},
                    {"User","Ivan","qwerty"},
                    {"User","Peter","helloworld"},
                    {"User","Nick","chupachups"},
                    {"User","Russel","delldell"},
                    {"User","John","snow"},
                };
            
            Console.Write("Login: ");
            _userName = Console.ReadLine();
            for (int i = 0; i < _arrayUsers.GetLength(0); i++)
            {
                if (_userName == _arrayUsers[i, 1])
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
                    if (_userEnteredPassword == _arrayUsers[_index,2])
                    {
                        _userRole = _arrayUsers[_index, 0];
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
                if(_passwordCorrect)
                {
                    switch (_userRole)
                    {
                        case "Admin":
                            Console.WriteLine("List of all users:");
                            for (int i = 0; i < _arrayUsers.GetLength(0); i++)
                            {
                                Console.WriteLine("{0,3}: Username {1,10}, Password {2,10}, Role {3,10} ",i+1, _arrayUsers[i,1], _arrayUsers[i, 2], _arrayUsers[i, 0]);
                            }
                            break;
                        case "Moderator":
                            Console.WriteLine("Quantity of all users: {0} ",_arrayUsers.GetLength(0));
                            break;
                        case "User":
                            Console.WriteLine("Name of users:");
                            for (int i = 0; i < _arrayUsers.GetLength(0); i++)
                            {
                                if(_arrayUsers[i,0] == "User")
                                {
                                    Console.WriteLine("{0,3}: {1,10}",_iUserQwantity+1, _arrayUsers[i, 1]);
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
