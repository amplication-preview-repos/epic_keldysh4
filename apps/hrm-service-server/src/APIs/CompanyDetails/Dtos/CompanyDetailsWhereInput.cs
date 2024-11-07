namespace HrmService.APIs.Dtos;

public class CompanyDetailsWhereInput
{
    public string? Branch { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? DateOfJoining { get; set; }

    public string? Department { get; set; }

    public string? Designation { get; set; }

    public string? EmployeeId { get; set; }

    public string? Id { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
