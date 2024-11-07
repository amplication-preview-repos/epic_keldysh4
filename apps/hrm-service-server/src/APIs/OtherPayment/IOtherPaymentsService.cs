using HrmService.APIs.Common;
using HrmService.APIs.Dtos;

namespace HrmService.APIs;

public interface IOtherPaymentsService
{
    /// <summary>
    /// Create one OtherPayment
    /// </summary>
    public Task<OtherPayment> CreateOtherPayment(OtherPaymentCreateInput otherpayment);

    /// <summary>
    /// Delete one OtherPayment
    /// </summary>
    public Task DeleteOtherPayment(OtherPaymentWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many OtherPayments
    /// </summary>
    public Task<List<OtherPayment>> OtherPayments(OtherPaymentFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about OtherPayment records
    /// </summary>
    public Task<MetadataDto> OtherPaymentsMeta(OtherPaymentFindManyArgs findManyArgs);

    /// <summary>
    /// Get one OtherPayment
    /// </summary>
    public Task<OtherPayment> OtherPayment(OtherPaymentWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one OtherPayment
    /// </summary>
    public Task UpdateOtherPayment(
        OtherPaymentWhereUniqueInput uniqueId,
        OtherPaymentUpdateInput updateDto
    );
}
