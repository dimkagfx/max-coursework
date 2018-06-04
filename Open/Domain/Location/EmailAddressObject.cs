
using Open.Data.Location;
namespace Open.Domain.Location {
    public sealed class EmailAddressObject : AddressObject<EmailAddressDbRecord> {
        public EmailAddressObject(EmailAddressDbRecord r) : base(r?? new EmailAddressDbRecord()) { }
    }
}


