using HrmService.Infrastructure;

namespace HrmService.APIs;

public class OvertimesService : OvertimesServiceBase
{
    public OvertimesService(HrmServiceDbContext context)
        : base(context) { }
}
