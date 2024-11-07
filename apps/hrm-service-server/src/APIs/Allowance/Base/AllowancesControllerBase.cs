using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AllowancesControllerBase : ControllerBase
{
    protected readonly IAllowancesService _service;

    public AllowancesControllerBase(IAllowancesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Allowance
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Allowance>> CreateAllowance(AllowanceCreateInput input)
    {
        var allowance = await _service.CreateAllowance(input);

        return CreatedAtAction(nameof(Allowance), new { id = allowance.Id }, allowance);
    }

    /// <summary>
    /// Delete one Allowance
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAllowance(
        [FromRoute()] AllowanceWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteAllowance(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Allowances
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Allowance>>> Allowances(
        [FromQuery()] AllowanceFindManyArgs filter
    )
    {
        return Ok(await _service.Allowances(filter));
    }

    /// <summary>
    /// Meta data about Allowance records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AllowancesMeta(
        [FromQuery()] AllowanceFindManyArgs filter
    )
    {
        return Ok(await _service.AllowancesMeta(filter));
    }

    /// <summary>
    /// Get one Allowance
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Allowance>> Allowance(
        [FromRoute()] AllowanceWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Allowance(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Allowance
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAllowance(
        [FromRoute()] AllowanceWhereUniqueInput uniqueId,
        [FromQuery()] AllowanceUpdateInput allowanceUpdateDto
    )
    {
        try
        {
            await _service.UpdateAllowance(uniqueId, allowanceUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
