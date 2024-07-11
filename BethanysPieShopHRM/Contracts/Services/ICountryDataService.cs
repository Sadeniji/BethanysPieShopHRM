using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Services;

public interface ICountryDataService
{
    Task<IEnumerable<Country>> GetAllCountries();
    Task<Country> GetCountryById(int countryId);
}