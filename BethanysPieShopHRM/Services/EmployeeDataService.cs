﻿using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Services;

public class EmployeeDataService(IEmployeeRepository employeeRepository) : IEmployeeDataService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    
    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await _employeeRepository.GetAllEmployees();
    }

    public async Task<Employee> GetEmployeeDetails(int employeeId)
    {
        return await _employeeRepository.GetEmployeeById(employeeId);
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        return await _employeeRepository.AddEmployee(employee);
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        return await _employeeRepository.UpdateEmployee(employee);
    }

    public async Task DeleteEmployee(int employeeId)
    {
        await _employeeRepository.DeleteEmployee(employeeId);
    }
}