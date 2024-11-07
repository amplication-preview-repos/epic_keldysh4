using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class DocumentsItemsControllerBase : ControllerBase
{
    protected readonly IDocumentsItemsService _service;

    public DocumentsItemsControllerBase(IDocumentsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Documents
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Documents>> CreateDocuments(DocumentsCreateInput input)
    {
        var documents = await _service.CreateDocuments(input);

        return CreatedAtAction(nameof(Documents), new { id = documents.Id }, documents);
    }

    /// <summary>
    /// Delete one Documents
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteDocuments(
        [FromRoute()] DocumentsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteDocuments(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many DocumentsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Documents>>> DocumentsItems(
        [FromQuery()] DocumentsFindManyArgs filter
    )
    {
        return Ok(await _service.DocumentsItems(filter));
    }

    /// <summary>
    /// Meta data about Documents records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> DocumentsItemsMeta(
        [FromQuery()] DocumentsFindManyArgs filter
    )
    {
        return Ok(await _service.DocumentsItemsMeta(filter));
    }

    /// <summary>
    /// Get one Documents
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Documents>> Documents(
        [FromRoute()] DocumentsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Documents(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Documents
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateDocuments(
        [FromRoute()] DocumentsWhereUniqueInput uniqueId,
        [FromQuery()] DocumentsUpdateInput documentsUpdateDto
    )
    {
        try
        {
            await _service.UpdateDocuments(uniqueId, documentsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
