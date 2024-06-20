using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Components.Pages;

public partial class EmployeeOverview
{
    public List<Employee> Employees { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        Employees = MockDataService.Employees;
    }
}