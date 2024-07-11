using BethanysPieShopHRM.Client;
using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Services;

public class EmployeeDataService(
    IEmployeeRepository employeeRepository, 
    IWebHostEnvironment webHostEnvironment, 
    IHttpContextAccessor httpContextAccessor) : IEmployeeDataService
{
    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await employeeRepository.GetAllEmployees();
    }

    public async Task<Employee> GetEmployeeDetails(int employeeId)
    {
        return await employeeRepository.GetEmployeeById(employeeId);
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        return await employeeRepository.AddEmployee(employee);
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        if (employee.ImageContent != null)
        {
            string currentUrl = httpContextAccessor.HttpContext.Request.Host.Value;
            var path = $"{webHostEnvironment.WebRootPath}\\uploads\\{employee.ImageName}";
            var fileStream = File.Create(path);
            fileStream.Write(employee.ImageContent, 0, employee.ImageContent.Length);
            fileStream.Close();

            employee.ImageName = $"https://{currentUrl}/uploads/{employee.ImageName}";
        }
        return await employeeRepository.UpdateEmployee(employee);
    }

    public async Task DeleteEmployee(int employeeId)
    {
        await employeeRepository.DeleteEmployee(employeeId);
    }
}