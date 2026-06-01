using EmployeeManagementSystem.Domain.Enums;

namespace EmployeeManagementSystem.Application.DTOs;

public record CreateDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public Deparment DepartmentId { get; set; }
    public string EmailId { get; set; } = string.Empty;
}
