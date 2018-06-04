using System;
using Open.Domain.Money;
using Open.Facade.Location;
namespace Open.Facade.Money {
    public static class CurrencyViewModelFactory {
        public static CurrencyViewModel Create(CurrencyObject o) {
            var v = new CurrencyViewModel {
                Name = o?.DbRecord.Name,
                IsoCode = o?.DbRecord.ID,
                Symbol = o?.DbRecord.Code
            };
            if (o is null) return v;
            v.ValidFrom = setNullIfExtremum(o.DbRecord.ValidFrom);
            v.ValidTo = setNullIfExtremum(o.DbRecord.ValidTo);
            foreach (var c in o.UsedInCountries) {
                var country = CountryViewModelFactory.Create(c);
                v.UsedInCountries.Add(country);
            } 
            return v;
        }
        private static DateTime? setNullIfExtremum(DateTime d) {
            if (d.Date >= DateTime.MaxValue.Date) return null;
            if (d.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return d;
        }
    }
}

