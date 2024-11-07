using HrmService.APIs.Dtos;
using HrmService.Infrastructure.Models;

namespace HrmService.APIs.Extensions;

public static class OvertimesExtensions
{
    public static Overtime ToDto(this OvertimeDbModel model)
    {
        return new Overtime
        {
            CreatedAt = model.CreatedAt,
            EmployeeName = model.EmployeeName,
            Hours = model.Hours,
            Id = model.Id,
            NumberOfDays = model.NumberOfDays,
            OvertimeTitle = model.OvertimeTitle,
            Rate = model.Rate,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static OvertimeDbModel ToModel(
        this OvertimeUpdateInput updateDto,
        OvertimeWhereUniqueInput uniqueId
    )
    {
        var overtime = new OvertimeDbModel
        {
            Id = uniqueId.Id,
            EmployeeName = updateDto.EmployeeName,
            Hours = updateDto.Hours,
            NumberOfDays = updateDto.NumberOfDays,
            OvertimeTitle = updateDto.OvertimeTitle,
            Rate = updateDto.Rate
        };

        if (updateDto.CreatedAt != null)
        {
            overtime.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            overtime.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return overtime;
    }
}
