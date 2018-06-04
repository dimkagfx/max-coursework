using Open.Data.Location;
namespace Open.Domain.Location {
    public sealed class WebAddressObject : AddressObject<WebPageAddressDbRecord> {
        public WebAddressObject(WebPageAddressDbRecord r) : base(r ?? new WebPageAddressDbRecord()) { }
    }

}



