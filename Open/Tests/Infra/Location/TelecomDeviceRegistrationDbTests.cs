using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Location;
using Open.Infra;
using Open.Infra.Location;
namespace Open.Tests.Infra.Location {
    public class TelecomDeviceRegistrationDbTests : BaseTests
    {
        protected static SentryDbContext db;
        protected static TelecomDeviceRegistrationObjectsRepository repository;
        protected const int count = 10;
        public TelecomDeviceRegistrationDbTests()
        {
            if (db != null) return;
            var options = new DbContextOptionsBuilder<SentryDbContext>()
                .UseInMemoryDatabase("TelecomDbTests").Options;
            db = new SentryDbContext(options);
            repository = new TelecomDeviceRegistrationObjectsRepository(db);
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Assert.AreEqual(0, db.TelecomDeviceRegistrations.Count());
            for (var i = 0; i < count; i++)
            {
                db.TelecomDeviceRegistrations.Add(GetRandom.Object<TelecomDeviceRegistrationDbRecord>());
                db.SaveChanges();
            }
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
            foreach (var c in db.TelecomDeviceRegistrations)
            {
                db.Remove(c);
                db.SaveChanges();
            }

            Assert.AreEqual(0, db.TelecomDeviceRegistrations.Count());
        }
    }
}


