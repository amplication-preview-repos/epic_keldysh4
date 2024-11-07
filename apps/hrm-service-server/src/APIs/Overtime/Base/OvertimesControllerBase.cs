using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class OvertimesControllerBase : ControllerBase
{
    protected readonly IOvertimesService _service;

    public OvertimesControllerBase(IOvertimesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Overtime
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Overtime>> CreateOvertime(OvertimeCreateInput input)
    {
        var overtime = await _service.CreateOvertime(input);

        return CreatedAtAction(nameof(Overtime), new { id = overtime.Id }, overtime);
    }

    /// <summary>
    /// Delete one Overtime
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteOvertime([FromRoute()] OvertimeWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteOvertime(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Overtimes
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Overtime>>> Overtimes(
        [FromQuery()] OvertimeFindManyArgs filter
    )
    {
        return Ok(await _service.Overtimes(filter));
    }

    /// <summary>
    /// Meta data about Overtime records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> OvertimesMeta(
        [FromQuery()] OvertimeFindManyArgs filter
    )
    {
        return Ok(await _service.OvertimesMeta(filter));
    }

    /// <summary>
    /// Get one Overtime
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Overtime>> Overtime(
        [FromRoute()] OvertimeWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Overtime(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Overtime
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateOvertime(
        [FromRoute()] OvertimeWhereUniqueInput uniqueId,
        [FromQuery()] OvertimeUpdateInput overtimeUpdateDto
    )
    {
        try
        {
            await _service.UpdateOvertime(uniqueId, overtimeUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
