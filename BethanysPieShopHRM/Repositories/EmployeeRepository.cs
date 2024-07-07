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

    public async Task<Employee> AddEmployee(Employee employee)
    {
        var addedEntity = await _appDbContext.Employees.AddAsync(employee);
        await _appDbContext.SaveChangesAsync();
        return addedEntity.Entity;
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        var foundEmployee = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

        if (foundEmployee is null)
        {
            return null;
        }
        
        foundEmployee.CountryId = employee.CountryId;
        foundEmployee.MaritalStatus = employee.MaritalStatus;
        foundEmployee.BirthDate = employee.BirthDate;
        foundEmployee.City = employee.City;
        foundEmployee.Email = employee.Email;
        foundEmployee.FirstName = employee.FirstName;
        foundEmployee.LastName = employee.LastName;
        foundEmployee.Gender = employee.Gender;
        foundEmployee.PhoneNumber = employee.PhoneNumber;
        foundEmployee.Smoker = employee.Smoker;
        foundEmployee.Street = employee.Street;
        foundEmployee.Zip = employee.Zip;
        foundEmployee.JobCategoryId = employee.JobCategoryId;

        await _appDbContext.SaveChangesAsync();
        return foundEmployee;
    }

    public async Task DeleteEmployee(int employeeId)
    {
        var foundEmployee = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

        if (foundEmployee is null)
            return;

        _appDbContext.Employees.Remove(foundEmployee);
        await _appDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}