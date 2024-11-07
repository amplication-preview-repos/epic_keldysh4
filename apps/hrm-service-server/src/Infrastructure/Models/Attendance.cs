using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrmService.Infrastructure.Models;

[Table("Attendances")]
public class AttendanceDbModel
{
    [StringLength(1000)]
    public string? AttendanceType { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public DateTime? Date { get; set; }

    [StringLength(1000)]
    public string? EmployeeName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
