using System.Collections.Generic;
using Open.Core;
using Open.Data.Location;
namespace Open.Domain.Location {

    public sealed class GeographicAddressObject : AddressObject<GeographicAddressDbRecord> {
        public readonly CountryObject Country;
        private readonly List<TelecomAddressObject> registeredTelecomDevices;
        public GeographicAddressObject(GeographicAddressDbRecord r) : base(
            r ?? new GeographicAddressDbRecord()) {
            Country = new CountryObject(DbRecord.Country);
            registeredTelecomDevices = new List<TelecomAddressObject>();
        }
        public IReadOnlyList<TelecomAddressObject> RegisteredTelecomDevices =>
            registeredTelecomDevices.AsReadOnly();

        public void RegisteredTelecomDevice(TelecomAddressObject telecomDeviceAddress) {
            if (telecomDeviceAddress is null) return;
            if (telecomDeviceAddress.DbRecord.ID == Constants.Unspecified) return;
            if (registeredTelecomDevices.Find(
                    x => x.DbRecord.ID == telecomDeviceAddress.DbRecord.ID) != null)
                return;
            registeredTelecomDevices.Add(telecomDeviceAddress);
        }
    }
}


