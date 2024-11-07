using HrmService.Infrastructure;

namespace HrmService.APIs;

public class AllowancesService : AllowancesServiceBase
{
    public AllowancesService(HrmServiceDbContext context)
        : base(context) { }
}
