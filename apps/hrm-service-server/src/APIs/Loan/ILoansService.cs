using HrmService.APIs.Common;
using HrmService.APIs.Dtos;

namespace HrmService.APIs;

public interface ILoansService
{
    /// <summary>
    /// Create one Loan
    /// </summary>
    public Task<Loan> CreateLoan(LoanCreateInput loan);

    /// <summary>
    /// Delete one Loan
    /// </summary>
    public Task DeleteLoan(LoanWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Loans
    /// </summary>
    public Task<List<Loan>> Loans(LoanFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Loan records
    /// </summary>
    public Task<MetadataDto> LoansMeta(LoanFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Loan
    /// </summary>
    public Task<Loan> Loan(LoanWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Loan
    /// </summary>
    public Task UpdateLoan(LoanWhereUniqueInput uniqueId, LoanUpdateInput updateDto);
}
