
namespace Open.Core {
    public interface IObjectsRepository<TObject, TRecord>: 
        IPaginatedRepository<TObject, TRecord>, 
        ICrudRepository<TObject> {
        bool IsInitialized();
    }
}


