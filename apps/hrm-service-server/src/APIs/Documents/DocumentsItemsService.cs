using HrmService.Infrastructure;

namespace HrmService.APIs;

public class DocumentsItemsService : DocumentsItemsServiceBase
{
    public DocumentsItemsService(HrmServiceDbContext context)
        : base(context) { }
}
