using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[ApiController()]
public class DocumentsItemsController : DocumentsItemsControllerBase
{
    public DocumentsItemsController(IDocumentsItemsService service)
        : base(service) { }
}
