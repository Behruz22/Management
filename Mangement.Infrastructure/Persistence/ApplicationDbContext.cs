using Management.Application.Abstractions;
using Management.Core.Entities;
using Management.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Mangement.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
    public DbSet<User> Users { get ; set ; }
    public DbSet<Company> Companies { get ; set ; }
    public DbSet<Employee> Employees { get ; set ; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}
