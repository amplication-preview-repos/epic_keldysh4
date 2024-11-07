using HrmService.APIs.Dtos;
using HrmService.Infrastructure.Models;

namespace HrmService.APIs.Extensions;

public static class EmployeesExtensions
{
    public static Employee ToDto(this EmployeeDbModel model)
    {
        return new Employee
        {
            Address = model.Address,
            CreatedAt = model.CreatedAt,
            Dob = model.Dob,
            Email = model.Email,
            Gender = model.Gender,
            Id = model.Id,
            Name = model.Name,
            Password = model.Password,
            Phone = model.Phone,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static EmployeeDbModel ToModel(
        this EmployeeUpdateInput updateDto,
        EmployeeWhereUniqueInput uniqueId
    )
    {
        var employee = new EmployeeDbModel
        {
            Id = uniqueId.Id,
            Address = updateDto.Address,
            Dob = updateDto.Dob,
            Email = updateDto.Email,
            Gender = updateDto.Gender,
            Name = updateDto.Name,
            Password = updateDto.Password,
            Phone = updateDto.Phone
        };

        if (updateDto.CreatedAt != null)
        {
            employee.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            employee.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return employee;
    }
}
