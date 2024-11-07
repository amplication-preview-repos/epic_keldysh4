using HrmService.Infrastructure;

namespace HrmService.APIs;

public class OtherPaymentsService : OtherPaymentsServiceBase
{
    public OtherPaymentsService(HrmServiceDbContext context)
        : base(context) { }
}
