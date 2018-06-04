using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Data.Location;
namespace Open.Tests.Infra.Location
{
    class AddressObjectsRepositoryTests
    {
        private static void validateAddress(AddressDbRecord actual, AddressDbRecord expected)
        {
            Assert.AreEqual(actual.ID, expected.ID);
            Assert.AreEqual(actual.Address, expected.Address);
            Assert.AreEqual(actual.CityOrAreaCode, expected.CityOrAreaCode);
            Assert.AreEqual(actual.RegionOrStateOrCountryCode, expected.RegionOrStateOrCountryCode);
            Assert.AreEqual(actual.ZipOrPostCodeOrExtension, expected.ZipOrPostCodeOrExtension);
            Assert.AreEqual(actual.ValidFrom, expected.ValidFrom);
            Assert.AreEqual(actual.ValidTo, expected.ValidTo);
            validateTelecomAddress(actual as TelecomAddressDbRecord,
                expected as TelecomAddressDbRecord);
            validateGeographivAddress(actual as GeographicAddressDbRecord,
                expected as GeographicAddressDbRecord);
        }
        private static void validateGeographivAddress(GeographicAddressDbRecord actual, GeographicAddressDbRecord expected)
        {
            if (!(actual is null))
                Assert.AreEqual(actual.CountryID, expected.CountryID);
            else Assert.IsNull(expected);
        }
        private static void validateTelecomAddress(TelecomAddressDbRecord actual, TelecomAddressDbRecord expected)
        {
            if (!(actual is null))
            {
                Assert.AreEqual(actual.Device, expected.Device);
                Assert.AreEqual(actual.NationalDirectDialingPrefix, expected.NationalDirectDialingPrefix);
            }
            else Assert.IsNull(expected);
        }
    }
}
