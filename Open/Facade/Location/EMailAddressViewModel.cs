using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Open.Facade.Location {

    public class EMailAddressViewModel : AddressViewModel {

        private string emailAddress;

        [Required]
        [DisplayName("Email")]
        [RegularExpression(@"(?!.*\.\.)(^[^\.][^@\s]+@[^@\s]+\.[^@\s\.]+$)")]
        public string EmailAddress {
            get => getString(ref emailAddress);
            set => emailAddress = value;
        }
        public override string ToString() {
            return EmailAddress;
        }
    }
}



