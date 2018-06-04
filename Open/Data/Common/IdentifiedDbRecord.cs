using Open.Core;

namespace Open.Data.Common {
    public abstract class IdentifiedDbRecord : UniqueDbRecord {
        private string code;
        private string name;

        public string Code {
            get => getString(ref code);
            set => code = value;
        }

        public string Name {
            get => getString(ref name, Code);
            set => name = value;
        }

        public override string ID {
            get => getString(ref id, Name);
            set => id = value;
        }

        //public override bool Contains(ref string searchString) {
        //    return base.Contains(ref searchString)
        //           || Name.ToLower().Contains(searchString)
        //           || Code.ToLower().Contains(searchString);
        //}
    }
}


