using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CompanyDetailsItemsControllerBase : ControllerBase
{
    protected readonly ICompanyDetailsItemsService _service;

    public CompanyDetailsItemsControllerBase(ICompanyDetailsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one CompanyDetails
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<CompanyDetails>> CreateCompanyDetails(
        CompanyDetailsCreateInput input
    )
    {
        var companyDetails = await _service.CreateCompanyDetails(input);

        return CreatedAtAction(
            nameof(CompanyDetails),
            new { id = companyDetails.Id },
            companyDetails
        );
    }

    /// <summary>
    /// Delete one CompanyDetails
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCompanyDetails(
        [FromRoute()] CompanyDetailsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteCompanyDetails(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many CompanyDetailsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<CompanyDetails>>> CompanyDetailsItems(
        [FromQuery()] CompanyDetailsFindManyArgs filter
    )
    {
        return Ok(await _service.CompanyDetailsItems(filter));
    }

    /// <summary>
    /// Meta data about CompanyDetails records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CompanyDetailsItemsMeta(
        [FromQuery()] CompanyDetailsFindManyArgs filter
    )
    {
        return Ok(await _service.CompanyDetailsItemsMeta(filter));
    }

    /// <summary>
    /// Get one CompanyDetails
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<CompanyDetails>> CompanyDetails(
        [FromRoute()] CompanyDetailsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.CompanyDetails(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one CompanyDetails
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCompanyDetails(
        [FromRoute()] CompanyDetailsWhereUniqueInput uniqueId,
        [FromQuery()] CompanyDetailsUpdateInput companyDetailsUpdateDto
    )
    {
        try
        {
            await _service.UpdateCompanyDetails(uniqueId, companyDetailsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
