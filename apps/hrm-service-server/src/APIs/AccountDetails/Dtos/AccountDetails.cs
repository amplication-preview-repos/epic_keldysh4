using HrmService.Core.Enums;

namespace HrmService.APIs.Dtos;

public class AccountDetails
{
    public string? AccountNumber { get; set; }

    public string? BankBranch { get; set; }

    public string? BankHolderName { get; set; }

    public string? BankName { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Id { get; set; }

    public string? IdentifierCode { get; set; }

    public string? NationalIdNumber { get; set; }

    public NationalIdTypeEnum? NationalIdType { get; set; }

    public string? SnnitAccountName { get; set; }

    public string? SnnitNumber { get; set; }

    public string? TinNumber { get; set; }

    public DateTime UpdatedAt { get; set; }
}
