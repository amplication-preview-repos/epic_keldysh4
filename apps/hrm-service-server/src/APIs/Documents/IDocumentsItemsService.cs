using HrmService.APIs.Common;
using HrmService.APIs.Dtos;

namespace HrmService.APIs;

public interface IDocumentsItemsService
{
    /// <summary>
    /// Create one Documents
    /// </summary>
    public Task<Documents> CreateDocuments(DocumentsCreateInput documents);

    /// <summary>
    /// Delete one Documents
    /// </summary>
    public Task DeleteDocuments(DocumentsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many DocumentsItems
    /// </summary>
    public Task<List<Documents>> DocumentsItems(DocumentsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Documents records
    /// </summary>
    public Task<MetadataDto> DocumentsItemsMeta(DocumentsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Documents
    /// </summary>
    public Task<Documents> Documents(DocumentsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Documents
    /// </summary>
    public Task UpdateDocuments(DocumentsWhereUniqueInput uniqueId, DocumentsUpdateInput updateDto);
}
