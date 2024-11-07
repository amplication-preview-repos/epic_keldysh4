using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HrmService.Core.Enums;

namespace HrmService.Infrastructure.Models;

[Table("StatutoryDeductions")]
public class StatutoryDeductionsDbModel
{
    [Range(-999999999, 999999999)]
    public double? Amount { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public DeductionOptionEnum? DeductionOption { get; set; }

    [StringLength(1000)]
    public string? EmployeeName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Title { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
