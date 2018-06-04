using System.Collections.Generic;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Common;
using Open.Domain.Money;
namespace Open.Domain.Location {
    public sealed class CountryObject : IdentifiedObject<CountryDbRecord> {

        private readonly List<CurrencyObject> currenciesInUse;

        public CountryObject(CountryDbRecord r) : base(r?? new CountryDbRecord()) {
            currenciesInUse = new List<CurrencyObject>();
        }

        public IReadOnlyList<CurrencyObject> CurrenciesInUse =>  currenciesInUse.AsReadOnly();

        public void CurrencyInUse(CurrencyObject currencyObject) {
            if (currencyObject is null) return;
            if (currencyObject.DbRecord.ID == Constants.Unspecified) return;
            if (currenciesInUse.Find(x => x.DbRecord.ID == currencyObject.DbRecord.ID) != null)
                return;
            currenciesInUse.Add(currencyObject);
        }
    }
}


