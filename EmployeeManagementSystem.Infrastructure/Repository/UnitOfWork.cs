using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Infrastructure.Data;

namespace EmployeeManagementSystem.Infrastructure.Repository;

public sealed class UnitOfWork(AppDbContext context, IGenericRepository<Employee> employees) : IUnitOfWork
{
    public IGenericRepository<Employee> Employees { get; } = employees;

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }

}
