using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[ApiController()]
public class EmployeeSalariesController : EmployeeSalariesControllerBase
{
    public EmployeeSalariesController(IEmployeeSalariesService service)
        : base(service) { }
}
