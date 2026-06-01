namespace EmployeeManagementSystem.Application.Interfaces;

public interface IUnitOfWork
{   
    public IGenericRepository<Employee> Employees { get; }
    Task<int> SaveChangesAsync();
}
