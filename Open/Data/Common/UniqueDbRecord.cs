
namespace Open.Data.Common {
    public abstract class UniqueDbRecord : TemporalDbRecord {

        protected string id;

        public virtual string ID {
            get => getString(ref id);
            set => id = value;
        }
    }
}


