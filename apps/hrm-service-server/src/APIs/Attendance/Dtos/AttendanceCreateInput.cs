namespace HrmService.APIs.Dtos;

public class AttendanceCreateInput
{
    public string? AttendanceType { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? Date { get; set; }

    public string? EmployeeName { get; set; }

    public string? Id { get; set; }

    public DateTime UpdatedAt { get; set; }
}
