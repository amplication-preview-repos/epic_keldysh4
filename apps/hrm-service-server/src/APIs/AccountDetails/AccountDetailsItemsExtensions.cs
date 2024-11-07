using HrmService.APIs.Dtos;
using HrmService.Infrastructure.Models;

namespace HrmService.APIs.Extensions;

public static class AccountDetailsItemsExtensions
{
    public static AccountDetails ToDto(this AccountDetailsDbModel model)
    {
        return new AccountDetails
        {
            AccountNumber = model.AccountNumber,
            BankBranch = model.BankBranch,
            BankHolderName = model.BankHolderName,
            BankName = model.BankName,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            IdentifierCode = model.IdentifierCode,
            NationalIdNumber = model.NationalIdNumber,
            NationalIdType = model.NationalIdType,
            SnnitAccountName = model.SnnitAccountName,
            SnnitNumber = model.SnnitNumber,
            TinNumber = model.TinNumber,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AccountDetailsDbModel ToModel(
        this AccountDetailsUpdateInput updateDto,
        AccountDetailsWhereUniqueInput uniqueId
    )
    {
        var accountDetails = new AccountDetailsDbModel
        {
            Id = uniqueId.Id,
            AccountNumber = updateDto.AccountNumber,
            BankBranch = updateDto.BankBranch,
            BankHolderName = updateDto.BankHolderName,
            BankName = updateDto.BankName,
            IdentifierCode = updateDto.IdentifierCode,
            NationalIdNumber = updateDto.NationalIdNumber,
            NationalIdType = updateDto.NationalIdType,
            SnnitAccountName = updateDto.SnnitAccountName,
            SnnitNumber = updateDto.SnnitNumber,
            TinNumber = updateDto.TinNumber
        };

        if (updateDto.CreatedAt != null)
        {
            accountDetails.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            accountDetails.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return accountDetails;
    }
}
