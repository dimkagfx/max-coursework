using Open.Core;
using Open.Data.Common;
namespace Open.Domain.Common {
    public abstract class TemporalObject<T> : RootObject where T : TemporalDbRecord, new() {
        public readonly T DbRecord;
        protected TemporalObject(T dbRecord) {
            DbRecord = dbRecord ?? new T();
        }
    }
}

