using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Infra;
using Open.Infra.Location;
namespace Open.Tests.Infra.Location
{
    public class AddressDbTests : BaseTests
    {
        protected static SentryDbContext db;
        protected const int count = 10;
        protected readonly AddressObjectsRepository repository;
        public AddressDbTests()
        {
            if (db != null) return;
            var options = new DbContextOptionsBuilder<SentryDbContext>()
                .UseInMemoryDatabase("AddressDbTests").Options;
            db = new SentryDbContext(options);
            repository = new AddressObjectsRepository(db);
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CountryObjectsRepository);
            Assert.AreEqual(0, db.Countries.Count());
            for (var i = 0; i < count; i++)
            {
                db.Addresses.Add(getRandomAddress());
                db.SaveChanges();
            }
        }
        private AddressDbRecord getRandomAddress() {
            var i = GetRandom.Int32() % 4;
            if (i == 0) return GetRandom.Object<WebPageAddressDbRecord>();
            if (i == 1) return GetRandom.Object<EmailAddressDbRecord>();
            if (i == 2) return GetRandom.Object<TelecomAddressDbRecord>();
            return GetRandom.Object<GeographicAddressDbRecord>();
        }
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
            foreach (var c in db.Addresses)
            {
                db.Remove(c);
                db.SaveChanges();
            }

            Assert.AreEqual(0, db.Addresses.Count());
        }

    }
}
