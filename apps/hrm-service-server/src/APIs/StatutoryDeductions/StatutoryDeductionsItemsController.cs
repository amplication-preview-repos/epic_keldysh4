using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[ApiController()]
public class StatutoryDeductionsItemsController : StatutoryDeductionsItemsControllerBase
{
    public StatutoryDeductionsItemsController(IStatutoryDeductionsItemsService service)
        : base(service) { }
}
