using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrmService.Infrastructure.Models;

[Table("Overtimes")]
public class OvertimeDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? EmployeeName { get; set; }

    [Range(-999999999, 999999999)]
    public int? Hours { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public int? NumberOfDays { get; set; }

    [StringLength(1000)]
    public string? OvertimeTitle { get; set; }

    [Range(-999999999, 999999999)]
    public double? Rate { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
