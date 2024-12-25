using Management.Core.Enums;

namespace Management.Core.Entities;

public class Employee
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public Role Role {  get; set; } 
}
