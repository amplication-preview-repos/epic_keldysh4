using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrmService.Infrastructure.Models;

[Table("CompanyDetails")]
public class CompanyDetailsDbModel
{
    [StringLength(1000)]
    public string? Branch { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public DateTime? DateOfJoining { get; set; }

    [StringLength(1000)]
    public string? Department { get; set; }

    [StringLength(1000)]
    public string? Designation { get; set; }

    [StringLength(1000)]
    public string? EmployeeId { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
