using HrmService.APIs.Dtos;
using HrmService.Infrastructure.Models;

namespace HrmService.APIs.Extensions;

public static class PayslipsExtensions
{
    public static Payslip ToDto(this PayslipDbModel model)
    {
        return new Payslip
        {
            CreatedAt = model.CreatedAt,
            Employee = model.Employee,
            Id = model.Id,
            PayslipAmount = model.PayslipAmount,
            PayslipDate = model.PayslipDate,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PayslipDbModel ToModel(
        this PayslipUpdateInput updateDto,
        PayslipWhereUniqueInput uniqueId
    )
    {
        var payslip = new PayslipDbModel
        {
            Id = uniqueId.Id,
            Employee = updateDto.Employee,
            PayslipAmount = updateDto.PayslipAmount,
            PayslipDate = updateDto.PayslipDate
        };

        if (updateDto.CreatedAt != null)
        {
            payslip.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            payslip.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return payslip;
    }
}
