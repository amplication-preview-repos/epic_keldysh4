using HrmService.APIs.Dtos;
using HrmService.Infrastructure.Models;

namespace HrmService.APIs.Extensions;

public static class CompanyDetailsItemsExtensions
{
    public static CompanyDetails ToDto(this CompanyDetailsDbModel model)
    {
        return new CompanyDetails
        {
            Branch = model.Branch,
            CreatedAt = model.CreatedAt,
            DateOfJoining = model.DateOfJoining,
            Department = model.Department,
            Designation = model.Designation,
            EmployeeId = model.EmployeeId,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CompanyDetailsDbModel ToModel(
        this CompanyDetailsUpdateInput updateDto,
        CompanyDetailsWhereUniqueInput uniqueId
    )
    {
        var companyDetails = new CompanyDetailsDbModel
        {
            Id = uniqueId.Id,
            Branch = updateDto.Branch,
            DateOfJoining = updateDto.DateOfJoining,
            Department = updateDto.Department,
            Designation = updateDto.Designation,
            EmployeeId = updateDto.EmployeeId
        };

        if (updateDto.CreatedAt != null)
        {
            companyDetails.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            companyDetails.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return companyDetails;
    }
}
