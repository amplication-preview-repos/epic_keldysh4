using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[ApiController()]
public class AccountDetailsItemsController : AccountDetailsItemsControllerBase
{
    public AccountDetailsItemsController(IAccountDetailsItemsService service)
        : base(service) { }
}
