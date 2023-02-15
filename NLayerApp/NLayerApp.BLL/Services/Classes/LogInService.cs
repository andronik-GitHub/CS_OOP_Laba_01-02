using NLayerApp.BLL.BusinessModels;
using NLayerApp.BLL.Services.Interfaces;
using NLayerApp.DAL.Repositories.Interfaces;

namespace NLayerApp.BLL.Services.Classes
{
    public class LoginService : ILoginService
    {
        public IUnitOfWork Database { get; set; }

        public LoginService(IUnitOfWork database)
        {
            Database = database;
        }


        public async Task<bool> Authorization(Login reg) // авторизація(вхід)
        {
            try
            {
                var users = await Database.Users.GetAllAsync(); // витягування всіх користувачів
                bool result = users.Any(s => s.NikName == reg.NiknameOrEmail || s.Email == reg.NiknameOrEmail);

                if (!result) return false; // користувач не знайдений
                else // якщо знайшовся якийсь користувач з відповідним логіном то перевіряється пароль
                {
                    var passwords = await Database.Passwords.GetAllAsync(); // витягування всіх паролів

                    int Id = users // витягування Id користувача
                        .Where(s => s.NikName == reg.NiknameOrEmail || s.Email == reg.NiknameOrEmail)
                        .Select(s => s.Id)
                        .FirstOrDefault();

                    result = passwords.Any(s => s.Id == Id && s.password == reg.password);

                    if (!result) return false; // користувач не знайдений
                    else return true; // користувач знайдений
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; // користувач не знайдений
            }
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
