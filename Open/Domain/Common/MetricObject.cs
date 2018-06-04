using Open.Data.Common;
namespace Open.Domain.Common {
    public abstract class MetricObject<T> : IdentifiedObject<T>
        where T : IdentifiedDbRecord, new() {
        protected MetricObject(T dbRecord) : base(dbRecord) { }
    }
}


