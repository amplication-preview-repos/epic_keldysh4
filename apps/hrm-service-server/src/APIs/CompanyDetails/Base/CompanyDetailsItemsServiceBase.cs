using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using HrmService.APIs.Extensions;
using HrmService.Infrastructure;
using HrmService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HrmService.APIs;

public abstract class CompanyDetailsItemsServiceBase : ICompanyDetailsItemsService
{
    protected readonly HrmServiceDbContext _context;

    public CompanyDetailsItemsServiceBase(HrmServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one CompanyDetails
    /// </summary>
    public async Task<CompanyDetails> CreateCompanyDetails(CompanyDetailsCreateInput createDto)
    {
        var companyDetails = new CompanyDetailsDbModel
        {
            Branch = createDto.Branch,
            CreatedAt = createDto.CreatedAt,
            DateOfJoining = createDto.DateOfJoining,
            Department = createDto.Department,
            Designation = createDto.Designation,
            EmployeeId = createDto.EmployeeId,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            companyDetails.Id = createDto.Id;
        }

        _context.CompanyDetailsItems.Add(companyDetails);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CompanyDetailsDbModel>(companyDetails.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one CompanyDetails
    /// </summary>
    public async Task DeleteCompanyDetails(CompanyDetailsWhereUniqueInput uniqueId)
    {
        var companyDetails = await _context.CompanyDetailsItems.FindAsync(uniqueId.Id);
        if (companyDetails == null)
        {
            throw new NotFoundException();
        }

        _context.CompanyDetailsItems.Remove(companyDetails);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many CompanyDetailsItems
    /// </summary>
    public async Task<List<CompanyDetails>> CompanyDetailsItems(
        CompanyDetailsFindManyArgs findManyArgs
    )
    {
        var companyDetailsItems = await _context
            .CompanyDetailsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return companyDetailsItems.ConvertAll(companyDetails => companyDetails.ToDto());
    }

    /// <summary>
    /// Meta data about CompanyDetails records
    /// </summary>
    public async Task<MetadataDto> CompanyDetailsItemsMeta(CompanyDetailsFindManyArgs findManyArgs)
    {
        var count = await _context.CompanyDetailsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one CompanyDetails
    /// </summary>
    public async Task<CompanyDetails> CompanyDetails(CompanyDetailsWhereUniqueInput uniqueId)
    {
        var companyDetailsItems = await this.CompanyDetailsItems(
            new CompanyDetailsFindManyArgs
            {
                Where = new CompanyDetailsWhereInput { Id = uniqueId.Id }
            }
        );
        var companyDetails = companyDetailsItems.FirstOrDefault();
        if (companyDetails == null)
        {
            throw new NotFoundException();
        }

        return companyDetails;
    }

    /// <summary>
    /// Update one CompanyDetails
    /// </summary>
    public async Task UpdateCompanyDetails(
        CompanyDetailsWhereUniqueInput uniqueId,
        CompanyDetailsUpdateInput updateDto
    )
    {
        var companyDetails = updateDto.ToModel(uniqueId);

        _context.Entry(companyDetails).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.CompanyDetailsItems.Any(e => e.Id == companyDetails.Id))
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
