using Management.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mangement.Infrastructure.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id); 
        builder.Property(c => c.Id).ValueGeneratedOnAdd(); 

        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.Phone)
               .IsRequired()
               .HasMaxLength(15);

        builder.HasMany(c => c.Employees)
               .WithOne(e => e.Company)
               .HasForeignKey(e => e.CompanyId)
               .OnDelete(DeleteBehavior.Cascade); 
    }
}
