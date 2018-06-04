using Open.Data.Common;
namespace Open.Domain.Common {
    public abstract class UniqueObject<T> : TemporalObject<T> where T : UniqueDbRecord, new() {
        protected UniqueObject(T dbRecord) : base(dbRecord) { }
    }

}

