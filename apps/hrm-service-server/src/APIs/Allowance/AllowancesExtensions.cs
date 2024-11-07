using HrmService.APIs.Dtos;
using HrmService.Infrastructure.Models;

namespace HrmService.APIs.Extensions;

public static class AllowancesExtensions
{
    public static Allowance ToDto(this AllowanceDbModel model)
    {
        return new Allowance
        {
            AllowanceOption = model.AllowanceOption,
            Amount = model.Amount,
            CreatedAt = model.CreatedAt,
            EmployeeName = model.EmployeeName,
            Id = model.Id,
            Title = model.Title,
            TypeField = model.TypeField,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AllowanceDbModel ToModel(
        this AllowanceUpdateInput updateDto,
        AllowanceWhereUniqueInput uniqueId
    )
    {
        var allowance = new AllowanceDbModel
        {
            Id = uniqueId.Id,
            AllowanceOption = updateDto.AllowanceOption,
            Amount = updateDto.Amount,
            EmployeeName = updateDto.EmployeeName,
            Title = updateDto.Title,
            TypeField = updateDto.TypeField
        };

        if (updateDto.CreatedAt != null)
        {
            allowance.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            allowance.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return allowance;
    }
}
