using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[ApiController()]
public class PayslipsController : PayslipsControllerBase
{
    public PayslipsController(IPayslipsService service)
        : base(service) { }
}
