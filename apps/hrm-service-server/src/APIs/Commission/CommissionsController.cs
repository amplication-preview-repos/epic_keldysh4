using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[ApiController()]
public class CommissionsController : CommissionsControllerBase
{
    public CommissionsController(ICommissionsService service)
        : base(service) { }
}
