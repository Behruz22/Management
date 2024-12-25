using Management.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Management.Application.Abstractions;

public interface IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
