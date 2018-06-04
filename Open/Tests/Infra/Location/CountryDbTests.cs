using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Infra;
using Open.Infra.Location;
namespace Open.Tests.Infra.Location {
    public class CountryDbTests : BaseTests {
        protected static SentryDbContext db;
        protected static CountryObjectsRepository repository;
        protected const int count = 10;
        public CountryDbTests() {
            if (db != null) return;
            var options = new DbContextOptionsBuilder<SentryDbContext>()
                .UseInMemoryDatabase("CountryDbTests").Options;
            db = new SentryDbContext(options);
            repository = new CountryObjectsRepository(db);
        }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            Assert.AreEqual(0, db.Countries.Count());
            for (var i = 0; i < count; i++) {
                db.Countries.Add(GetRandom.Object<CountryDbRecord>());
                db.SaveChanges();
            }
        }

        [TestCleanup] public override void TestCleanup() {
            base.TestCleanup();
            foreach (var c in db.Countries) {
                db.Remove(c);
                db.SaveChanges();
            }

            Assert.AreEqual(0, db.Countries.Count());
        }
    }
}
