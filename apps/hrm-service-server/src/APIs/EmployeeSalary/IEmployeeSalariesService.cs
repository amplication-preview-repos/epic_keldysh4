using HrmService.APIs.Common;
using HrmService.APIs.Dtos;

namespace HrmService.APIs;

public interface IEmployeeSalariesService
{
    /// <summary>
    /// Create one EmployeeSalary
    /// </summary>
    public Task<EmployeeSalary> CreateEmployeeSalary(EmployeeSalaryCreateInput employeesalary);

    /// <summary>
    /// Delete one EmployeeSalary
    /// </summary>
    public Task DeleteEmployeeSalary(EmployeeSalaryWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many EmployeeSalaries
    /// </summary>
    public Task<List<EmployeeSalary>> EmployeeSalaries(EmployeeSalaryFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about EmployeeSalary records
    /// </summary>
    public Task<MetadataDto> EmployeeSalariesMeta(EmployeeSalaryFindManyArgs findManyArgs);

    /// <summary>
    /// Get one EmployeeSalary
    /// </summary>
    public Task<EmployeeSalary> EmployeeSalary(EmployeeSalaryWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one EmployeeSalary
    /// </summary>
    public Task UpdateEmployeeSalary(
        EmployeeSalaryWhereUniqueInput uniqueId,
        EmployeeSalaryUpdateInput updateDto
    );
}
