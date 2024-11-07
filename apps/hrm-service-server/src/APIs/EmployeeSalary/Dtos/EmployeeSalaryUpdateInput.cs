namespace HrmService.APIs.Dtos;

public class EmployeeSalaryUpdateInput
{
    public string? Account { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? PayslipType { get; set; }

    public double? Salary { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
