using HrmService.APIs.Common;
using HrmService.APIs.Dtos;

namespace HrmService.APIs;

public interface ICommissionsService
{
    /// <summary>
    /// Create one Commission
    /// </summary>
    public Task<Commission> CreateCommission(CommissionCreateInput commission);

    /// <summary>
    /// Delete one Commission
    /// </summary>
    public Task DeleteCommission(CommissionWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Commissions
    /// </summary>
    public Task<List<Commission>> Commissions(CommissionFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Commission records
    /// </summary>
    public Task<MetadataDto> CommissionsMeta(CommissionFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Commission
    /// </summary>
    public Task<Commission> Commission(CommissionWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Commission
    /// </summary>
    public Task UpdateCommission(
        CommissionWhereUniqueInput uniqueId,
        CommissionUpdateInput updateDto
    );
}
