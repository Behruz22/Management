namespace Management.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
