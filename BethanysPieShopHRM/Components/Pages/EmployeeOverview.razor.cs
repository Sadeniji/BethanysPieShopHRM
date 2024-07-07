using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Components.Pages;

public partial class EmployeeOverview
{
    public List<Employee> Employees { get; set; } = default!;
    private Employee? _selectedEmployee;

    private const string Title = "Employee overview";

    [Inject] 
    public IEmployeeDataService? EmployeeDataService { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        //await Task.Delay(2000);
        Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
    }

    public void ShowQuickViewPopup(Employee selectedEmployee)
    {
        _selectedEmployee = selectedEmployee;
    }
}