using HrmService.Infrastructure;

namespace HrmService.APIs;

public class LoansService : LoansServiceBase
{
    public LoansService(HrmServiceDbContext context)
        : base(context) { }
}
