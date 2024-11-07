using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using HrmService.APIs.Extensions;
using HrmService.Infrastructure;
using HrmService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HrmService.APIs;

public abstract class AccountDetailsItemsServiceBase : IAccountDetailsItemsService
{
    protected readonly HrmServiceDbContext _context;

    public AccountDetailsItemsServiceBase(HrmServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one AccountDetails
    /// </summary>
    public async Task<AccountDetails> CreateAccountDetails(AccountDetailsCreateInput createDto)
    {
        var accountDetails = new AccountDetailsDbModel
        {
            AccountNumber = createDto.AccountNumber,
            BankBranch = createDto.BankBranch,
            BankHolderName = createDto.BankHolderName,
            BankName = createDto.BankName,
            CreatedAt = createDto.CreatedAt,
            IdentifierCode = createDto.IdentifierCode,
            NationalIdNumber = createDto.NationalIdNumber,
            NationalIdType = createDto.NationalIdType,
            SnnitAccountName = createDto.SnnitAccountName,
            SnnitNumber = createDto.SnnitNumber,
            TinNumber = createDto.TinNumber,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            accountDetails.Id = createDto.Id;
        }

        _context.AccountDetailsItems.Add(accountDetails);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AccountDetailsDbModel>(accountDetails.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one AccountDetails
    /// </summary>
    public async Task DeleteAccountDetails(AccountDetailsWhereUniqueInput uniqueId)
    {
        var accountDetails = await _context.AccountDetailsItems.FindAsync(uniqueId.Id);
        if (accountDetails == null)
        {
            throw new NotFoundException();
        }

        _context.AccountDetailsItems.Remove(accountDetails);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many AccountDetailsItems
    /// </summary>
    public async Task<List<AccountDetails>> AccountDetailsItems(
        AccountDetailsFindManyArgs findManyArgs
    )
    {
        var accountDetailsItems = await _context
            .AccountDetailsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return accountDetailsItems.ConvertAll(accountDetails => accountDetails.ToDto());
    }

    /// <summary>
    /// Meta data about AccountDetails records
    /// </summary>
    public async Task<MetadataDto> AccountDetailsItemsMeta(AccountDetailsFindManyArgs findManyArgs)
    {
        var count = await _context.AccountDetailsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one AccountDetails
    /// </summary>
    public async Task<AccountDetails> AccountDetails(AccountDetailsWhereUniqueInput uniqueId)
    {
        var accountDetailsItems = await this.AccountDetailsItems(
            new AccountDetailsFindManyArgs
            {
                Where = new AccountDetailsWhereInput { Id = uniqueId.Id }
            }
        );
        var accountDetails = accountDetailsItems.FirstOrDefault();
        if (accountDetails == null)
        {
            throw new NotFoundException();
        }

        return accountDetails;
    }

    /// <summary>
    /// Update one AccountDetails
    /// </summary>
    public async Task UpdateAccountDetails(
        AccountDetailsWhereUniqueInput uniqueId,
        AccountDetailsUpdateInput updateDto
    )
    {
        var accountDetails = updateDto.ToModel(uniqueId);

        _context.Entry(accountDetails).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.AccountDetailsItems.Any(e => e.Id == accountDetails.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
