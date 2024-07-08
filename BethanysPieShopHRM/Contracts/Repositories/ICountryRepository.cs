using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Contracts.Repositories;

public interface ICountryRepository
{
    Task<IEnumerable<Country>> GetAllCountries();
    Task<Country> GetCountryById(int countryId);
}