using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Repositories;

public class TimeRegistrationRepository(IDbContextFactory<AppDbContext> dbContextFactory)
    : ITimeRegistrationRepository, IDisposable
{
    private readonly AppDbContext _appDbContext = dbContextFactory.CreateDbContext();

    public async Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId)
    {
        return await _appDbContext.TimeRegistrations.Where(t => t.EmployeeId == employeeId)
            .OrderBy(t => t.StartTime)
            .ToListAsync();
    }

    public async Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start)
    {
        return await _appDbContext.TimeRegistrations.Where(t => t.EmployeeId == employeeId)
            .OrderBy(t => t.StartTime)
            .Take(pageSize).ToListAsync();
    }

    public async Task<int> GetTimeRegistrationCountForEmployeeId(int employeeId)
    {
        return await _appDbContext.TimeRegistrations.CountAsync(t => t.EmployeeId == employeeId);
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}