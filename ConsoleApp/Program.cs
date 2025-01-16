<<<<<<< HEAD
﻿using ConsoleApp.Models;
using ConsoleApp.Menus;

namespace ConsoleApp
{
    internal class Program
    {
        private readonly Menu _mainMenu = new Menu([
            "Users",
            "Positions",
            "Addresses",
            "Exit"
        ], "Main Menu");
        
        private readonly MenuUsers _menuUsers = new MenuUsers([
            "Register User",
            "List Users",
            "Update User",
            "Contracts",
            "Back to Main Menu",
        ], "User Menu");

        private readonly MenuPosition _menuPosition = new MenuPosition([
            "Register Position",
            "List Positions",
            "Update Position",
            "Back to Main Menu",
        ], "Position Menu");

        private readonly MenuAddress _menuAddress = new MenuAddress([
            "Register Address",
            "List Addresses",
            "Update Address",
            "Back to Main Menu",
        ], "Address Menu");

        private readonly MenuContract _menuContract = new MenuContract([
            "Register Contract",
            "List Contracts",
            "Update Contract",
            "Back to Main Menu",
        ], "Contract Menu");

        static void Main()
        {
            Program program = new Program();
            program.Run();
        }

        void Run()
        {
            while (true)
            {
                _mainMenu.Display();
                var choice = _mainMenu.GetChoice();
                
                switch (choice)
                {
                    case 1:
                        ShowUserMenu();
                        break;
                    case 2:
                        ShowPositionMenu();
                        break;
                    case 3:
                        ShowAddressMenu();
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        void ShowUserMenu()
        {
            _menuUsers.Display();
            var choice = _menuUsers.GetChoice();
            
            switch (choice)
            {
                case 1:
                    _menuUsers.Register();
                    break;
                case 2:
                    _menuUsers.ListUsers();
                    break;
                case 3:
                    _menuUsers.UpdateUser();
                    break;
                case 4:
                    ShowContractMenu();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        void ShowPositionMenu()
        {
            _menuPosition.Display();
            var choice = _menuPosition.GetChoice();

            switch (choice)
            {
                case 1:
                    _menuPosition.Register();
                    break;
                case 2:
                    _menuPosition.ListPositions();
                    break;
                case 3:
                    _menuPosition.UpdatePosition();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        void ShowAddressMenu()
        {
            _menuAddress.Display();
            var choice = _menuAddress.GetChoice();

            switch (choice)
            {
                case 1:
                    _menuAddress.Register();
                    break;
                case 2:
                    _menuAddress.ListAddresses();
                    break;
                case 3:
                    _menuAddress.UpdateAddress();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        void ShowContractMenu()
        {
            _menuContract.Display();
            var choice = _menuContract.GetChoice();
            
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
=======
﻿namespace ConsoleApp
{
    public class Program
    {
        List<User> users = new List<User>();

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        void Run()
        {
            while (true)
            {
                ShowMenu();
                Console.Write("Option: ");
                string option = Console.ReadLine()!;
                Console.Clear();

                switch (option)
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        List();
                        break;
                    case "3":
                        Update();
                        break;
                    case "4":
                        Exit();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        void ShowMenu()
        {
            Console.WriteLine("1 - Register");
            Console.WriteLine("2 - List");
            Console.WriteLine("3 - Update");
            Console.WriteLine("4 - Exit\n");
        }

        void Title(string title)
        {
            string separator = new string('-', title.Length);
            Console.WriteLine(separator);
            Console.WriteLine(title);
            Console.WriteLine(separator);
        }
        
        void ExitOption()
        {
            Console.WriteLine("\nExiting...");
            Thread.Sleep(2000);
            Console.Clear();
        }

        void Register()
        {
            Title("Register");
            
            Console.Write("First name: ");
            string name = Console.ReadLine()!;
            Console.Write("Last name: ");
            string lastName = Console.ReadLine()!;
            Console.Write("Email: ");
            string email = Console.ReadLine()!;
            Console.Write("Password: ");
            string password = Console.ReadLine()!;

            User user = new User(name, lastName, email, password);
            users.Add(user);
            
            Console.WriteLine("\nUser registered successfully!");
            ExitOption();
        }

        void List()
        {
            Title("List");
            
            if (users.Count == 0)
            {
                Console.WriteLine("No users registered.");
            }
            else
            {
                foreach (User user in users)
                {
                    Console.WriteLine($"First name: {user.FirstName}");
                    Console.WriteLine($"Last name: {user.LastName}");
                    Console.WriteLine($"Email: {user.Email}");
                }
            }
            
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        void Update()
        {
            Title("Update");
            
            if (users.Count == 0) Console.WriteLine("No users registered.");
            else
            {
                Console.Write("Email: ");
                string email = Console.ReadLine()!;
                
                User? user = users.Find(u => u.Email == email);
                if (user == null) Console.WriteLine("User not found.");
                else
                {
                    Console.Write("First name: ");
                    string name = Console.ReadLine()!;
                    Console.Write("Last name: ");
                    string lastName = Console.ReadLine()!;
                    Console.Write("Password: ");
                    string password = Console.ReadLine()!;
                    
                    user.FirstName = name;
                    user.LastName = lastName;
                    user.Password = password;
                    
                    Console.WriteLine("\nUser updated successfully!");
                }
            }
            
            ExitOption();
        }

        void Exit()
        {
            Console.WriteLine("Exiting...");
        }
    }
>>>>>>> c81d71d (feat:init)
}