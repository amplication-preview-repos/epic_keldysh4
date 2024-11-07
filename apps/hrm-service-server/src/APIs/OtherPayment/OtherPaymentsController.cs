using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[ApiController()]
public class OtherPaymentsController : OtherPaymentsControllerBase
{
    public OtherPaymentsController(IOtherPaymentsService service)
        : base(service) { }
}
