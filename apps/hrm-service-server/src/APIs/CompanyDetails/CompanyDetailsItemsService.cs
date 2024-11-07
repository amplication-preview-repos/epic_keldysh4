using HrmService.Infrastructure;

namespace HrmService.APIs;

public class CompanyDetailsItemsService : CompanyDetailsItemsServiceBase
{
    public CompanyDetailsItemsService(HrmServiceDbContext context)
        : base(context) { }
}
