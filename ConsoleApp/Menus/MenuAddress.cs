using ConsoleApp.Models;

namespace ConsoleApp.Menus;

public class MenuAddress(List<string> options, string title) : Menu(options, title)
{
    private readonly List<Address> _addresses =
    [
        new Address(
            id: 1,
            street: "Main St",
            number: "123",
            complement: "Apt 101",
            neighborhood: "Downtown",
            city: "Springfield",
            state: "IL",
            zipCode: "62701",
            country: "USA",
            user: null
        ),

        new Address(
            id: 2,
            street: "Broadway",
            number: "456",
            complement: "Suite 202",
            neighborhood: "Midtown",
            city: "New York",
            state: "NY",
            zipCode: "10001",
            country: "USA",
            user: null
        ),

        new Address(
            id: 3,
            street: "Sunset Blvd",
            number: "789",
            complement: "Floor 3",
            neighborhood: "Hollywood",
            city: "Los Angeles",
            state: "CA",
            zipCode: "90001",
            country: "USA",
            user: null
        )
    ];

    public void Register()
    {
        Title("Register Address");

        try
        {
            string street = ReadString("Street: ");
            string number = ReadString("Number: ");
            string complement = ReadString("Complement: ");
            string neighborhood = ReadString("Neighborhood: ");
            string city = ReadString("City: ");
            string state = ReadString("State: ");
            string zipCode = ReadString("Zip code: ");
            string country = ReadString("Country: ");

            Address address = new Address(
                id: _addresses.Count + 1,
                street: street,
                number: number,
                complement: complement,
                neighborhood: neighborhood,
                city: city,
                state: state,
                zipCode: zipCode,
                country: country,
                user: null
            );
            _addresses.Add(address);

            Console.WriteLine("\nAddress registered successfully!");
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

    public void ListAddresses()
    {
        Title("List Addresses");

        if (_addresses.Count == 0) Console.WriteLine("No addresses registered.");
        else
        {
            foreach (Address address in _addresses)
            {
                Console.WriteLine(address.ToString());
                Console.WriteLine();
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    public void UpdateAddress()
    {
        Title("Update Address");

        try
        {
            Console.WriteLine("Enter the address ID to update:");
            int id = ReadInt("ID: ");

            if (_addresses.Count == 0) Console.WriteLine("No addresses registered.");
            else
            {
                Address? address = _addresses.Find(a => a.Id == id);
                if (address == null) Console.WriteLine("Address not found.");
                else
                {
                    string street = ReadString("Street: ");
                    string number = ReadString("Number: ");
                    string complement = ReadString("Complement: ");
                    string neighborhood = ReadString("Neighborhood: ");
                    string city = ReadString("City: ");
                    string state = ReadString("State: ");
                    string zipCode = ReadString("Zip code: ");
                    string country = ReadString("Country: ");

                    address.Update(
                        street: street,
                        number: number,
                        complement: complement,
                        neighborhood: neighborhood,
                        city: city,
                        state: state,
                        zipCode: zipCode,
                        country: country
                    );

                    Console.WriteLine("\nAddress updated successfully!");
                }
            }
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
}