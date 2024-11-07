using HrmService.APIs.Dtos;
using HrmService.Infrastructure.Models;

namespace HrmService.APIs.Extensions;

public static class LoansExtensions
{
    public static Loan ToDto(this LoanDbModel model)
    {
        return new Loan
        {
            Amount = model.Amount,
            CreatedAt = model.CreatedAt,
            Employee = model.Employee,
            Id = model.Id,
            LoanAmount = model.LoanAmount,
            LoanOption = model.LoanOption,
            Title = model.Title,
            TypeField = model.TypeField,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static LoanDbModel ToModel(this LoanUpdateInput updateDto, LoanWhereUniqueInput uniqueId)
    {
        var loan = new LoanDbModel
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            Employee = updateDto.Employee,
            LoanAmount = updateDto.LoanAmount,
            LoanOption = updateDto.LoanOption,
            Title = updateDto.Title,
            TypeField = updateDto.TypeField
        };

        if (updateDto.CreatedAt != null)
        {
            loan.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            loan.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return loan;
    }
}
