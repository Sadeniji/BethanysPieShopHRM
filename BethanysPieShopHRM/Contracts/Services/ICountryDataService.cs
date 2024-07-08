using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Contracts.Services;

public interface ICountryDataService
{
    Task<IEnumerable<Country>> GetAllCountries();
    Task<Country> GetCountryById(int countryId);
}