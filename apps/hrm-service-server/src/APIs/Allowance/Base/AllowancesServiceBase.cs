using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using HrmService.APIs.Extensions;
using HrmService.Infrastructure;
using HrmService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HrmService.APIs;

public abstract class AllowancesServiceBase : IAllowancesService
{
    protected readonly HrmServiceDbContext _context;

    public AllowancesServiceBase(HrmServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Allowance
    /// </summary>
    public async Task<Allowance> CreateAllowance(AllowanceCreateInput createDto)
    {
        var allowance = new AllowanceDbModel
        {
            AllowanceOption = createDto.AllowanceOption,
            Amount = createDto.Amount,
            CreatedAt = createDto.CreatedAt,
            EmployeeName = createDto.EmployeeName,
            Title = createDto.Title,
            TypeField = createDto.TypeField,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            allowance.Id = createDto.Id;
        }

        _context.Allowances.Add(allowance);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AllowanceDbModel>(allowance.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Allowance
    /// </summary>
    public async Task DeleteAllowance(AllowanceWhereUniqueInput uniqueId)
    {
        var allowance = await _context.Allowances.FindAsync(uniqueId.Id);
        if (allowance == null)
        {
            throw new NotFoundException();
        }

        _context.Allowances.Remove(allowance);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Allowances
    /// </summary>
    public async Task<List<Allowance>> Allowances(AllowanceFindManyArgs findManyArgs)
    {
        var allowances = await _context
            .Allowances.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return allowances.ConvertAll(allowance => allowance.ToDto());
    }

    /// <summary>
    /// Meta data about Allowance records
    /// </summary>
    public async Task<MetadataDto> AllowancesMeta(AllowanceFindManyArgs findManyArgs)
    {
        var count = await _context.Allowances.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Allowance
    /// </summary>
    public async Task<Allowance> Allowance(AllowanceWhereUniqueInput uniqueId)
    {
        var allowances = await this.Allowances(
            new AllowanceFindManyArgs { Where = new AllowanceWhereInput { Id = uniqueId.Id } }
        );
        var allowance = allowances.FirstOrDefault();
        if (allowance == null)
        {
            throw new NotFoundException();
        }

        return allowance;
    }

    /// <summary>
    /// Update one Allowance
    /// </summary>
    public async Task UpdateAllowance(
        AllowanceWhereUniqueInput uniqueId,
        AllowanceUpdateInput updateDto
    )
    {
        var allowance = updateDto.ToModel(uniqueId);

        _context.Entry(allowance).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Allowances.Any(e => e.Id == allowance.Id))
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
