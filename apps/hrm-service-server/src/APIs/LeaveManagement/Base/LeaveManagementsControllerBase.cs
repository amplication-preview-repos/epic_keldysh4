using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class LeaveManagementsControllerBase : ControllerBase
{
    protected readonly ILeaveManagementsService _service;

    public LeaveManagementsControllerBase(ILeaveManagementsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one LeaveManagement
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<LeaveManagement>> CreateLeaveManagement(
        LeaveManagementCreateInput input
    )
    {
        var leaveManagement = await _service.CreateLeaveManagement(input);

        return CreatedAtAction(
            nameof(LeaveManagement),
            new { id = leaveManagement.Id },
            leaveManagement
        );
    }

    /// <summary>
    /// Delete one LeaveManagement
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteLeaveManagement(
        [FromRoute()] LeaveManagementWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteLeaveManagement(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many LeaveManagements
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<LeaveManagement>>> LeaveManagements(
        [FromQuery()] LeaveManagementFindManyArgs filter
    )
    {
        return Ok(await _service.LeaveManagements(filter));
    }

    /// <summary>
    /// Meta data about LeaveManagement records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> LeaveManagementsMeta(
        [FromQuery()] LeaveManagementFindManyArgs filter
    )
    {
        return Ok(await _service.LeaveManagementsMeta(filter));
    }

    /// <summary>
    /// Get one LeaveManagement
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<LeaveManagement>> LeaveManagement(
        [FromRoute()] LeaveManagementWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.LeaveManagement(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one LeaveManagement
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateLeaveManagement(
        [FromRoute()] LeaveManagementWhereUniqueInput uniqueId,
        [FromQuery()] LeaveManagementUpdateInput leaveManagementUpdateDto
    )
    {
        try
        {
            await _service.UpdateLeaveManagement(uniqueId, leaveManagementUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
