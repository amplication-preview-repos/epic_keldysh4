using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using HrmService.APIs.Extensions;
using HrmService.Infrastructure;
using HrmService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HrmService.APIs;

public abstract class LoansServiceBase : ILoansService
{
    protected readonly HrmServiceDbContext _context;

    public LoansServiceBase(HrmServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Loan
    /// </summary>
    public async Task<Loan> CreateLoan(LoanCreateInput createDto)
    {
        var loan = new LoanDbModel
        {
            Amount = createDto.Amount,
            CreatedAt = createDto.CreatedAt,
            Employee = createDto.Employee,
            LoanAmount = createDto.LoanAmount,
            LoanOption = createDto.LoanOption,
            Title = createDto.Title,
            TypeField = createDto.TypeField,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            loan.Id = createDto.Id;
        }

        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<LoanDbModel>(loan.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Loan
    /// </summary>
    public async Task DeleteLoan(LoanWhereUniqueInput uniqueId)
    {
        var loan = await _context.Loans.FindAsync(uniqueId.Id);
        if (loan == null)
        {
            throw new NotFoundException();
        }

        _context.Loans.Remove(loan);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Loans
    /// </summary>
    public async Task<List<Loan>> Loans(LoanFindManyArgs findManyArgs)
    {
        var loans = await _context
            .Loans.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return loans.ConvertAll(loan => loan.ToDto());
    }

    /// <summary>
    /// Meta data about Loan records
    /// </summary>
    public async Task<MetadataDto> LoansMeta(LoanFindManyArgs findManyArgs)
    {
        var count = await _context.Loans.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Loan
    /// </summary>
    public async Task<Loan> Loan(LoanWhereUniqueInput uniqueId)
    {
        var loans = await this.Loans(
            new LoanFindManyArgs { Where = new LoanWhereInput { Id = uniqueId.Id } }
        );
        var loan = loans.FirstOrDefault();
        if (loan == null)
        {
            throw new NotFoundException();
        }

        return loan;
    }

    /// <summary>
    /// Update one Loan
    /// </summary>
    public async Task UpdateLoan(LoanWhereUniqueInput uniqueId, LoanUpdateInput updateDto)
    {
        var loan = updateDto.ToModel(uniqueId);

        _context.Entry(loan).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Loans.Any(e => e.Id == loan.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
