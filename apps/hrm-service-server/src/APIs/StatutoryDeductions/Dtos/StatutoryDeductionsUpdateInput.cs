using HrmService.Core.Enums;

namespace HrmService.APIs.Dtos;

public class StatutoryDeductionsUpdateInput
{
    public double? Amount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DeductionOptionEnum? DeductionOption { get; set; }

    public string? EmployeeName { get; set; }

    public string? Id { get; set; }

    public string? Title { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
