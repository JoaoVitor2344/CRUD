using System;

namespace ConsoleApp.Models
{
    public class Position
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal BaseSalary { get; private set; }
        public string Description { get; private set; }
        public int WorkHours { get; private set; }
        public int VacationDays { get; private set; }
        public bool HasHealthPlan { get; private set; }
        public bool HasTransportationVoucher { get; private set; }
        public bool HasHomeOffice { get; private set; }

        public Position(int id, string name, decimal baseSalary, string description, int workHours, int vacationDays, bool hasHealthPlan, bool hasTransportationVoucher, bool hasHomeOffice)
        {
            ValidateInputs(name, baseSalary, description, workHours, vacationDays);

            Id = id;
            Name = name;
            BaseSalary = baseSalary;
            Description = description;
            WorkHours = workHours;
            VacationDays = vacationDays;
            HasHealthPlan = hasHealthPlan;
            HasTransportationVoucher = hasTransportationVoucher;
            HasHomeOffice = hasHomeOffice;
        }

        private void ValidateInputs(string name, decimal baseSalary, string description, int workHours, int vacationDays)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            if (baseSalary < 0)
                throw new ArgumentException("Base salary cannot be negative.", nameof(baseSalary));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));

            if (workHours <= 0)
                throw new ArgumentException("Work hours must be greater than zero.", nameof(workHours));

            if (vacationDays < 0)
                throw new ArgumentException("Vacation days cannot be negative.", nameof(vacationDays));
        }

        public void Update(string name, decimal baseSalary, string description, int workHours, int vacationDays, bool hasHealthPlan, bool hasTransportationVoucher, bool hasHomeOffice)
        {
            ValidateInputs(name, baseSalary, description, workHours, vacationDays);

            Name = name;
            BaseSalary = baseSalary;
            Description = description;
            WorkHours = workHours;
            VacationDays = vacationDays;
            HasHealthPlan = hasHealthPlan;
            HasTransportationVoucher = hasTransportationVoucher;
            HasHomeOffice = hasHomeOffice;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nBase Salary: {BaseSalary:C}\nDescription: {Description}\nWork Hours: {WorkHours}\nVacation Days: {VacationDays}\nHealth Plan: {HasHealthPlan}\nTransportation Voucher: {HasTransportationVoucher}\nHome Office: {HasHomeOffice}";
        }
    }
}