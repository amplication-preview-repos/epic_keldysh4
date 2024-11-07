using HrmService.APIs.Dtos;
using HrmService.Infrastructure.Models;

namespace HrmService.APIs.Extensions;

public static class OtherPaymentsExtensions
{
    public static OtherPayment ToDto(this OtherPaymentDbModel model)
    {
        return new OtherPayment
        {
            Amount = model.Amount,
            CreatedAt = model.CreatedAt,
            Employee = model.Employee,
            Id = model.Id,
            Title = model.Title,
            TypeField = model.TypeField,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static OtherPaymentDbModel ToModel(
        this OtherPaymentUpdateInput updateDto,
        OtherPaymentWhereUniqueInput uniqueId
    )
    {
        var otherPayment = new OtherPaymentDbModel
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            Employee = updateDto.Employee,
            Title = updateDto.Title,
            TypeField = updateDto.TypeField
        };

        if (updateDto.CreatedAt != null)
        {
            otherPayment.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            otherPayment.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return otherPayment;
    }
}
