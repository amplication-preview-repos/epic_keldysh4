using HrmService.Infrastructure;

namespace HrmService.APIs;

public class EmployeesService : EmployeesServiceBase
{
    public EmployeesService(HrmServiceDbContext context)
        : base(context) { }
}
