using ConsoleApp.Models;

namespace ConsoleApp.Menus;

public class MenuPosition(List<string> options, string title) : Menu(options, title)
{
    private readonly List<Position> _positions =
    [
        new Position(
            id: 1,
            name: "Software Engineer",
            baseSalary: 8000.00m,
            description: "Develop and maintain software applications.",
            workHours: 40,
            vacationDays: 30,
            hasHealthPlan: true,
            hasTransportationVoucher: true,
            hasHomeOffice: true
        ),

        new Position(
            id: 2,
            name: "Product Manager",
            baseSalary: 10000.00m,
            description: "Manage product development and strategy.",
            workHours: 40,
            vacationDays: 30,
            hasHealthPlan: true,
            hasTransportationVoucher: true,
            hasHomeOffice: false
        ),

        new Position(
            id: 3,
            name: "Data Scientist",
            baseSalary: 9000.00m,
            description: "Analyze and interpret complex data.",
            workHours: 40,
            vacationDays: 30,
            hasHealthPlan: true,
            hasTransportationVoucher: false,
            hasHomeOffice: true
        )
    ];

    public void Register()
    {
        Title("Register Position");

        try
        {
            string name = ReadString("Name: ");
            decimal baseSalary = ReadDecimal("Base salary: ");
            string description = ReadString("Description: ");
            int workHours = ReadInt("Work hours: ");
            int vacationDays = ReadInt("Vacation days: ");
            bool hasHealthPlan = ReadBoolean("Has health plan (true/false): ");
            bool hasTransportationVoucher = ReadBoolean("Has transportation voucher (true/false): ");
            bool hasHomeOffice = ReadBoolean("Has home office (true/false): ");

            Position position = new Position(
                id: _positions.Count + 1,
                name: name,
                baseSalary: baseSalary,
                description: description,
                workHours: workHours,
                vacationDays: vacationDays,
                hasHealthPlan: hasHealthPlan,
                hasTransportationVoucher: hasTransportationVoucher,
                hasHomeOffice: hasHomeOffice
            );

            _positions.Add(position);
            Console.WriteLine($"\nPosition '{name}' registered successfully!");
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

    public void ListPositions()
    {
        Title("List Positions");

        if (_positions.Count == 0)
        {
            Console.WriteLine("No positions registered.");
        }
        else
        {
            foreach (Position position in _positions)
            {
                Console.WriteLine(position.ToString());
                Console.WriteLine();
            }
        }

        ExitOption();
    }

    public void UpdatePosition()
    {
        Title("Update Position");

        if (_positions.Count == 0)
        {
            Console.WriteLine("No positions registered.");
        }
        else
        {
            string name = ReadString("Name: ");
            Position? position = _positions.Find(p => p.Name == name);

            if (position == null)
            {
                Console.WriteLine("Position not found.");
            }
            else
            {
                decimal baseSalary = ReadDecimal("Base salary: ", position.BaseSalary);
                string description = ReadString("Description: ");
                int workHours = ReadInt("Work hours: ", position.WorkHours);
                int vacationDays = ReadInt("Vacation days: ", position.VacationDays);
                bool hasHealthPlan = ReadBoolean("Has health plan (true/false): ", position.HasHealthPlan);
                bool hasTransportationVoucher = ReadBoolean("Has transportation voucher (true/false): ",
                    position.HasTransportationVoucher);
                bool hasHomeOffice = ReadBoolean("Has home office (true/false): ", position.HasHomeOffice);

                position.Update(
                    name: name,
                    baseSalary: baseSalary,
                    description: description,
                    workHours: workHours,
                    vacationDays: vacationDays,
                    hasHealthPlan: hasHealthPlan,
                    hasTransportationVoucher: hasTransportationVoucher,
                    hasHomeOffice: hasHomeOffice
                );

                Console.WriteLine("\nPosition updated successfully!");
            }
        }

        ExitOption();
    }
}