
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Location;
namespace Open.Infra.Location {
    public class AddressObjectsRepository : IAddressObjectsRepository {
        private readonly DbSet<AddressDbRecord> dbSet;
        private readonly DbContext db;
        public AddressObjectsRepository(SentryDbContext c) {
            db = c;
            dbSet = c?.Addresses;
        }
        public string SearchString { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public SortOrder SortOrder { get; set; }
        public Func<AddressDbRecord, object> SortFunction { get; set; }
        public async Task<PaginatedList<IAddressObject>> GetObjectsList() {
            var countries = getSorted().Where(s => s.Contains(SearchString)).AsNoTracking();
            var count = await countries.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await countries.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
        protected internal PaginatedList<IAddressObject> createList(
            List<AddressDbRecord> l, RepositoryPage p) {
            return new AddressObjectsList(l, p);
        }
        private IQueryable<AddressDbRecord> getSet() {
            return from s in dbSet select s;
        }
        private IQueryable<AddressDbRecord> getSorted() {
            if (SortFunction is null) return getSet();
            return SortOrder == SortOrder.Descending
                ? getSet().OrderByDescending(x => SortFunction(x))
                : getSet().OrderBy(x => SortFunction(x));
        }
        protected internal async Task<AddressDbRecord> getObject(string id)
        {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }
        public async Task<IAddressObject> GetObject(string id) {
            var r = await getObject(id);
            return AddressObjectFactory.Create(r);
        }
        public async Task AddObject(IAddressObject o) {
            if (o is WebAddressObject web) dbSet.Add(web.DbRecord);
            if (o is EmailAddressObject email) dbSet.Add(email.DbRecord);
            if (o is GeographicAddressObject adr) dbSet.Add(adr.DbRecord);
            if (o is TelecomAddressObject tel) dbSet.Add(tel.DbRecord);
            await db.SaveChangesAsync();
        }
        public async Task UpdateObject(IAddressObject o) {
            if (o is WebAddressObject web) dbSet.Update(web.DbRecord);
            if (o is EmailAddressObject email) dbSet.Update(email.DbRecord);
            if (o is GeographicAddressObject adr) dbSet.Update(adr.DbRecord);
            if (o is TelecomAddressObject tel) dbSet.Update(tel.DbRecord);
            await db.SaveChangesAsync();
        }
        public async Task DeleteObject(IAddressObject o) {
            if (o is WebAddressObject web) dbSet.Remove(web.DbRecord);
            if (o is EmailAddressObject email) dbSet.Remove(email.DbRecord);
            if (o is GeographicAddressObject adr) dbSet.Remove(adr.DbRecord);
            if (o is TelecomAddressObject tel) dbSet.Remove(tel.DbRecord);
            await db.SaveChangesAsync();
        }
        public bool IsInitialized() {
            db.Database.EnsureCreated();
            return dbSet.Any();
        }
        public async Task<IPaginatedList<IAddressObject>> GetDevicesList() {
            var countries = getSorted().Where(s => s is TelecomAddressDbRecord && s.Contains(SearchString)).AsNoTracking();
            var count = await countries.CountAsync();
            var p = new RepositoryPage(count, PageIndex, PageSize);
            var items = await countries.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync();
            return createList(items, p);
        }
    }
}


