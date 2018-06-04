namespace Open.Data.Location {

    public class GeographicAddressDbRecord : AddressDbRecord {
        private string countryID;

        public string CountryID {
            get => getString(ref countryID);
            set => countryID = value;
        }

        public virtual CountryDbRecord Country { get; set; }
    }
}




