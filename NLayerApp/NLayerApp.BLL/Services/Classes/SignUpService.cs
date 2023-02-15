using NLayerApp.BLL.BusinessModels;
using NLayerApp.BLL.Services.Interfaces;
using NLayerApp.DAL.Repositories.Interfaces;
using NLayerApp.DAL.Entities;

namespace NLayerApp.BLL.Services.Classes
{
    public class SignUpService : IRegistrationService
    {
        public IUnitOfWork Database { get; set; }

        public SignUpService(IUnitOfWork database)
        {
            Database = database;
        }


        public async Task<bool> Authorization(SignUp reg) // авторизація(реєстрація)
        {
            try
            {
                // Додавання користувача в БД і витягування його Id
                reg.Id = await Database.Users.CreateAsync(
                    new User
                    {
                        NikName = reg.NikName,
                        Email = reg.Email,
                        Sex = reg.Sex,
                        AboutMyself = reg.AboutMyself,
                        RegistrationDate = reg.RegistrationDate
                    });
                // Додавання пароля
                await Database.Passwords.CreateAsync(
                    new Password
                    {
                        Id = reg.Id,
                        password = reg.password
                    });

                Database.Save();
                return true; // авторизація пройшла успішно
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; // авторизація не пройшла успішно
            }
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
