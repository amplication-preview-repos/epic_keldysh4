using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[ApiController()]
public class LoansController : LoansControllerBase
{
    public LoansController(ILoansService service)
        : base(service) { }
}
