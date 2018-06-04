using Open.Data.Common;
using Open.Data.Location;
namespace Open.Data.Money {
    public class CountryCurrencyDbRecord : TemporalDbRecord {
        private string countryID;
        private string currencyID;
        public string CountryID {
            get => getString(ref countryID);
            set => countryID = value;
        }
        public string CurrencyID {
            get => getString(ref currencyID);
            set => currencyID = value;
        }
        public virtual CountryDbRecord Country { get; set; }
        public virtual CurrencyDbRecord Currency { get; set; }

    }
}





