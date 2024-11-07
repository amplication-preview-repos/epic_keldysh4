using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrmService.Infrastructure.Models;

[Table("Payslips")]
public class PayslipDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Employee { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public double? PayslipAmount { get; set; }

    public DateTime? PayslipDate { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
