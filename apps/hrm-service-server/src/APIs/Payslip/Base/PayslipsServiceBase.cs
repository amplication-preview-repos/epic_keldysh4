using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using HrmService.APIs.Extensions;
using HrmService.Infrastructure;
using HrmService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HrmService.APIs;

public abstract class PayslipsServiceBase : IPayslipsService
{
    protected readonly HrmServiceDbContext _context;

    public PayslipsServiceBase(HrmServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Payslip
    /// </summary>
    public async Task<Payslip> CreatePayslip(PayslipCreateInput createDto)
    {
        var payslip = new PayslipDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Employee = createDto.Employee,
            PayslipAmount = createDto.PayslipAmount,
            PayslipDate = createDto.PayslipDate,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            payslip.Id = createDto.Id;
        }

        _context.Payslips.Add(payslip);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PayslipDbModel>(payslip.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Payslip
    /// </summary>
    public async Task DeletePayslip(PayslipWhereUniqueInput uniqueId)
    {
        var payslip = await _context.Payslips.FindAsync(uniqueId.Id);
        if (payslip == null)
        {
            throw new NotFoundException();
        }

        _context.Payslips.Remove(payslip);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Payslips
    /// </summary>
    public async Task<List<Payslip>> Payslips(PayslipFindManyArgs findManyArgs)
    {
        var payslips = await _context
            .Payslips.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return payslips.ConvertAll(payslip => payslip.ToDto());
    }

    /// <summary>
    /// Meta data about Payslip records
    /// </summary>
    public async Task<MetadataDto> PayslipsMeta(PayslipFindManyArgs findManyArgs)
    {
        var count = await _context.Payslips.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Payslip
    /// </summary>
    public async Task<Payslip> Payslip(PayslipWhereUniqueInput uniqueId)
    {
        var payslips = await this.Payslips(
            new PayslipFindManyArgs { Where = new PayslipWhereInput { Id = uniqueId.Id } }
        );
        var payslip = payslips.FirstOrDefault();
        if (payslip == null)
        {
            throw new NotFoundException();
        }

        return payslip;
    }

    /// <summary>
    /// Update one Payslip
    /// </summary>
    public async Task UpdatePayslip(PayslipWhereUniqueInput uniqueId, PayslipUpdateInput updateDto)
    {
        var payslip = updateDto.ToModel(uniqueId);

        _context.Entry(payslip).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Payslips.Any(e => e.Id == payslip.Id))
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
