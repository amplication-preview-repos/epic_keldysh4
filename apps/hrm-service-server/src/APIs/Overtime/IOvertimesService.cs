using HrmService.APIs.Common;
using HrmService.APIs.Dtos;

namespace HrmService.APIs;

public interface IOvertimesService
{
    /// <summary>
    /// Create one Overtime
    /// </summary>
    public Task<Overtime> CreateOvertime(OvertimeCreateInput overtime);

    /// <summary>
    /// Delete one Overtime
    /// </summary>
    public Task DeleteOvertime(OvertimeWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Overtimes
    /// </summary>
    public Task<List<Overtime>> Overtimes(OvertimeFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Overtime records
    /// </summary>
    public Task<MetadataDto> OvertimesMeta(OvertimeFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Overtime
    /// </summary>
    public Task<Overtime> Overtime(OvertimeWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Overtime
    /// </summary>
    public Task UpdateOvertime(OvertimeWhereUniqueInput uniqueId, OvertimeUpdateInput updateDto);
}
