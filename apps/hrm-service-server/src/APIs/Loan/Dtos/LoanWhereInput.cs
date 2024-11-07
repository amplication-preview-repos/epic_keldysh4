using HrmService.Core.Enums;

namespace HrmService.APIs.Dtos;

public class LoanWhereInput
{
    public double? Amount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Employee { get; set; }

    public string? Id { get; set; }

    public double? LoanAmount { get; set; }

    public LoanOptionEnum? LoanOption { get; set; }

    public string? Title { get; set; }

    public string? TypeField { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
