using System.Linq;
using Microsoft.EntityFrameworkCore;
using Open.Core;
using Open.Data.Common;
using Open.Domain.Common;
namespace Open.Infra {

    public abstract class
        ObjectsRepository<TObject, TRecord> : PaginatedRepository<TObject, TRecord>, IObjectsRepository<TObject, TRecord>
        where TObject : UniqueObject<TRecord>
        where TRecord : UniqueDbRecord, new() {
        protected ObjectsRepository(DbSet<TRecord> s, DbContext c) : base(s, c) { }

        public bool IsInitialized() {
            db.Database.EnsureCreated();
            return dbSet.Any();
        }
    }
}
