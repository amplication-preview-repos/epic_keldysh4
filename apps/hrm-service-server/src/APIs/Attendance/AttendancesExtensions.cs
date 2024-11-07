using HrmService.APIs.Dtos;
using HrmService.Infrastructure.Models;

namespace HrmService.APIs.Extensions;

public static class AttendancesExtensions
{
    public static Attendance ToDto(this AttendanceDbModel model)
    {
        return new Attendance
        {
            AttendanceType = model.AttendanceType,
            CreatedAt = model.CreatedAt,
            Date = model.Date,
            EmployeeName = model.EmployeeName,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AttendanceDbModel ToModel(
        this AttendanceUpdateInput updateDto,
        AttendanceWhereUniqueInput uniqueId
    )
    {
        var attendance = new AttendanceDbModel
        {
            Id = uniqueId.Id,
            AttendanceType = updateDto.AttendanceType,
            Date = updateDto.Date,
            EmployeeName = updateDto.EmployeeName
        };

        if (updateDto.CreatedAt != null)
        {
            attendance.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            attendance.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return attendance;
    }
}
