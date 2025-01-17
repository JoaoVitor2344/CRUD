namespace ConsoleApp.Models;

public class Contract(int employerId, int employeeId, int positionId, int addressId, DateTime startDate, DateTime endDate, bool trialPeriod)
{
    public int EmployerId { get; set; }
    public int EmployeeId { get; set; }
    public int PositionId { get; set; }
    public int AddressId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool TrialPeriod { get; set; }
}