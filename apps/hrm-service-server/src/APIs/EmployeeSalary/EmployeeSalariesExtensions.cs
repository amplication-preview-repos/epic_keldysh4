using HrmService.APIs.Dtos;
using HrmService.Infrastructure.Models;

namespace HrmService.APIs.Extensions;

public static class EmployeeSalariesExtensions
{
    public static EmployeeSalary ToDto(this EmployeeSalaryDbModel model)
    {
        return new EmployeeSalary
        {
            Account = model.Account,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            PayslipType = model.PayslipType,
            Salary = model.Salary,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static EmployeeSalaryDbModel ToModel(
        this EmployeeSalaryUpdateInput updateDto,
        EmployeeSalaryWhereUniqueInput uniqueId
    )
    {
        var employeeSalary = new EmployeeSalaryDbModel
        {
            Id = uniqueId.Id,
            Account = updateDto.Account,
            PayslipType = updateDto.PayslipType,
            Salary = updateDto.Salary
        };

        if (updateDto.CreatedAt != null)
        {
            employeeSalary.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            employeeSalary.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return employeeSalary;
    }
}
