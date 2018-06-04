﻿using System;
using Open.Domain.Location;
using Open.Facade.Money;
namespace Open.Facade.Location {
    public static class CountryViewModelFactory {
        public static CountryViewModel Create(CountryObject o) {
            var v = new CountryViewModel {
                Name = o?.DbRecord.Name,
                Alpha3Code = o?.DbRecord.ID,
                Alpha2Code = o?.DbRecord.Code
            };
            if (o is null) return v;
            v.ValidFrom = setNullIfExtremum(o.DbRecord.ValidFrom);
            v.ValidTo = setNullIfExtremum(o.DbRecord.ValidTo);
            foreach (var c in o.CurrenciesInUse) {
                var currency = CurrencyViewModelFactory.Create(c);
                v.CurrenciesInUse.Add(currency);
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





