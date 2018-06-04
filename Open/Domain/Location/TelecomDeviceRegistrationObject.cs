using Open.Data.Location;
using Open.Domain.Common;
namespace Open.Domain.Location {
    public class
        TelecomDeviceRegistrationObject : TemporalObject<TelecomDeviceRegistrationDbRecord> {
        public readonly TelecomAddressObject Device;
        public readonly GeographicAddressObject Address;
        public TelecomDeviceRegistrationObject(TelecomDeviceRegistrationDbRecord dbRecord) :
            base(dbRecord) {
            DbRecord.Address = DbRecord.Address ?? new GeographicAddressDbRecord();
            DbRecord.Device = DbRecord.Device ?? new TelecomAddressDbRecord();
            Address = AddressObjectFactory.Create(DbRecord.Address) as GeographicAddressObject;
            Device = AddressObjectFactory.Create(DbRecord.Device) as TelecomAddressObject;
        }
    }
}



