using System.Threading.Tasks;
using Open.Core;
using Open.Domain.Location;
namespace Open.Domain.Money {
    public interface ICountryCurrencyObjectsRepository
        : ICrudRepository<CountryCurrencyObject> {
        Task LoadCountries(CurrencyObject currency);
        Task LoadCurrencies(CountryObject country);
    }
}



