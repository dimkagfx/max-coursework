﻿using System;
using System.Globalization;
using Open.Data.Money;
namespace Open.Domain.Money {
    public static class CurrencyObjectFactory {

        public static CurrencyObject Create(string id, string name, string code,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var o = new CurrencyDbRecord {
                ID = id,
                Name = name,
                Code = code,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new CurrencyObject(o);
        }

        public static CurrencyObject Create(RegionInfo r) {
            var id = r?.ISOCurrencySymbol;
            var name = r?.CurrencyEnglishName;
            var code = r?.CurrencySymbol;
            return Create(id, name, code);
        }
    }
}

