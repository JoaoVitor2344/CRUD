namespace ConsoleApp.Menus;

public class Menu(List<string> options, string title)
{
    public void Display()
    {
        Title(title);

        foreach (var option in options.Select((value, index) => new { value, index }))
        {
            Console.WriteLine($"{option.index + 1}. {option.value}");
        }
    }

    public int GetChoice()
    {
        while (true)
        {
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out var choice) && choice > 0 && choice <= options.Count)
            {
                Console.Clear();
                return choice;
            }

            Console.WriteLine("Invalid choice. Please try again.");
            Thread.Sleep(2000);
            Console.Clear();
        }
    }

    public static void Title(string title)
    {
        string separator = new string('=', title.Length);
        Console.WriteLine(separator);
        Console.WriteLine(title);
        Console.WriteLine(separator);
    }

    protected static void ExitOption()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    protected static string ReadString(string prompt)
    {
        Console.Write(prompt);

        string input = Console.ReadLine()!;
        return input;
    }

    protected static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()!;

            if (decimal.TryParse(input, out decimal result) && result >= 0)
                return result;

            Console.WriteLine("Valor inválido. Digite um número decimal não negativo.");
        }
    }

    protected static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()!;

            if (int.TryParse(input, out int result) && result > 0)
                return result;

            Console.WriteLine("Valor inválido. Digite um número inteiro positivo.");
        }
    }

    protected static bool ReadBoolean(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()!;

            if (bool.TryParse(input, out bool result))
                return result;

            Console.WriteLine("Valor inválido. Digite 'true' ou 'false'.");
        }
    }
}