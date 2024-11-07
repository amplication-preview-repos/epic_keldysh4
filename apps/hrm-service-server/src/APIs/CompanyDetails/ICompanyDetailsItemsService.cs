using HrmService.APIs.Common;
using HrmService.APIs.Dtos;

namespace HrmService.APIs;

public interface ICompanyDetailsItemsService
{
    /// <summary>
    /// Create one CompanyDetails
    /// </summary>
    public Task<CompanyDetails> CreateCompanyDetails(CompanyDetailsCreateInput companydetails);

    /// <summary>
    /// Delete one CompanyDetails
    /// </summary>
    public Task DeleteCompanyDetails(CompanyDetailsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many CompanyDetailsItems
    /// </summary>
    public Task<List<CompanyDetails>> CompanyDetailsItems(CompanyDetailsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about CompanyDetails records
    /// </summary>
    public Task<MetadataDto> CompanyDetailsItemsMeta(CompanyDetailsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one CompanyDetails
    /// </summary>
    public Task<CompanyDetails> CompanyDetails(CompanyDetailsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one CompanyDetails
    /// </summary>
    public Task UpdateCompanyDetails(
        CompanyDetailsWhereUniqueInput uniqueId,
        CompanyDetailsUpdateInput updateDto
    );
}
