using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using HrmService.APIs.Extensions;
using HrmService.Infrastructure;
using HrmService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HrmService.APIs;

public abstract class EmployeeSalariesServiceBase : IEmployeeSalariesService
{
    protected readonly HrmServiceDbContext _context;

    public EmployeeSalariesServiceBase(HrmServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one EmployeeSalary
    /// </summary>
    public async Task<EmployeeSalary> CreateEmployeeSalary(EmployeeSalaryCreateInput createDto)
    {
        var employeeSalary = new EmployeeSalaryDbModel
        {
            Account = createDto.Account,
            CreatedAt = createDto.CreatedAt,
            PayslipType = createDto.PayslipType,
            Salary = createDto.Salary,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            employeeSalary.Id = createDto.Id;
        }

        _context.EmployeeSalaries.Add(employeeSalary);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<EmployeeSalaryDbModel>(employeeSalary.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one EmployeeSalary
    /// </summary>
    public async Task DeleteEmployeeSalary(EmployeeSalaryWhereUniqueInput uniqueId)
    {
        var employeeSalary = await _context.EmployeeSalaries.FindAsync(uniqueId.Id);
        if (employeeSalary == null)
        {
            throw new NotFoundException();
        }

        _context.EmployeeSalaries.Remove(employeeSalary);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many EmployeeSalaries
    /// </summary>
    public async Task<List<EmployeeSalary>> EmployeeSalaries(
        EmployeeSalaryFindManyArgs findManyArgs
    )
    {
        var employeeSalaries = await _context
            .EmployeeSalaries.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return employeeSalaries.ConvertAll(employeeSalary => employeeSalary.ToDto());
    }

    /// <summary>
    /// Meta data about EmployeeSalary records
    /// </summary>
    public async Task<MetadataDto> EmployeeSalariesMeta(EmployeeSalaryFindManyArgs findManyArgs)
    {
        var count = await _context.EmployeeSalaries.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one EmployeeSalary
    /// </summary>
    public async Task<EmployeeSalary> EmployeeSalary(EmployeeSalaryWhereUniqueInput uniqueId)
    {
        var employeeSalaries = await this.EmployeeSalaries(
            new EmployeeSalaryFindManyArgs
            {
                Where = new EmployeeSalaryWhereInput { Id = uniqueId.Id }
            }
        );
        var employeeSalary = employeeSalaries.FirstOrDefault();
        if (employeeSalary == null)
        {
            throw new NotFoundException();
        }

        return employeeSalary;
    }

    /// <summary>
    /// Update one EmployeeSalary
    /// </summary>
    public async Task UpdateEmployeeSalary(
        EmployeeSalaryWhereUniqueInput uniqueId,
        EmployeeSalaryUpdateInput updateDto
    )
    {
        var employeeSalary = updateDto.ToModel(uniqueId);

        _context.Entry(employeeSalary).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.EmployeeSalaries.Any(e => e.Id == employeeSalary.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
