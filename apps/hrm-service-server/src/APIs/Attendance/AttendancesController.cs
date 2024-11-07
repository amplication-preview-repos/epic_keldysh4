using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs;

[ApiController()]
public class AttendancesController : AttendancesControllerBase
{
    public AttendancesController(IAttendancesService service)
        : base(service) { }
}
