using HrmService.Infrastructure;

namespace HrmService.APIs;

public class PayslipsService : PayslipsServiceBase
{
    public PayslipsService(HrmServiceDbContext context)
        : base(context) { }
}
