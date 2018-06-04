
using Open.Data.Location;
using Open.Domain.Common;
namespace Open.Domain.Location {
    public abstract class AddressObject<T> : UniqueObject<T>, IAddressObject  where T : AddressDbRecord, new() {
        protected AddressObject(T r) : base(r) { }
    }

}

