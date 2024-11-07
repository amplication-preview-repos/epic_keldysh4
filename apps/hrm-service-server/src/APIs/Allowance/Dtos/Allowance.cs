using HrmService.Core.Enums;

namespace HrmService.APIs.Dtos;

public class Allowance
{
    public AllowanceOptionEnum? AllowanceOption { get; set; }

    public double? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? EmployeeName { get; set; }

    public string Id { get; set; }

    public string? Title { get; set; }

    public string? TypeField { get; set; }

    public DateTime UpdatedAt { get; set; }
}
