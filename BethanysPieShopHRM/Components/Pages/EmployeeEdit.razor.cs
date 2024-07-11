using BethanysPieShopHRM.Client;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BethanysPieShopHRM.Components.Pages;

public partial class EmployeeEdit
{
    [Inject]
    public IEmployeeDataService? EmployeeDataService { get; set; }
    
    [Inject]
    public ICountryDataService? CountryDataService { get; set; }
    
    [Inject]
    public IJobCategoryDataService? JobCategoryDataService { get; set; }
    
    [Inject] 
    public NavigationManager NavigationManager { get; set; }
    
    [Parameter] 
    public int EmployeeId { get; set; }

    [SupplyParameterFromForm] 
    public Employee Employee { get; set; } = new();

    public List<Country> Countries { get; set; } = [];
    public List<JobCategory> JobCategories { get; set; } = [];

    protected bool Saved;
    private IBrowserFile selectedFile;

    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;
    
    protected override async Task OnInitializedAsync()
    {
        Saved = false;
        Countries = (await CountryDataService.GetAllCountries()).ToList();
        JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();

        Employee = await EmployeeDataService.GetEmployeeDetails(EmployeeId);
    }

    private async Task HandleValidSubmit()
    {
        if (selectedFile != null)
        {
            var file = selectedFile;
            Stream stream = file.OpenReadStream();
            MemoryStream ms = new();
            await stream.CopyToAsync(ms);
            stream.Close();

            Employee.ImageName = file.Name;
            Employee.ImageContent = ms.ToArray();
        }
        await EmployeeDataService.UpdateEmployee(Employee);
        Saved = true;
        StatusClass = "alert-success";
        Message = "Employee updated successfully.";
    }

    private void HandleInvalidSubmit()
    {
        StatusClass = "alert-danger";
        Message = "There are some validation errors. Please try again.";
    }

    private async Task DeleteEmployee()
    {
        await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);
        
        Saved = true;
        StatusClass = "alert-success";
        Message = "Deleted successfully";
    }

    private void NavigationToOverview()
    {
        NavigationManager.NavigateTo("/employeeoverview");
    }

    private void OnInputFileChange(InputFileChangeEventArgs e)
    {
        selectedFile = e.File;
        StateHasChanged();
    }
}