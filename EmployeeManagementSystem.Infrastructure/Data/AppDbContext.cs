using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Domain.Entities;
namespace EmployeeManagementSystem.Infrastructure.Data;

public class AppDbContext  : DbContext
{ 
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>().HasQueryFilter(x => x.Status);
    }
}
