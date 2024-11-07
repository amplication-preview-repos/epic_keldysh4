using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using HrmService.APIs.Extensions;
using HrmService.Infrastructure;
using HrmService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HrmService.APIs;

public abstract class CommissionsServiceBase : ICommissionsService
{
    protected readonly HrmServiceDbContext _context;

    public CommissionsServiceBase(HrmServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Commission
    /// </summary>
    public async Task<Commission> CreateCommission(CommissionCreateInput createDto)
    {
        var commission = new CommissionDbModel
        {
            Amount = createDto.Amount,
            CreatedAt = createDto.CreatedAt,
            EmployeeName = createDto.EmployeeName,
            Title = createDto.Title,
            TypeField = createDto.TypeField,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            commission.Id = createDto.Id;
        }

        _context.Commissions.Add(commission);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CommissionDbModel>(commission.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Commission
    /// </summary>
    public async Task DeleteCommission(CommissionWhereUniqueInput uniqueId)
    {
        var commission = await _context.Commissions.FindAsync(uniqueId.Id);
        if (commission == null)
        {
            throw new NotFoundException();
        }

        _context.Commissions.Remove(commission);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Commissions
    /// </summary>
    public async Task<List<Commission>> Commissions(CommissionFindManyArgs findManyArgs)
    {
        var commissions = await _context
            .Commissions.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return commissions.ConvertAll(commission => commission.ToDto());
    }

    /// <summary>
    /// Meta data about Commission records
    /// </summary>
    public async Task<MetadataDto> CommissionsMeta(CommissionFindManyArgs findManyArgs)
    {
        var count = await _context.Commissions.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Commission
    /// </summary>
    public async Task<Commission> Commission(CommissionWhereUniqueInput uniqueId)
    {
        var commissions = await this.Commissions(
            new CommissionFindManyArgs { Where = new CommissionWhereInput { Id = uniqueId.Id } }
        );
        var commission = commissions.FirstOrDefault();
        if (commission == null)
        {
            throw new NotFoundException();
        }

        return commission;
    }

    /// <summary>
    /// Update one Commission
    /// </summary>
    public async Task UpdateCommission(
        CommissionWhereUniqueInput uniqueId,
        CommissionUpdateInput updateDto
    )
    {
        var commission = updateDto.ToModel(uniqueId);

        _context.Entry(commission).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Commissions.Any(e => e.Id == commission.Id))
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
