using HrmService.APIs.Common;
using HrmService.APIs.Dtos;

namespace HrmService.APIs;

public interface IStatutoryDeductionsItemsService
{
    /// <summary>
    /// Create one StatutoryDeductions
    /// </summary>
    public Task<StatutoryDeductions> CreateStatutoryDeductions(
        StatutoryDeductionsCreateInput statutorydeductions
    );

    /// <summary>
    /// Delete one StatutoryDeductions
    /// </summary>
    public Task DeleteStatutoryDeductions(StatutoryDeductionsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many StatutoryDeductionsItems
    /// </summary>
    public Task<List<StatutoryDeductions>> StatutoryDeductionsItems(
        StatutoryDeductionsFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about StatutoryDeductions records
    /// </summary>
    public Task<MetadataDto> StatutoryDeductionsItemsMeta(
        StatutoryDeductionsFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one StatutoryDeductions
    /// </summary>
    public Task<StatutoryDeductions> StatutoryDeductions(
        StatutoryDeductionsWhereUniqueInput uniqueId
    );

    /// <summary>
    /// Update one StatutoryDeductions
    /// </summary>
    public Task UpdateStatutoryDeductions(
        StatutoryDeductionsWhereUniqueInput uniqueId,
        StatutoryDeductionsUpdateInput updateDto
    );
}
