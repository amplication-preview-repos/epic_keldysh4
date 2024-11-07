using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrmService.Infrastructure.Models;

[Table("EmployeeSalaries")]
public class EmployeeSalaryDbModel
{
    [StringLength(1000)]
    public string? Account { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? PayslipType { get; set; }

    [Range(-999999999, 999999999)]
    public double? Salary { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
