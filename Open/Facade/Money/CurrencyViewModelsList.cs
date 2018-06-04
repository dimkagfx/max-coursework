using Open.Core;
using Open.Domain.Money;
namespace Open.Facade.Money {
    public class CurrencyViewModelsList : PaginatedList<CurrencyViewModel> {
        public CurrencyViewModelsList(IPaginatedList<CurrencyObject> list) {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) { Add(CurrencyViewModelFactory.Create(e)); }
        }
    }
}



