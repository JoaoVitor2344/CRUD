namespace ConsoleApp.Models;

public class User(string firstName, string lastName, string email, string password, Contract? contract)
{
    public int Id { get; set; }
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;

    public override string ToString() => $"First name: {FirstName}\nLast name: {LastName}\nEmail: {Email}";
}