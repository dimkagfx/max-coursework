using System;
using Open.Data.Location;
namespace Open.Domain.Location {
    public static class TelecomDeviceRegistrationObjectFactory {
        public static TelecomDeviceRegistrationObject Create(GeographicAddressObject address,
            TelecomAddressObject device,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var o = new TelecomDeviceRegistrationDbRecord {
                Address = address?.DbRecord?? new GeographicAddressDbRecord(),
                Device = device?.DbRecord?? new TelecomAddressDbRecord(),
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            o.AddressID = o.Address?.ID;
            o.DeviceID = o.Device?.ID;
            return new TelecomDeviceRegistrationObject(o);
        }
    }
}



