using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PayslipsControllerBase : ControllerBase
{
    protected readonly IPayslipsService _service;

    public PayslipsControllerBase(IPayslipsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Payslip
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Payslip>> CreatePayslip(PayslipCreateInput input)
    {
        var payslip = await _service.CreatePayslip(input);

        return CreatedAtAction(nameof(Payslip), new { id = payslip.Id }, payslip);
    }

    /// <summary>
    /// Delete one Payslip
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePayslip([FromRoute()] PayslipWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeletePayslip(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Payslips
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Payslip>>> Payslips(
        [FromQuery()] PayslipFindManyArgs filter
    )
    {
        return Ok(await _service.Payslips(filter));
    }

    /// <summary>
    /// Meta data about Payslip records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PayslipsMeta(
        [FromQuery()] PayslipFindManyArgs filter
    )
    {
        return Ok(await _service.PayslipsMeta(filter));
    }

    /// <summary>
    /// Get one Payslip
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Payslip>> Payslip([FromRoute()] PayslipWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Payslip(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Payslip
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePayslip(
        [FromRoute()] PayslipWhereUniqueInput uniqueId,
        [FromQuery()] PayslipUpdateInput payslipUpdateDto
    )
    {
        try
        {
            await _service.UpdatePayslip(uniqueId, payslipUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
