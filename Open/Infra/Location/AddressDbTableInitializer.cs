using System;
using System.Collections.Generic;
using System.Linq;
using Open.Aids;
using Open.Core;
using Open.Data.Location;
namespace Open.Infra.Location {
    public static class AddressDbTableInitializer {
        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Addresses.Any()) return;
            initWebPageAddresses(c);
            initEmailAddresses(c);
            var geographicIDs = initGeographicAddresses(c);
            var telecomIDs = initTelecomAddresses(c);
            initTelecomRegistrations(c, geographicIDs, telecomIDs);
            c.SaveChanges();
        }

        private static void initTelecomRegistrations(SentryDbContext c, List<string> geographicIDs, List<string> telecomIDs) {
            foreach (var a in geographicIDs) {
                foreach (var d in telecomIDs) {
                    if (GetRandom.Bool()) continue;
                    c.TelecomDeviceRegistrations.Add(new TelecomDeviceRegistrationDbRecord {AddressID = a, DeviceID = d});
                }
            }
        }

        private static List<string> initTelecomAddresses(SentryDbContext c) {
            var l = new List<string> {
                add(c, new TelecomAddressDbRecord{Address = "22222222",
                    CityOrAreaCode = "51",
                    RegionOrStateOrCountryCode = "372",
                    Device = TelecomDevice.Mobile
                }),
                add(c, new TelecomAddressDbRecord{Address = "1111111",
                    CityOrAreaCode = "52",
                    RegionOrStateOrCountryCode = "372",
                    Device = TelecomDevice.Mobile
                }),
                add(c, new TelecomAddressDbRecord{Address = "3333333",
                    CityOrAreaCode = "60",
                    RegionOrStateOrCountryCode = "372",
                    Device = TelecomDevice.Phone
                }),
                add(c, new TelecomAddressDbRecord{Address = "4444444",
                    CityOrAreaCode = "61",
                    RegionOrStateOrCountryCode = "372",
                    Device = TelecomDevice.Fax
                })
            };
            return l;
        }

        private static List<string> initGeographicAddresses(SentryDbContext c) {
            var l = new List<string> {
                add(c, new GeographicAddressDbRecord {Address = "Akadeemia tee 15A",
                    CityOrAreaCode = "Tallinn",
                    RegionOrStateOrCountryCode = "Harjumaa",
                    CountryID = "EST",
                    ZipOrPostCodeOrExtension = "12618"
                }),
                add(c, new GeographicAddressDbRecord {Address = "Raja 4C",
                    CityOrAreaCode = "Tallinn",
                    RegionOrStateOrCountryCode = "Harjumaa",
                    CountryID = "EST",
                    ZipOrPostCodeOrExtension = "12616"
                }),
                add(c, new GeographicAddressDbRecord {Address = "Ehitajate tee 5",
                    CityOrAreaCode = "Tallinn",
                    RegionOrStateOrCountryCode = "Harjumaa",
                    CountryID = "EST",
                    ZipOrPostCodeOrExtension = "12618"
                })
            };
            add(c, new GeographicAddressDbRecord {
                Address = "4 Privet Drive",
                CityOrAreaCode = "Little Whinging",
                RegionOrStateOrCountryCode = "Surrey",
                CountryID = "GBR",
                ZipOrPostCodeOrExtension = "BS13 9RN"
            });
            return l;
        }

        private static void initEmailAddresses(SentryDbContext c) {
            add(c, new EmailAddressDbRecord { Address = "Harry.Potter@hogwarts.edu" });
            add(c, new EmailAddressDbRecord { Address = "Hermione.Granger@hogwarts.edu" });
            add(c, new EmailAddressDbRecord { Address = "Ron.Weasley@hogwarts.edu" });
            add(c, new EmailAddressDbRecord { Address = "Albus.Dumbledore@hogwarts.edu" });
        }

        private static void initWebPageAddresses(SentryDbContext c) {
            add(c, new WebPageAddressDbRecord {Address = "www.visualstudio.com" });
            add(c, new WebPageAddressDbRecord { Address = "www.jetbrains.com" });
            add(c, new WebPageAddressDbRecord { Address = "www.wikipedia.org" });
            add(c, new WebPageAddressDbRecord { Address = "www.amazon.com" });
        }

        private static string add(SentryDbContext c, AddressDbRecord address) {
            address.ID = Guid.NewGuid().ToString();
            c.Addresses.Add(address);
            return address.ID;
        }
    }
}


