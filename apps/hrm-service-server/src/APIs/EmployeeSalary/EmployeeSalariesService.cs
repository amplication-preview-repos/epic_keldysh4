using HrmService.Infrastructure;

namespace HrmService.APIs;

public class EmployeeSalariesService : EmployeeSalariesServiceBase
{
    public EmployeeSalariesService(HrmServiceDbContext context)
        : base(context) { }
}
