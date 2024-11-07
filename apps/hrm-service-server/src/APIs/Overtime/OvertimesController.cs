using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[ApiController()]
public class OvertimesController : OvertimesControllerBase
{
    public OvertimesController(IOvertimesService service)
        : base(service) { }
}
