using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using HrmService.APIs.Extensions;
using HrmService.Infrastructure;
using HrmService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HrmService.APIs;

public abstract class OvertimesServiceBase : IOvertimesService
{
    protected readonly HrmServiceDbContext _context;

    public OvertimesServiceBase(HrmServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Overtime
    /// </summary>
    public async Task<Overtime> CreateOvertime(OvertimeCreateInput createDto)
    {
        var overtime = new OvertimeDbModel
        {
            CreatedAt = createDto.CreatedAt,
            EmployeeName = createDto.EmployeeName,
            Hours = createDto.Hours,
            NumberOfDays = createDto.NumberOfDays,
            OvertimeTitle = createDto.OvertimeTitle,
            Rate = createDto.Rate,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            overtime.Id = createDto.Id;
        }

        _context.Overtimes.Add(overtime);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<OvertimeDbModel>(overtime.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Overtime
    /// </summary>
    public async Task DeleteOvertime(OvertimeWhereUniqueInput uniqueId)
    {
        var overtime = await _context.Overtimes.FindAsync(uniqueId.Id);
        if (overtime == null)
        {
            throw new NotFoundException();
        }

        _context.Overtimes.Remove(overtime);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Overtimes
    /// </summary>
    public async Task<List<Overtime>> Overtimes(OvertimeFindManyArgs findManyArgs)
    {
        var overtimes = await _context
            .Overtimes.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return overtimes.ConvertAll(overtime => overtime.ToDto());
    }

    /// <summary>
    /// Meta data about Overtime records
    /// </summary>
    public async Task<MetadataDto> OvertimesMeta(OvertimeFindManyArgs findManyArgs)
    {
        var count = await _context.Overtimes.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Overtime
    /// </summary>
    public async Task<Overtime> Overtime(OvertimeWhereUniqueInput uniqueId)
    {
        var overtimes = await this.Overtimes(
            new OvertimeFindManyArgs { Where = new OvertimeWhereInput { Id = uniqueId.Id } }
        );
        var overtime = overtimes.FirstOrDefault();
        if (overtime == null)
        {
            throw new NotFoundException();
        }

        return overtime;
    }

    /// <summary>
    /// Update one Overtime
    /// </summary>
    public async Task UpdateOvertime(
        OvertimeWhereUniqueInput uniqueId,
        OvertimeUpdateInput updateDto
    )
    {
        var overtime = updateDto.ToModel(uniqueId);

        _context.Entry(overtime).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Overtimes.Any(e => e.Id == overtime.Id))
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
