using Open.Data.Common;
namespace Open.Domain.Common {
    public abstract class IdentifiedObject<T> : UniqueObject<T>
        where T : IdentifiedDbRecord, new() {
        protected IdentifiedObject(T dbRecord) : base(dbRecord) { }
    }
}



