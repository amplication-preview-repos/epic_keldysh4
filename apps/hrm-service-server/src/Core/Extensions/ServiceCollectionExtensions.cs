using HrmService.APIs;

namespace HrmService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountDetailsService, AccountDetailsService>();
        services.AddScoped<IAllowancesService, AllowancesService>();
        services.AddScoped<IAttendancesService, AttendancesService>();
        services.AddScoped<ICommissionsService, CommissionsService>();
        services.AddScoped<ICompanyDetailsService, CompanyDetailsService>();
        services.AddScoped<IDocumentsService, DocumentsService>();
        services.AddScoped<IEmployeesService, EmployeesService>();
        services.AddScoped<IEmployeeSalariesService, EmployeeSalariesService>();
        services.AddScoped<ILeaveManagementsService, LeaveManagementsService>();
        services.AddScoped<ILoansService, LoansService>();
        services.AddScoped<IOtherPaymentsService, OtherPaymentsService>();
        services.AddScoped<IOvertimesService, OvertimesService>();
        services.AddScoped<IPayslipsService, PayslipsService>();
        services.AddScoped<IStatutoryDeductionsService, StatutoryDeductionsService>();
    }
}
