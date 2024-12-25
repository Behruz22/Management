namespace Management.Core.Entities;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Address { get; set; }
    public string Phone { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime? UpdatedAt { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
