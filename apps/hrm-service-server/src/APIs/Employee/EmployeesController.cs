using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[ApiController()]
public class EmployeesController : EmployeesControllerBase
{
    public EmployeesController(IEmployeesService service)
        : base(service) { }
}
