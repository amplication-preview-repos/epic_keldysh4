using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class EmployeeSalariesControllerBase : ControllerBase
{
    protected readonly IEmployeeSalariesService _service;

    public EmployeeSalariesControllerBase(IEmployeeSalariesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one EmployeeSalary
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<EmployeeSalary>> CreateEmployeeSalary(
        EmployeeSalaryCreateInput input
    )
    {
        var employeeSalary = await _service.CreateEmployeeSalary(input);

        return CreatedAtAction(
            nameof(EmployeeSalary),
            new { id = employeeSalary.Id },
            employeeSalary
        );
    }

    /// <summary>
    /// Delete one EmployeeSalary
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteEmployeeSalary(
        [FromRoute()] EmployeeSalaryWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteEmployeeSalary(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many EmployeeSalaries
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<EmployeeSalary>>> EmployeeSalaries(
        [FromQuery()] EmployeeSalaryFindManyArgs filter
    )
    {
        return Ok(await _service.EmployeeSalaries(filter));
    }

    /// <summary>
    /// Meta data about EmployeeSalary records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> EmployeeSalariesMeta(
        [FromQuery()] EmployeeSalaryFindManyArgs filter
    )
    {
        return Ok(await _service.EmployeeSalariesMeta(filter));
    }

    /// <summary>
    /// Get one EmployeeSalary
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<EmployeeSalary>> EmployeeSalary(
        [FromRoute()] EmployeeSalaryWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.EmployeeSalary(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one EmployeeSalary
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateEmployeeSalary(
        [FromRoute()] EmployeeSalaryWhereUniqueInput uniqueId,
        [FromQuery()] EmployeeSalaryUpdateInput employeeSalaryUpdateDto
    )
    {
        try
        {
            await _service.UpdateEmployeeSalary(uniqueId, employeeSalaryUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
