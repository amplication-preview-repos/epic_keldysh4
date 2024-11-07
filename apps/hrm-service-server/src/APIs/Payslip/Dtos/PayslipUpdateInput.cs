namespace HrmService.APIs.Dtos;

public class PayslipUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Employee { get; set; }

    public string? Id { get; set; }

    public double? PayslipAmount { get; set; }

    public DateTime? PayslipDate { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
