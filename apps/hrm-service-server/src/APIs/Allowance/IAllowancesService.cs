using HrmService.APIs.Common;
using HrmService.APIs.Dtos;

namespace HrmService.APIs;

public interface IAllowancesService
{
    /// <summary>
    /// Create one Allowance
    /// </summary>
    public Task<Allowance> CreateAllowance(AllowanceCreateInput allowance);

    /// <summary>
    /// Delete one Allowance
    /// </summary>
    public Task DeleteAllowance(AllowanceWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Allowances
    /// </summary>
    public Task<List<Allowance>> Allowances(AllowanceFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Allowance records
    /// </summary>
    public Task<MetadataDto> AllowancesMeta(AllowanceFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Allowance
    /// </summary>
    public Task<Allowance> Allowance(AllowanceWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Allowance
    /// </summary>
    public Task UpdateAllowance(AllowanceWhereUniqueInput uniqueId, AllowanceUpdateInput updateDto);
}
