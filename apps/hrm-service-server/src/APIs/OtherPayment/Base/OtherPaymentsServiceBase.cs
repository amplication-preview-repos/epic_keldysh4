using HrmService.APIs;
using HrmService.APIs.Common;
using HrmService.APIs.Dtos;
using HrmService.APIs.Errors;
using HrmService.APIs.Extensions;
using HrmService.Infrastructure;
using HrmService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HrmService.APIs;

public abstract class OtherPaymentsServiceBase : IOtherPaymentsService
{
    protected readonly HrmServiceDbContext _context;

    public OtherPaymentsServiceBase(HrmServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one OtherPayment
    /// </summary>
    public async Task<OtherPayment> CreateOtherPayment(OtherPaymentCreateInput createDto)
    {
        var otherPayment = new OtherPaymentDbModel
        {
            Amount = createDto.Amount,
            CreatedAt = createDto.CreatedAt,
            Employee = createDto.Employee,
            Title = createDto.Title,
            TypeField = createDto.TypeField,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            otherPayment.Id = createDto.Id;
        }

        _context.OtherPayments.Add(otherPayment);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<OtherPaymentDbModel>(otherPayment.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one OtherPayment
    /// </summary>
    public async Task DeleteOtherPayment(OtherPaymentWhereUniqueInput uniqueId)
    {
        var otherPayment = await _context.OtherPayments.FindAsync(uniqueId.Id);
        if (otherPayment == null)
        {
            throw new NotFoundException();
        }

        _context.OtherPayments.Remove(otherPayment);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many OtherPayments
    /// </summary>
    public async Task<List<OtherPayment>> OtherPayments(OtherPaymentFindManyArgs findManyArgs)
    {
        var otherPayments = await _context
            .OtherPayments.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return otherPayments.ConvertAll(otherPayment => otherPayment.ToDto());
    }

    /// <summary>
    /// Meta data about OtherPayment records
    /// </summary>
    public async Task<MetadataDto> OtherPaymentsMeta(OtherPaymentFindManyArgs findManyArgs)
    {
        var count = await _context.OtherPayments.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one OtherPayment
    /// </summary>
    public async Task<OtherPayment> OtherPayment(OtherPaymentWhereUniqueInput uniqueId)
    {
        var otherPayments = await this.OtherPayments(
            new OtherPaymentFindManyArgs { Where = new OtherPaymentWhereInput { Id = uniqueId.Id } }
        );
        var otherPayment = otherPayments.FirstOrDefault();
        if (otherPayment == null)
        {
            throw new NotFoundException();
        }

        return otherPayment;
    }

    /// <summary>
    /// Update one OtherPayment
    /// </summary>
    public async Task UpdateOtherPayment(
        OtherPaymentWhereUniqueInput uniqueId,
        OtherPaymentUpdateInput updateDto
    )
    {
        var otherPayment = updateDto.ToModel(uniqueId);

        _context.Entry(otherPayment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.OtherPayments.Any(e => e.Id == otherPayment.Id))
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
