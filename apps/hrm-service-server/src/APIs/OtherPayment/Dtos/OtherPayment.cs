namespace HrmService.APIs.Dtos;

public class OtherPayment
{
    public double? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Employee { get; set; }

    public string Id { get; set; }

    public string? Title { get; set; }

    public string? TypeField { get; set; }

    public DateTime UpdatedAt { get; set; }
}
