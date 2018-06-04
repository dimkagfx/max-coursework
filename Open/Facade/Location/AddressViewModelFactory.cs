
using System;
using Open.Core;
using Open.Domain.Location;
namespace Open.Facade.Location {
    public static class AddressViewModelFactory {

        public static AddressViewModel Create(IAddressObject o)
        {
                switch (o)
                {
                    case WebAddressObject web:
                        return create(web);
                    case EmailAddressObject email:
                        return create(email);
                    case TelecomAddressObject device:
                        return create(device);
                }

                return create(o as GeographicAddressObject);
        }

        private static WebPageAddressViewModel create(WebAddressObject o) {
            var v = new WebPageAddressViewModel {
                Url = o?.DbRecord?.Address,
            };
            setCommonValues(v, o?.DbRecord?.ID, o?.DbRecord?.ValidFrom, o?.DbRecord?.ValidTo);

            return v;
        }
        private static EMailAddressViewModel create(EmailAddressObject o) {
            var v = new EMailAddressViewModel {
                EmailAddress = o?.DbRecord?.Address,
            };
            setCommonValues(v, o?.DbRecord?.ID, o?.DbRecord?.ValidFrom, o?.DbRecord?.ValidTo);

            return v;
        }
        private static TelecomAddressViewModel create(TelecomAddressObject o) {
            var v = new TelecomAddressViewModel {
                Number = o?.DbRecord?.Address,
                AreaCode = o?.DbRecord?.CityOrAreaCode,
                DeviceType = o?.DbRecord?.Device ?? TelecomDevice.NotKnown,
                CountryCode = o?.DbRecord?.RegionOrStateOrCountryCode,
                NationalDirectDialingPrefix = o?.DbRecord?.NationalDirectDialingPrefix,
                Extension = o?.DbRecord?.ZipOrPostCodeOrExtension
            };
            setCommonValues(v, o?.DbRecord?.ID, o?.DbRecord?.ValidFrom, o?.DbRecord?.ValidTo);
            if (o is null) return v;
            foreach (var c in o.RegisteredInAddresses) {
                var address = create(c);
                v.RegisteredInAddresses.Add(address);
            }

            return v;
        }
        private static GeographicAddressViewModel create(GeographicAddressObject o) {
            var v = new GeographicAddressViewModel {
                AddressLine = o?.DbRecord?.Address,
                City = o?.DbRecord?.CityOrAreaCode,
                ZipOrPostalCode = o?.DbRecord?.ZipOrPostCodeOrExtension,
                RegionOrState = o?.DbRecord?.RegionOrStateOrCountryCode,
                Country = o?.DbRecord?.CountryID
            };
            setCommonValues(v, o?.DbRecord?.ID, o?.DbRecord?.ValidFrom, o?.DbRecord?.ValidTo);
            if (o is null) return v;

            foreach (var c in o.RegisteredTelecomDevices) {
                var device = create(c);
                v.RegisteredTelecomAddresses.Add(device);
            }

            return v;
        }

        private static void setCommonValues(AddressViewModel model, string id, DateTime? validFrom,
            DateTime? validTo) {
            model.ID = id;
            model.ValidFrom = setNullIfExtremum(validFrom ?? DateTime.MinValue);
            model.ValidTo = setNullIfExtremum(validTo ?? DateTime.MaxValue);
        }
        private static DateTime? setNullIfExtremum(DateTime d) {
            if (d.Date >= DateTime.MaxValue.Date) return null;
            if (d.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return d;
        }

    }
}
