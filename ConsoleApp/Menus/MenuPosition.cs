using ConsoleApp.Menus;
using ConsoleApp.Models;
using ConsoleApp1.Database;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1.Menus;

public class MenuPosition : Menu
{
    private readonly List<Position> _positions;
    private readonly Connection _connection = new Connection();

    public MenuPosition(List<string> options, string title) : base(options, title)
    {
        _positions = new List<Position>();
        LoadPosition();

    }

    private void LoadPosition()
    {
        try
        {
            _connection.OpenConnection();
            using SqlCommand command = new SqlCommand("SELECT id, name, base_salary, description, work_hours, vacation_days, has_health_plan, has_transportation_voucher, has_home_office FROM Positions", _connection.GetConnection());
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                decimal baseSalary = reader.GetDecimal(2);
                string description = reader.GetString(3);
                int workHours = reader.GetInt32(4);
                int vacationDays = reader.GetInt32(5);
                bool hasHealthPlan = reader.GetBoolean(6);
                bool hasTransportationVoucher = reader.GetBoolean(7);
                bool hasHomeOffice = reader.GetBoolean(8);

                Position position= new Position(id, name, baseSalary, description, workHours, vacationDays, hasHealthPlan, hasTransportationVoucher, hasHomeOffice);
                _positions.Add(position);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            _connection.CloseConnection();
        }
    }

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
                decimal baseSalary = ReadDecimal("Base salary: ");
                string description = ReadString("Description: ");
                int workHours = ReadInt("Work hours: ");
                int vacationDays = ReadInt("Vacation days: ");
                bool hasHealthPlan = ReadBoolean("Has health plan (true/false): ");
                bool hasTransportationVoucher = ReadBoolean("Has transportation voucher (true/false)");
                bool hasHomeOffice = ReadBoolean("Has home office (true/false): ");

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