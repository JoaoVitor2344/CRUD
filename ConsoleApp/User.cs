namespace ConsoleApp;

public class User
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
    
    public User(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
    
    public override string ToString() => $"First name: {FirstName}\nLast name: {LastName}\nEmail: {Email}";
}   
