using System;
using Open.Core;
using Open.Data.Location;
namespace Open.Domain.Location {
    public static class AddressObjectFactory {
        public static IAddressObject Create(AddressDbRecord dbRecord) {
            switch (dbRecord) {
                case WebPageAddressDbRecord web:
                    return create(web);
                case EmailAddressDbRecord email:
                    return create(email);
                case TelecomAddressDbRecord device:
                    return create(device);
            }

            return create(dbRecord as GeographicAddressDbRecord);
        }
        private static WebAddressObject create(WebPageAddressDbRecord dbRecord) {
            return new WebAddressObject(dbRecord);
        }
        private static EmailAddressObject create(EmailAddressDbRecord dbRecord) {
            return new EmailAddressObject(dbRecord);
        }
        private static GeographicAddressObject create(GeographicAddressDbRecord dbRecord) {
            return new GeographicAddressObject(dbRecord);
        }
        private static TelecomAddressObject create(TelecomAddressDbRecord dbRecord) {
            return new TelecomAddressObject(dbRecord);
        }
        public static WebAddressObject CreateWeb(string id, string address,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var r = new WebPageAddressDbRecord {
                ID = id,
                Address = address,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new WebAddressObject(r);
        }
        public static EmailAddressObject CreateEmail(string id, string address,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var r = new EmailAddressDbRecord {
                ID = id,
                Address = address,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new EmailAddressObject(r);
        }
        public static GeographicAddressObject CreateAddress(string id, string addressLine,
            string city, string regionOrState, string zipOrPostalCode, string countryId,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var r = new GeographicAddressDbRecord {
                ID = id,
                Address = addressLine,
                ZipOrPostCodeOrExtension = zipOrPostalCode,
                RegionOrStateOrCountryCode = regionOrState,
                CityOrAreaCode = city,
                CountryID = countryId,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new GeographicAddressObject(r);
        }
        public static TelecomAddressObject CreateDevice(string id, string countryCode,
            string areaCode,
            string number, string extension, string nationalDirectDialingPrefix,
            TelecomDevice deviceType,
            DateTime? validFrom = null, DateTime? validTo = null) {
            var r = new TelecomAddressDbRecord {
                ID = id,
                Address = number,
                ZipOrPostCodeOrExtension = extension,
                RegionOrStateOrCountryCode = countryCode,
                CityOrAreaCode = areaCode,
                NationalDirectDialingPrefix = nationalDirectDialingPrefix,
                Device = deviceType,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new TelecomAddressObject(r);
        }
    }
}





