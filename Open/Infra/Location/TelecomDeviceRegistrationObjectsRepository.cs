using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Data.Location;
using Open.Domain.Location;
namespace Open.Infra.Location {
    public class TelecomDeviceRegistrationObjectsRepository : ITelecomDeviceRegistrationObjectsRepository {
        private readonly DbSet<TelecomDeviceRegistrationDbRecord> dbSet;
        private readonly DbContext db;
        public TelecomDeviceRegistrationObjectsRepository(SentryDbContext c) {
            db = c;
            dbSet = c?.TelecomDeviceRegistrations;
        }
        public Task<TelecomDeviceRegistrationObject> GetObject(string id) {
            throw new NotImplementedException();
        }
        public async Task AddObject(TelecomDeviceRegistrationObject o) {
            var r = o.DbRecord;
            r.Address = null;
            r.Device = null;
            dbSet.Add(r);
            await db.SaveChangesAsync();
        }
        public async Task UpdateObject(TelecomDeviceRegistrationObject o) {
            var r = o.DbRecord;
            r.Address = null;
            r.Device = null;
            dbSet.Update(r);
            await db.SaveChangesAsync();
        }
        public async Task DeleteObject(TelecomDeviceRegistrationObject o) {
            var r = o.DbRecord;
            r.Address = null;
            r.Device = null;
            dbSet.Remove(r);
            await db.SaveChangesAsync();
        }
        public async Task LoadAddresses(TelecomAddressObject device) {
            if (device is null) return;
            var id = device.DbRecord?.ID ?? string.Empty;
            var addresses = await dbSet.Include(x => x.Address).Where(x => x.DeviceID == id)
                .AsNoTracking().ToListAsync();
            foreach (var c in addresses)
                device.RegisteredInAddress(new GeographicAddressObject(c.Address));
        }
        public async Task LoadDevices(GeographicAddressObject address) {
            if (address is null) return;
            var id = address.DbRecord?.ID ?? string.Empty;
            var devices = await dbSet.Include(x => x.Device).Where(x => x.AddressID == id)
                .AsNoTracking().ToListAsync();
            foreach (var c in devices)
                address.RegisteredTelecomDevice(new TelecomAddressObject(c.Device));
        }
        public async Task<TelecomDeviceRegistrationObject> GetObject(string adr, string dev) {
            var o = await dbSet.FirstOrDefaultAsync(
                x => x.AddressID == adr && x.DeviceID == dev);
            return new TelecomDeviceRegistrationObject(o);
        }
    }
}
