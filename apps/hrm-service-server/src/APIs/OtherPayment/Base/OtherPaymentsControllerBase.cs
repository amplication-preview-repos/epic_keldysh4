using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class OtherPaymentsControllerBase : ControllerBase
{
    protected readonly IOtherPaymentsService _service;

    public OtherPaymentsControllerBase(IOtherPaymentsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one OtherPayment
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<OtherPayment>> CreateOtherPayment(OtherPaymentCreateInput input)
    {
        var otherPayment = await _service.CreateOtherPayment(input);

        return CreatedAtAction(nameof(OtherPayment), new { id = otherPayment.Id }, otherPayment);
    }

    /// <summary>
    /// Delete one OtherPayment
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteOtherPayment(
        [FromRoute()] OtherPaymentWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteOtherPayment(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many OtherPayments
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<OtherPayment>>> OtherPayments(
        [FromQuery()] OtherPaymentFindManyArgs filter
    )
    {
        return Ok(await _service.OtherPayments(filter));
    }

    /// <summary>
    /// Meta data about OtherPayment records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> OtherPaymentsMeta(
        [FromQuery()] OtherPaymentFindManyArgs filter
    )
    {
        return Ok(await _service.OtherPaymentsMeta(filter));
    }

    /// <summary>
    /// Get one OtherPayment
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<OtherPayment>> OtherPayment(
        [FromRoute()] OtherPaymentWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.OtherPayment(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one OtherPayment
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateOtherPayment(
        [FromRoute()] OtherPaymentWhereUniqueInput uniqueId,
        [FromQuery()] OtherPaymentUpdateInput otherPaymentUpdateDto
    )
    {
        try
        {
            await _service.UpdateOtherPayment(uniqueId, otherPaymentUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
