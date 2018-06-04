using Open.Data.Quantity;
using Open.Domain.Common;
namespace Open.Domain.Quantity {
    public sealed class MeasureObject : MetricObject<MeasureDbRecord> {
        public MeasureObject(MeasureDbRecord r) : base(r ?? new MeasureDbRecord()) { }
    }

}



