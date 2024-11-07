using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrmService.Infrastructure.Models;

[Table("Documents")]
public class DocumentsDbModel
{
    public string? Certificates { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? Cv { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public string? Photo { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
