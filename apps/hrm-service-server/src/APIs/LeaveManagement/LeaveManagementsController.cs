using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[ApiController()]
public class LeaveManagementsController : LeaveManagementsControllerBase
{
    public LeaveManagementsController(ILeaveManagementsService service)
        : base(service) { }
}
