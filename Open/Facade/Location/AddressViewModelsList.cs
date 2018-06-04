using Open.Core;
using Open.Domain.Location;
namespace Open.Facade.Location {

    public class AddressViewModelsList : PaginatedList<AddressViewModel> {
        public AddressViewModelsList(IPaginatedList<IAddressObject> list) {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list) { Add(AddressViewModelFactory.Create(e)); }
        }
    }

}

