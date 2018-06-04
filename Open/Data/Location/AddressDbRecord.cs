using Open.Data.Common;
namespace Open.Data.Location {
    public class AddressDbRecord : UniqueDbRecord {
        private string address;
        private string area;
        private string region;
        private string zip;

        public string Address {
            get => getString(ref address);
            set => address = value;
        }
        public string CityOrAreaCode {
            get => getString(ref area);
            set => area = value;
        }
        public string RegionOrStateOrCountryCode {
            get => getString(ref region);
            set => region = value;
        }
        public string ZipOrPostCodeOrExtension {
            get => getString(ref zip);
            set => zip = value;
        }
    }
}



