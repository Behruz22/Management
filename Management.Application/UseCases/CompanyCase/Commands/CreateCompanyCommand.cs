using MediatR;
using System.Text.Json.Serialization;

namespace Management.Application.UseCases.CompanyCase.Commands;

public class CreateCompanyCommand : IRequest<bool>
{
    public string Name { get; set; }
    public string? Address { get; set; }
    public string Phone { get; set; }
    public string? Email { get; set; }
    [JsonIgnore]
    public DateTime CreatedAt { get; set; } 
}
