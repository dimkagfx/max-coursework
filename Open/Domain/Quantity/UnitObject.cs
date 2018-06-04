using Open.Data.Quantity;
using Open.Domain.Common;
namespace Open.Domain.Quantity {
    public sealed class UnitObject : MetricObject<UnitDbRecord> {
        public UnitObject(UnitDbRecord r) : base(r ?? new UnitDbRecord()) { }
    }

}
