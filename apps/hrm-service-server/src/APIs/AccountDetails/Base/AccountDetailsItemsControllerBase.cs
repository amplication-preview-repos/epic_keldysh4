using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AccountDetailsItemsControllerBase : ControllerBase
{
    protected readonly IAccountDetailsItemsService _service;

    public AccountDetailsItemsControllerBase(IAccountDetailsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one AccountDetails
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<AccountDetails>> CreateAccountDetails(
        AccountDetailsCreateInput input
    )
    {
        var accountDetails = await _service.CreateAccountDetails(input);

        return CreatedAtAction(
            nameof(AccountDetails),
            new { id = accountDetails.Id },
            accountDetails
        );
    }

    /// <summary>
    /// Delete one AccountDetails
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAccountDetails(
        [FromRoute()] AccountDetailsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteAccountDetails(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many AccountDetailsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<AccountDetails>>> AccountDetailsItems(
        [FromQuery()] AccountDetailsFindManyArgs filter
    )
    {
        return Ok(await _service.AccountDetailsItems(filter));
    }

    /// <summary>
    /// Meta data about AccountDetails records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AccountDetailsItemsMeta(
        [FromQuery()] AccountDetailsFindManyArgs filter
    )
    {
        return Ok(await _service.AccountDetailsItemsMeta(filter));
    }

    /// <summary>
    /// Get one AccountDetails
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<AccountDetails>> AccountDetails(
        [FromRoute()] AccountDetailsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.AccountDetails(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one AccountDetails
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAccountDetails(
        [FromRoute()] AccountDetailsWhereUniqueInput uniqueId,
        [FromQuery()] AccountDetailsUpdateInput accountDetailsUpdateDto
    )
    {
        try
        {
            await _service.UpdateAccountDetails(uniqueId, accountDetailsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
