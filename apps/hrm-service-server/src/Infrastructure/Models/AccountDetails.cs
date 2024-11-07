using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HrmService.Core.Enums;

namespace HrmService.Infrastructure.Models;

[Table("AccountDetails")]
public class AccountDetailsDbModel
{
    [StringLength(1000)]
    public string? AccountNumber { get; set; }

    [StringLength(1000)]
    public string? BankBranch { get; set; }

    [StringLength(1000)]
    public string? BankHolderName { get; set; }

    [StringLength(1000)]
    public string? BankName { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? IdentifierCode { get; set; }

    [StringLength(1000)]
    public string? NationalIdNumber { get; set; }

    public NationalIdTypeEnum? NationalIdType { get; set; }

    [StringLength(1000)]
    public string? SnnitAccountName { get; set; }

    [StringLength(1000)]
    public string? SnnitNumber { get; set; }

    [StringLength(1000)]
    public string? TinNumber { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
