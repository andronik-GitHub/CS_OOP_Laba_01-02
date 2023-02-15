using NLayerApp.DAL.Entities;

namespace NLayerApp.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateAsync(User item);
        Task<User> GetAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task UpdateAsync(User item);
        Task DeleteAsync(int id);
        void Dispose();
    }
}
