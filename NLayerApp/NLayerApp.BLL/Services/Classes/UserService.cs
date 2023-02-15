using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Services.Interfaces;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Repositories.Interfaces;

namespace NLayerApp.BLL.Services.Classes
{
    public class UserService : IUserService
    {
        private IUnitOfWork _uow { get; set; }

        public UserService(IUnitOfWork uow)
        {
            this._uow = uow;
        }


        public async Task<int> CreateAsync(User user)
        {
            int id =  await _uow.Users.CreateAsync(user);
            _uow.Save(); // commit

            return id;
        }

        public async Task<User> GetAsync(int id)
        {
            var user = await _uow.Users.GetAsync(id);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _uow.Users.GetAllAsync();
            return users;
        }

        public async Task UpdateAsync(User user)
        {
            await _uow.Users.UpdateAsync(user);
            _uow.Save(); // commit
        }

        public async Task DeleteAsync(int id)
        {
            await _uow.Users.DeleteAsync(id);
            _uow.Save(); // commit
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
