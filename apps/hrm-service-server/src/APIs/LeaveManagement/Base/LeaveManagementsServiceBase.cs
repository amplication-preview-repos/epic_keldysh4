using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using HrmService.APIs.Extensions;
using HrmService.Infrastructure;
using HrmService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HrmService.APIs;

public abstract class LeaveManagementsServiceBase : ILeaveManagementsService
{
    protected readonly HrmServiceDbContext _context;

    public LeaveManagementsServiceBase(HrmServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one LeaveManagement
    /// </summary>
    public async Task<LeaveManagement> CreateLeaveManagement(LeaveManagementCreateInput createDto)
    {
        var leaveManagement = new LeaveManagementDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Duration = createDto.Duration,
            LeaveType = createDto.LeaveType,
            Status = createDto.Status,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            leaveManagement.Id = createDto.Id;
        }

        _context.LeaveManagements.Add(leaveManagement);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<LeaveManagementDbModel>(leaveManagement.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one LeaveManagement
    /// </summary>
    public async Task DeleteLeaveManagement(LeaveManagementWhereUniqueInput uniqueId)
    {
        var leaveManagement = await _context.LeaveManagements.FindAsync(uniqueId.Id);
        if (leaveManagement == null)
        {
            throw new NotFoundException();
        }

        _context.LeaveManagements.Remove(leaveManagement);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many LeaveManagements
    /// </summary>
    public async Task<List<LeaveManagement>> LeaveManagements(
        LeaveManagementFindManyArgs findManyArgs
    )
    {
        var leaveManagements = await _context
            .LeaveManagements.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return leaveManagements.ConvertAll(leaveManagement => leaveManagement.ToDto());
    }

    /// <summary>
    /// Meta data about LeaveManagement records
    /// </summary>
    public async Task<MetadataDto> LeaveManagementsMeta(LeaveManagementFindManyArgs findManyArgs)
    {
        var count = await _context.LeaveManagements.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one LeaveManagement
    /// </summary>
    public async Task<LeaveManagement> LeaveManagement(LeaveManagementWhereUniqueInput uniqueId)
    {
        var leaveManagements = await this.LeaveManagements(
            new LeaveManagementFindManyArgs
            {
                Where = new LeaveManagementWhereInput { Id = uniqueId.Id }
            }
        );
        var leaveManagement = leaveManagements.FirstOrDefault();
        if (leaveManagement == null)
        {
            throw new NotFoundException();
        }

        return leaveManagement;
    }

    /// <summary>
    /// Update one LeaveManagement
    /// </summary>
    public async Task UpdateLeaveManagement(
        LeaveManagementWhereUniqueInput uniqueId,
        LeaveManagementUpdateInput updateDto
    )
    {
        var leaveManagement = updateDto.ToModel(uniqueId);

        _context.Entry(leaveManagement).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.LeaveManagements.Any(e => e.Id == leaveManagement.Id))
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
