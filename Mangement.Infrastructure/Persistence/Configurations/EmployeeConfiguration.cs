using Management.Core.Entities;
using Management.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mangement.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id); 
        builder.Property(e => e.Id).ValueGeneratedOnAdd();


        builder.HasOne(e => e.Company)
               .WithMany(c => c.Employees)
               .HasForeignKey(e => e.CompanyId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.User)
               .WithMany(u => u.Employees)
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
