using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[ApiController()]
public class CompanyDetailsItemsController : CompanyDetailsItemsControllerBase
{
    public CompanyDetailsItemsController(ICompanyDetailsItemsService service)
        : base(service) { }
}
