using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class StatutoryDeductionsItemsControllerBase : ControllerBase
{
    protected readonly IStatutoryDeductionsItemsService _service;

    public StatutoryDeductionsItemsControllerBase(IStatutoryDeductionsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one StatutoryDeductions
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<StatutoryDeductions>> CreateStatutoryDeductions(
        StatutoryDeductionsCreateInput input
    )
    {
        var statutoryDeductions = await _service.CreateStatutoryDeductions(input);

        return CreatedAtAction(
            nameof(StatutoryDeductions),
            new { id = statutoryDeductions.Id },
            statutoryDeductions
        );
    }

    /// <summary>
    /// Delete one StatutoryDeductions
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteStatutoryDeductions(
        [FromRoute()] StatutoryDeductionsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteStatutoryDeductions(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many StatutoryDeductionsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<StatutoryDeductions>>> StatutoryDeductionsItems(
        [FromQuery()] StatutoryDeductionsFindManyArgs filter
    )
    {
        return Ok(await _service.StatutoryDeductionsItems(filter));
    }

    /// <summary>
    /// Meta data about StatutoryDeductions records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> StatutoryDeductionsItemsMeta(
        [FromQuery()] StatutoryDeductionsFindManyArgs filter
    )
    {
        return Ok(await _service.StatutoryDeductionsItemsMeta(filter));
    }

    /// <summary>
    /// Get one StatutoryDeductions
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<StatutoryDeductions>> StatutoryDeductions(
        [FromRoute()] StatutoryDeductionsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.StatutoryDeductions(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one StatutoryDeductions
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateStatutoryDeductions(
        [FromRoute()] StatutoryDeductionsWhereUniqueInput uniqueId,
        [FromQuery()] StatutoryDeductionsUpdateInput statutoryDeductionsUpdateDto
    )
    {
        try
        {
            await _service.UpdateStatutoryDeductions(uniqueId, statutoryDeductionsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
