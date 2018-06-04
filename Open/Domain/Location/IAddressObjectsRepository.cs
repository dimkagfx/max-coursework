using System.Threading.Tasks;
using Open.Core;
using Open.Data.Location;
namespace Open.Domain.Location {
    public interface IAddressObjectsRepository : IObjectsRepository<IAddressObject, AddressDbRecord> {
        Task<IPaginatedList<IAddressObject>> GetDevicesList();
    }
}



