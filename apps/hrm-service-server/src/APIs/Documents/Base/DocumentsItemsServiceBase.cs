using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using HrmService.APIs.Extensions;
using HrmService.Infrastructure;
using HrmService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HrmService.APIs;

public abstract class DocumentsItemsServiceBase : IDocumentsItemsService
{
    protected readonly HrmServiceDbContext _context;

    public DocumentsItemsServiceBase(HrmServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Documents
    /// </summary>
    public async Task<Documents> CreateDocuments(DocumentsCreateInput createDto)
    {
        var documents = new DocumentsDbModel
        {
            Certificates = createDto.Certificates,
            CreatedAt = createDto.CreatedAt,
            Cv = createDto.Cv,
            Photo = createDto.Photo,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            documents.Id = createDto.Id;
        }

        _context.DocumentsItems.Add(documents);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<DocumentsDbModel>(documents.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Documents
    /// </summary>
    public async Task DeleteDocuments(DocumentsWhereUniqueInput uniqueId)
    {
        var documents = await _context.DocumentsItems.FindAsync(uniqueId.Id);
        if (documents == null)
        {
            throw new NotFoundException();
        }

        _context.DocumentsItems.Remove(documents);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many DocumentsItems
    /// </summary>
    public async Task<List<Documents>> DocumentsItems(DocumentsFindManyArgs findManyArgs)
    {
        var documentsItems = await _context
            .DocumentsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return documentsItems.ConvertAll(documents => documents.ToDto());
    }

    /// <summary>
    /// Meta data about Documents records
    /// </summary>
    public async Task<MetadataDto> DocumentsItemsMeta(DocumentsFindManyArgs findManyArgs)
    {
        var count = await _context.DocumentsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Documents
    /// </summary>
    public async Task<Documents> Documents(DocumentsWhereUniqueInput uniqueId)
    {
        var documentsItems = await this.DocumentsItems(
            new DocumentsFindManyArgs { Where = new DocumentsWhereInput { Id = uniqueId.Id } }
        );
        var documents = documentsItems.FirstOrDefault();
        if (documents == null)
        {
            throw new NotFoundException();
        }

        return documents;
    }

    /// <summary>
    /// Update one Documents
    /// </summary>
    public async Task UpdateDocuments(
        DocumentsWhereUniqueInput uniqueId,
        DocumentsUpdateInput updateDto
    )
    {
        var documents = updateDto.ToModel(uniqueId);

        _context.Entry(documents).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.DocumentsItems.Any(e => e.Id == documents.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
