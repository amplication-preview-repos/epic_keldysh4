using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class LoansControllerBase : ControllerBase
{
    protected readonly ILoansService _service;

    public LoansControllerBase(ILoansService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Loan
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Loan>> CreateLoan(LoanCreateInput input)
    {
        var loan = await _service.CreateLoan(input);

        return CreatedAtAction(nameof(Loan), new { id = loan.Id }, loan);
    }

    /// <summary>
    /// Delete one Loan
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteLoan([FromRoute()] LoanWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteLoan(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Loans
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Loan>>> Loans([FromQuery()] LoanFindManyArgs filter)
    {
        return Ok(await _service.Loans(filter));
    }

    /// <summary>
    /// Meta data about Loan records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> LoansMeta([FromQuery()] LoanFindManyArgs filter)
    {
        return Ok(await _service.LoansMeta(filter));
    }

    /// <summary>
    /// Get one Loan
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Loan>> Loan([FromRoute()] LoanWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Loan(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Loan
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateLoan(
        [FromRoute()] LoanWhereUniqueInput uniqueId,
        [FromQuery()] LoanUpdateInput loanUpdateDto
    )
    {
        try
        {
            await _service.UpdateLoan(uniqueId, loanUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
