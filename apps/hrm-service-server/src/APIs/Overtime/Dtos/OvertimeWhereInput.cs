namespace HrmService.APIs.Dtos;

public class OvertimeWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? EmployeeName { get; set; }

    public int? Hours { get; set; }

    public string? Id { get; set; }

    public int? NumberOfDays { get; set; }

    public string? OvertimeTitle { get; set; }

    public double? Rate { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
