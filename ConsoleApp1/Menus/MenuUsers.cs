using ConsoleApp.Menus;
using ConsoleApp.Models;
using ConsoleApp1.Database;
using ConsoleApp1.Models;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1.Menus;

public class MenuUsers : Menu
{
    private readonly List<User> _users = [];
    private readonly Connection _connection = new Connection();

    public MenuUsers(List<string> options, string title) : base(options, title)
    {
        _users = new List<User>();
        LoadUsersFromDatabase();
    }

    private void LoadUsersFromDatabase()
    {
        try
        {
            _connection.OpenConnection();
            using SqlCommand command = new SqlCommand("SELECT first_name, last_name, email, password FROM Users", _connection.GetConnection());
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string firstName = reader.GetString(0);
                string lastName = reader.GetString(1);
                string email = reader.GetString(2);
                string password = reader.GetString(3);

                User user = new User(firstName, lastName, email, password);
                _users.Add(user);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
        finally
        {
            _connection.CloseConnection();
        }
    }

    public void Register()
    {
        Title("Register User");

        try
        {
            string firstName = ReadString("First name: ");
            string lastName = ReadString("Last name: ");
            string email = ReadString("Email: ");
            string password = ReadString("Password: ");

            User user = new User(firstName, lastName, email, password);
            _users.Add(user);

            _connection.OpenConnection();
            _connection.ExecuteNonQuery($"INSERT INTO Users (first_name, last_name, email, password) VALUES ('{firstName}', '{lastName}', '{email}', '{password}')");
            _connection.CloseConnection();

            Console.WriteLine("\nUser registered successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
        finally
        {
            ExitOption();
        }
    }

    public void ListUsers()
    {
        Title("List Users");

        if (_users.Count == 0)
        {
            Console.WriteLine("No users registered.");
        }
        else
        {
            foreach (User user in _users)
            {
                Console.WriteLine(user.ToString());
                Console.WriteLine();
            }
        }

        ExitOption();
    }

    public void UpdateUser()
    {
        Title("Update User");

        if (_users.Count == 0)
        {
            Console.WriteLine("No users registered.");
        }
        else
        {
            string email = ReadString("Email: ");
            User? user = _users.Find(u => u.Email == email);

            if (user == null)
            {
                Console.WriteLine("User not found.");
            }
            else
            {
                string firstName = ReadString("First name: ");
                string lastName = ReadString("Last name: ");
                string password = ReadString("Password: ");

                user.FirstName = firstName;
                user.LastName = lastName;
                user.Password = password;

                _connection.OpenConnection();
                _connection.ExecuteNonQuery($"UPDATE Users SET first_name = '{firstName}', last_name = '{lastName}', password = '{password}' WHERE email = '{email}'");
                _connection.CloseConnection();

                Console.WriteLine("\nUser updated successfully!");
            }
        }

        ExitOption();
    }
}