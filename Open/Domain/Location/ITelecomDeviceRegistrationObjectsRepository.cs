using System.Threading.Tasks;
using Open.Core;
namespace Open.Domain.Location {

    public interface
        ITelecomDeviceRegistrationObjectsRepository : ICrudRepository<
            TelecomDeviceRegistrationObject> {
        Task LoadAddresses(TelecomAddressObject device);
        Task LoadDevices(GeographicAddressObject address);
        Task<TelecomDeviceRegistrationObject> GetObject(string adr, string dev);
    }

}

