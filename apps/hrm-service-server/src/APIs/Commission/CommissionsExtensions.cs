using HrmService.APIs.Dtos;
using HrmService.Infrastructure.Models;

namespace HrmService.APIs.Extensions;

public static class CommissionsExtensions
{
    public static Commission ToDto(this CommissionDbModel model)
    {
        return new Commission
        {
            Amount = model.Amount,
            CreatedAt = model.CreatedAt,
            EmployeeName = model.EmployeeName,
            Id = model.Id,
            Title = model.Title,
            TypeField = model.TypeField,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CommissionDbModel ToModel(
        this CommissionUpdateInput updateDto,
        CommissionWhereUniqueInput uniqueId
    )
    {
        var commission = new CommissionDbModel
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            EmployeeName = updateDto.EmployeeName,
            Title = updateDto.Title,
            TypeField = updateDto.TypeField
        };

        if (updateDto.CreatedAt != null)
        {
            commission.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            commission.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return commission;
    }
}
