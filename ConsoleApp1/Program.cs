using ConsoleApp.Menus;
using ConsoleApp1.Database;
using ConsoleApp1.Menus;

namespace ConsoleApp1
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

        private void ShowUserMenu()
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

        private void ShowPositionMenu()
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

        private void ShowAddressMenu()
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

        private void ShowContractMenu()
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
}