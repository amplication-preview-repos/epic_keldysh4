using HrmService.APIs.Dtos;
using HrmService.Infrastructure.Models;

namespace HrmService.APIs.Extensions;

public static class LeaveManagementsExtensions
{
    public static LeaveManagement ToDto(this LeaveManagementDbModel model)
    {
        return new LeaveManagement
        {
            CreatedAt = model.CreatedAt,
            Duration = model.Duration,
            Id = model.Id,
            LeaveType = model.LeaveType,
            Status = model.Status,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static LeaveManagementDbModel ToModel(
        this LeaveManagementUpdateInput updateDto,
        LeaveManagementWhereUniqueInput uniqueId
    )
    {
        var leaveManagement = new LeaveManagementDbModel
        {
            Id = uniqueId.Id,
            Duration = updateDto.Duration,
            LeaveType = updateDto.LeaveType,
            Status = updateDto.Status
        };

        if (updateDto.CreatedAt != null)
        {
            leaveManagement.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            leaveManagement.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return leaveManagement;
    }
}
