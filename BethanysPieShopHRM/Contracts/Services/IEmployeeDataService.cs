using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Contracts.Services;

public interface IEmployeeDataService
{
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<Employee> GetEmployeeDetails(int employeeId);
}