using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[ApiController()]
public class AllowancesController : AllowancesControllerBase
{
    public AllowancesController(IAllowancesService service)
        : base(service) { }
}
