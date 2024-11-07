using HrmService.Infrastructure;

namespace HrmService.APIs;

public class LeaveManagementsService : LeaveManagementsServiceBase
{
    public LeaveManagementsService(HrmServiceDbContext context)
        : base(context) { }
}
