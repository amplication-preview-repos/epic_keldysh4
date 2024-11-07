using HrmService.APIs.Dtos;
using HrmService.Infrastructure.Models;

namespace HrmService.APIs.Extensions;

public static class DocumentsItemsExtensions
{
    public static Documents ToDto(this DocumentsDbModel model)
    {
        return new Documents
        {
            Certificates = model.Certificates,
            CreatedAt = model.CreatedAt,
            Cv = model.Cv,
            Id = model.Id,
            Photo = model.Photo,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static DocumentsDbModel ToModel(
        this DocumentsUpdateInput updateDto,
        DocumentsWhereUniqueInput uniqueId
    )
    {
        var documents = new DocumentsDbModel
        {
            Id = uniqueId.Id,
            Certificates = updateDto.Certificates,
            Cv = updateDto.Cv,
            Photo = updateDto.Photo
        };

        if (updateDto.CreatedAt != null)
        {
            documents.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            documents.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return documents;
    }
}
