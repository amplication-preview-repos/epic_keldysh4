using HrmService.Infrastructure;

namespace HrmService.APIs;

public class StatutoryDeductionsItemsService : StatutoryDeductionsItemsServiceBase
{
    public StatutoryDeductionsItemsService(HrmServiceDbContext context)
        : base(context) { }
}
