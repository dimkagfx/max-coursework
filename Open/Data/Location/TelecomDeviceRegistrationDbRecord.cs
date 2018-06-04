using Open.Data.Common;
namespace Open.Data.Location {
    public class TelecomDeviceRegistrationDbRecord : TemporalDbRecord {
        private string addressID;
        private string deviceID;
        public string AddressID {
            get => getString(ref addressID);
            set => addressID = value;
        }
        public string DeviceID {
            get => getString(ref deviceID);
            set => deviceID = value;
        }
        public virtual GeographicAddressDbRecord Address { get; set; }
        public virtual TelecomAddressDbRecord Device { get; set; }
    }
}
