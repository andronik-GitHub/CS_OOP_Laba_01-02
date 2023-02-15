namespace NLayerApp.DAL.Repositories.Interfaces
{
    public interface IGeneric_Repository<T>
    {
        Task<int> CreateAsync(T item);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
    }
}
