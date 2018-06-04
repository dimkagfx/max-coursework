using Open.Core;
using Open.Domain.Location;
namespace Open.Facade.Location {
    public class CountryViewModelsList : PaginatedList<CountryViewModel> {
        public CountryViewModelsList(IPaginatedList<CountryObject> list) {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) {
                Add(CountryViewModelFactory.Create(e));
            }
        }
    }
}



