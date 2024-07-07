using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Shared;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Repositories;

public class EmployeeRepository(IDbContextFactory<AppDbContext> dbFactory) : IEmployeeRepository, IDisposable
{
    private readonly AppDbContext _appDbContext = dbFactory.CreateDbContext();

    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await _appDbContext.Employees.ToListAsync();
    }

    public async Task<Employee> GetEmployeeById(int employeeId)
    {
        return await _appDbContext.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}