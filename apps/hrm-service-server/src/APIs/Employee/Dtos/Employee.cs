using HrmService.Core.Enums;

namespace HrmService.APIs.Dtos;

public class Employee
{
    public string? Address { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? Dob { get; set; }

    public string? Email { get; set; }

    public GenderEnum? Gender { get; set; }

    public string Id { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public DateTime UpdatedAt { get; set; }
}
