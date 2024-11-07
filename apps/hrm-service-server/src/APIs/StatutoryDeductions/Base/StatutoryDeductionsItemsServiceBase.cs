using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using HrmService.APIs.Extensions;
using HrmService.Infrastructure;
using HrmService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HrmService.APIs;

public abstract class StatutoryDeductionsItemsServiceBase : IStatutoryDeductionsItemsService
{
    protected readonly HrmServiceDbContext _context;

    public StatutoryDeductionsItemsServiceBase(HrmServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one StatutoryDeductions
    /// </summary>
    public async Task<StatutoryDeductions> CreateStatutoryDeductions(
        StatutoryDeductionsCreateInput createDto
    )
    {
        var statutoryDeductions = new StatutoryDeductionsDbModel
        {
            Amount = createDto.Amount,
            CreatedAt = createDto.CreatedAt,
            DeductionOption = createDto.DeductionOption,
            EmployeeName = createDto.EmployeeName,
            Title = createDto.Title,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            statutoryDeductions.Id = createDto.Id;
        }

        _context.StatutoryDeductionsItems.Add(statutoryDeductions);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<StatutoryDeductionsDbModel>(statutoryDeductions.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one StatutoryDeductions
    /// </summary>
    public async Task DeleteStatutoryDeductions(StatutoryDeductionsWhereUniqueInput uniqueId)
    {
        var statutoryDeductions = await _context.StatutoryDeductionsItems.FindAsync(uniqueId.Id);
        if (statutoryDeductions == null)
        {
            throw new NotFoundException();
        }

        _context.StatutoryDeductionsItems.Remove(statutoryDeductions);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many StatutoryDeductionsItems
    /// </summary>
    public async Task<List<StatutoryDeductions>> StatutoryDeductionsItems(
        StatutoryDeductionsFindManyArgs findManyArgs
    )
    {
        var statutoryDeductionsItems = await _context
            .StatutoryDeductionsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return statutoryDeductionsItems.ConvertAll(statutoryDeductions =>
            statutoryDeductions.ToDto()
        );
    }

    /// <summary>
    /// Meta data about StatutoryDeductions records
    /// </summary>
    public async Task<MetadataDto> StatutoryDeductionsItemsMeta(
        StatutoryDeductionsFindManyArgs findManyArgs
    )
    {
        var count = await _context
            .StatutoryDeductionsItems.ApplyWhere(findManyArgs.Where)
            .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one StatutoryDeductions
    /// </summary>
    public async Task<StatutoryDeductions> StatutoryDeductions(
        StatutoryDeductionsWhereUniqueInput uniqueId
    )
    {
        var statutoryDeductionsItems = await this.StatutoryDeductionsItems(
            new StatutoryDeductionsFindManyArgs
            {
                Where = new StatutoryDeductionsWhereInput { Id = uniqueId.Id }
            }
        );
        var statutoryDeductions = statutoryDeductionsItems.FirstOrDefault();
        if (statutoryDeductions == null)
        {
            throw new NotFoundException();
        }

        return statutoryDeductions;
    }

    /// <summary>
    /// Update one StatutoryDeductions
    /// </summary>
    public async Task UpdateStatutoryDeductions(
        StatutoryDeductionsWhereUniqueInput uniqueId,
        StatutoryDeductionsUpdateInput updateDto
    )
    {
        var statutoryDeductions = updateDto.ToModel(uniqueId);

        _context.Entry(statutoryDeductions).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.StatutoryDeductionsItems.Any(e => e.Id == statutoryDeductions.Id))
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
