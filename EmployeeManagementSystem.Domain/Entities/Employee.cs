namespace EmployeeManagementSystem.Domain.Entities;

public class Employee : BaseEntity
{
    public required string Name { get; set; }
    public decimal Salary { get; set; }
    public Deparment DepartmentId { get; set; }
    public required string EmailId { get; set; } 
    public DateTime Joiningdate { get; set; }

}
