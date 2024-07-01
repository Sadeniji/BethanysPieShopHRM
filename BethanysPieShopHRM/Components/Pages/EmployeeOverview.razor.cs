using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Components.Pages;

public partial class EmployeeOverview
{
    public List<Employee> Employees { get; set; } = default!;
    private Employee? _selectedEmployee;

    private string Title = "Employee overview";

    protected override async Task OnInitializedAsync()
    {
        //await Task.Delay(2000);
        Employees = MockDataService.Employees;
    }

    public void ShowQuickViewPopup(Employee selectedEmployee)
    {
        _selectedEmployee = selectedEmployee;
    }
}