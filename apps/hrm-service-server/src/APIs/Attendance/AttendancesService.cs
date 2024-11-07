using HrmService.Infrastructure;

namespace HrmService.APIs;

public class AttendancesService : AttendancesServiceBase
{
    public AttendancesService(HrmServiceDbContext context)
        : base(context) { }
}
