using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Infrastructure.Data;

namespace EmployeeManagementSystem.Infrastructure.Repository;

public sealed class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _set = context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync() {
        return await _set.ToListAsync();
    }
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _set.FindAsync(id);
    }
    public async Task AddAsync(T entity)
    {
        await _set.AddAsync(entity);
    }
    public void Update(T entity)
    {
         _set.Update(entity);
    }
    public void Delete(T entity)
    {
        entity.Status = false;
        _set.Update(entity);
    }
}
    