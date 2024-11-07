using HrmService.APIs.Common;
using HrmService.APIs.Dtos;

namespace HrmService.APIs;

public interface ILeaveManagementsService
{
    /// <summary>
    /// Create one LeaveManagement
    /// </summary>
    public Task<LeaveManagement> CreateLeaveManagement(LeaveManagementCreateInput leavemanagement);

    /// <summary>
    /// Delete one LeaveManagement
    /// </summary>
    public Task DeleteLeaveManagement(LeaveManagementWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many LeaveManagements
    /// </summary>
    public Task<List<LeaveManagement>> LeaveManagements(LeaveManagementFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about LeaveManagement records
    /// </summary>
    public Task<MetadataDto> LeaveManagementsMeta(LeaveManagementFindManyArgs findManyArgs);

    /// <summary>
    /// Get one LeaveManagement
    /// </summary>
    public Task<LeaveManagement> LeaveManagement(LeaveManagementWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one LeaveManagement
    /// </summary>
    public Task UpdateLeaveManagement(
        LeaveManagementWhereUniqueInput uniqueId,
        LeaveManagementUpdateInput updateDto
    );
}
