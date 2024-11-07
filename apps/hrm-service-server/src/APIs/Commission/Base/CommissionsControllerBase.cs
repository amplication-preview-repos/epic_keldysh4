using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CommissionsControllerBase : ControllerBase
{
    protected readonly ICommissionsService _service;

    public CommissionsControllerBase(ICommissionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Commission
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Commission>> CreateCommission(CommissionCreateInput input)
    {
        var commission = await _service.CreateCommission(input);

        return CreatedAtAction(nameof(Commission), new { id = commission.Id }, commission);
    }

    /// <summary>
    /// Delete one Commission
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCommission(
        [FromRoute()] CommissionWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteCommission(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Commissions
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Commission>>> Commissions(
        [FromQuery()] CommissionFindManyArgs filter
    )
    {
        return Ok(await _service.Commissions(filter));
    }

    /// <summary>
    /// Meta data about Commission records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CommissionsMeta(
        [FromQuery()] CommissionFindManyArgs filter
    )
    {
        return Ok(await _service.CommissionsMeta(filter));
    }

    /// <summary>
    /// Get one Commission
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Commission>> Commission(
        [FromRoute()] CommissionWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Commission(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Commission
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCommission(
        [FromRoute()] CommissionWhereUniqueInput uniqueId,
        [FromQuery()] CommissionUpdateInput commissionUpdateDto
    )
    {
        try
        {
            await _service.UpdateCommission(uniqueId, commissionUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
