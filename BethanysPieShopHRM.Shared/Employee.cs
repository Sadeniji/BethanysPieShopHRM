using System.ComponentModel.DataAnnotations.Schema;

namespace BethanysPieShopHRM.Shared;

public class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime? BirthDate { get; set; }

    public string Email { get; set; } = string.Empty;

    public string? Street { get; set; }

    public string? Zip { get; set; }

    public string? City { get; set; }

    public int? CountryId { get; set; }

    public Country? Country { get; set; }

    public string? PhoneNumber { get; set; }

    public bool Smoker { get; set; }

    public MaritalStatus? MaritalStatus { get; set; }

    public Gender? Gender { get; set; }

    public bool IsOnHoliday { get; set; }

    public string Comment { get; set; } = string.Empty;

    public DateTime? JoinedDate { get; set; }

    public DateTime? ExitDate { get; set; }

    public int? JobCategoryId { get; set; }

    public JobCategory? JobCategory { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    [NotMapped] 
    public byte[]? ImageContent { get; set; }

    public string ImageName { get; set; }
}