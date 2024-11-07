using HrmService.APIs.Common;
using HrmService.APIs.Dtos;

namespace HrmService.APIs;

public interface IAccountDetailsItemsService
{
    /// <summary>
    /// Create one AccountDetails
    /// </summary>
    public Task<AccountDetails> CreateAccountDetails(AccountDetailsCreateInput accountdetails);

    /// <summary>
    /// Delete one AccountDetails
    /// </summary>
    public Task DeleteAccountDetails(AccountDetailsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many AccountDetailsItems
    /// </summary>
    public Task<List<AccountDetails>> AccountDetailsItems(AccountDetailsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about AccountDetails records
    /// </summary>
    public Task<MetadataDto> AccountDetailsItemsMeta(AccountDetailsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one AccountDetails
    /// </summary>
    public Task<AccountDetails> AccountDetails(AccountDetailsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one AccountDetails
    /// </summary>
    public Task UpdateAccountDetails(
        AccountDetailsWhereUniqueInput uniqueId,
        AccountDetailsUpdateInput updateDto
    );
}
