using Open.Core;
namespace Open.Data.Location {
    public class TelecomAddressDbRecord : AddressDbRecord {

        private string prefix;

        public string NationalDirectDialingPrefix {
            get => getString(ref prefix);
            set => prefix = value;
        }

        public TelecomDevice Device { get; set; }
    }
}


