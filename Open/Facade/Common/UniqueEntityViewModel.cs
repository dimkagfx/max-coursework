using Open.Core;
namespace Open.Facade.Common
{
    public class UniqueEntityViewModel: TemporalViewModel
    {
        private string id;
        public string ID {
            get => getString(ref id, Constants.Unspecified);
            set => id = value;
        }
    }
}

