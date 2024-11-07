using HrmService.APIs.Common;
using HrmService.APIs.Dtos;

namespace HrmService.APIs;

public interface IPayslipsService
{
    /// <summary>
    /// Create one Payslip
    /// </summary>
    public Task<Payslip> CreatePayslip(PayslipCreateInput payslip);

    /// <summary>
    /// Delete one Payslip
    /// </summary>
    public Task DeletePayslip(PayslipWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Payslips
    /// </summary>
    public Task<List<Payslip>> Payslips(PayslipFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Payslip records
    /// </summary>
    public Task<MetadataDto> PayslipsMeta(PayslipFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Payslip
    /// </summary>
    public Task<Payslip> Payslip(PayslipWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Payslip
    /// </summary>
    public Task UpdatePayslip(PayslipWhereUniqueInput uniqueId, PayslipUpdateInput updateDto);
}
