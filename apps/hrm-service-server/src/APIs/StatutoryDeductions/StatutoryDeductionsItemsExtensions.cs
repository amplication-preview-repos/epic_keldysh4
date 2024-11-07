using HrmService.APIs.Dtos;
using HrmService.Infrastructure.Models;

namespace HrmService.APIs.Extensions;

public static class StatutoryDeductionsItemsExtensions
{
    public static StatutoryDeductions ToDto(this StatutoryDeductionsDbModel model)
    {
        return new StatutoryDeductions
        {
            Amount = model.Amount,
            CreatedAt = model.CreatedAt,
            DeductionOption = model.DeductionOption,
            EmployeeName = model.EmployeeName,
            Id = model.Id,
            Title = model.Title,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static StatutoryDeductionsDbModel ToModel(
        this StatutoryDeductionsUpdateInput updateDto,
        StatutoryDeductionsWhereUniqueInput uniqueId
    )
    {
        var statutoryDeductions = new StatutoryDeductionsDbModel
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            DeductionOption = updateDto.DeductionOption,
            EmployeeName = updateDto.EmployeeName,
            Title = updateDto.Title
        };

        if (updateDto.CreatedAt != null)
        {
            statutoryDeductions.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            statutoryDeductions.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return statutoryDeductions;
    }
}
