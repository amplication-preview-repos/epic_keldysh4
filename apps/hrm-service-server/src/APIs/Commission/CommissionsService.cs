using HrmService.Infrastructure;

namespace HrmService.APIs;

public class CommissionsService : CommissionsServiceBase
{
    public CommissionsService(HrmServiceDbContext context)
        : base(context) { }
}
