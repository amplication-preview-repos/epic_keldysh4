using HrmService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HrmService.Infrastructure;

public class HrmServiceDbContext : DbContext
{
    public HrmServiceDbContext(DbContextOptions<HrmServiceDbContext> options)
        : base(options) { }

    public DbSet<EmployeeDbModel> Employees { get; set; }

    public DbSet<CompanyDetailsDbModel> CompanyDetailsItems { get; set; }

    public DbSet<AccountDetailsDbModel> AccountDetailsItems { get; set; }

    public DbSet<DocumentsDbModel> DocumentsItems { get; set; }

    public DbSet<AllowanceDbModel> Allowances { get; set; }

    public DbSet<EmployeeSalaryDbModel> EmployeeSalaries { get; set; }

    public DbSet<PayslipDbModel> Payslips { get; set; }

    public DbSet<OtherPaymentDbModel> OtherPayments { get; set; }

    public DbSet<OvertimeDbModel> Overtimes { get; set; }

    public DbSet<LoanDbModel> Loans { get; set; }

    public DbSet<StatutoryDeductionsDbModel> StatutoryDeductionsItems { get; set; }

    public DbSet<CommissionDbModel> Commissions { get; set; }

    public DbSet<AttendanceDbModel> Attendances { get; set; }

    public DbSet<LeaveManagementDbModel> LeaveManagements { get; set; }
}
