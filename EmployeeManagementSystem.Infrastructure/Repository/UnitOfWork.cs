namespace EmployeeManagementSystem.Infrastructure.Repository;

public sealed class UnitOfWork(AppDbContext context, IGenericRepository<Employee> employees) : IUnitOfWork
{
    public IGenericRepository<Employee> Employees { get; } = employees;

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }

}
