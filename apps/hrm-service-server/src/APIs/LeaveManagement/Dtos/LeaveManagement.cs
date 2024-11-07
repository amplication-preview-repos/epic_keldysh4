namespace HrmService.APIs.Dtos;

public class LeaveManagement
{
    public DateTime CreatedAt { get; set; }

    public int? Duration { get; set; }

    public string Id { get; set; }

    public string? LeaveType { get; set; }

    public string? Status { get; set; }

    public DateTime UpdatedAt { get; set; }
}
