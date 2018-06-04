using System.Collections.Generic;
using Open.Core;
using Open.Data.Location;
namespace Open.Domain.Location {
    public sealed class TelecomAddressObject : AddressObject<TelecomAddressDbRecord> {
        private readonly List<GeographicAddressObject> registeredInAddresses;

        public TelecomAddressObject(TelecomAddressDbRecord r) : base(
            r ?? new TelecomAddressDbRecord()) {
            registeredInAddresses = new List<GeographicAddressObject>();
        }
        public IReadOnlyList<GeographicAddressObject> RegisteredInAddresses =>
            registeredInAddresses.AsReadOnly();

        public void RegisteredInAddress(GeographicAddressObject geographicAddress) {
            if (geographicAddress is null) return;
            if (geographicAddress.DbRecord.ID == Constants.Unspecified) return;
            if (registeredInAddresses.Find(x => x.DbRecord.ID == geographicAddress.DbRecord.ID) != null)
                return;
            registeredInAddresses.Add(geographicAddress);
        }
    }
}
