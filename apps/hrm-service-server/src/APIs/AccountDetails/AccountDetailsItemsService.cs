using HrmService.Infrastructure;

namespace HrmService.APIs;

public class AccountDetailsItemsService : AccountDetailsItemsServiceBase
{
    public AccountDetailsItemsService(HrmServiceDbContext context)
        : base(context) { }
}
