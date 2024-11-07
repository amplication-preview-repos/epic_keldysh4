using HrmService.APIs.Common;
using HrmService.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace HrmService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class PayslipFindManyArgs : FindManyInput<Payslip, PayslipWhereInput> { }
