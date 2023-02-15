using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

using NLayerApp.DAL.Entities;
using NLayerApp.DAL.App_Setting.DB_Tables.Interfaces;
using NLayerApp.DAL.Repositories.Classes;
using NLayerApp.DAL.Repositories.Interfaces;


namespace NLayerApp.DAL.App_Setting.DB_Tables.Classes
{
    public class TABLE_Users : ICID_Table_Users
    {
        public async Task Create(SqlConnection connection)
        {
            var command = new SqlCommand() { Connection = connection };

            try
            {
                command.CommandText = @"
                    CREATE TABLE [Users]
                    (
	                    [Id] INT NOT NULL IDENTITY(1000000, 1),
	                    [NikName] NVARCHAR(30) NOT NULL UNIQUE,
	                    [Email] NVARCHAR(50) NOT NULL UNIQUE,
	                    [Sex] NVARCHAR(15) NOT NULL DEFAULT N'Не визначено',
	                    [AboutMyself] NVARCHAR(1000) NULL,
	                    [RegistrationDate] SMALLDATETIME NOT NULL DEFAULT GETDATE(),

	                    PRIMARY KEY ([Id])
                    )";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Table [Users] created!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Write("\nClick to continue...");
                Console.ReadKey(); Console.Clear();
            }
        }
        public async Task Drop(SqlConnection connection)
        {
            var command = new SqlCommand() { Connection = connection };

            try
            {
                command.CommandText = @"DROP TABLE [Users]";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("The [Users] table has been deleted!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Write("\nClick to continue...");
                Console.ReadKey(); Console.Clear();
            }
        }
        public async Task Insert(SqlConnection connection)
        {
            var unitOfWork = DB_Collection_Books.services
                .BuildServiceProvider()
                .GetRequiredService<IUnitOfWork>();

            try
            {
                await unitOfWork.Users.CreateAsync(new User { NikName = "Nikname1", Email = "example1email@gmail.com", Sex = "Чоловіча" });
                await unitOfWork.Users.CreateAsync(new User { NikName = "Nikname2", Email = "example2email@gmail.com", Sex = "Жіноча" });
                await unitOfWork.Users.CreateAsync(new User { NikName = "Nikname3", Email = "example3email@gmail.com", Sex = "Жіноча" });
                await unitOfWork.Users.CreateAsync(new User { NikName = "Nikname4", Email = "example4email@gmail.com", Sex = "Чоловіча" });
                await unitOfWork.Users.CreateAsync(new User { NikName = "Nikname5", Email = "example5email@gmail.com", Sex = "Чоловіча" });
                await unitOfWork.Users.CreateAsync(new User { NikName = "Nikname6", Email = "example6email@gmail.com", Sex = "Жіноча" });
                await unitOfWork.Users.CreateAsync(new User { NikName = "Nikname7", Email = "example7email@gmail.com", Sex = "Чоловіча" });
                await unitOfWork.Users.CreateAsync(new User { NikName = "Nikname8", Email = "example8email@gmail.com", Sex = "Жіноча" });
                await unitOfWork.Users.CreateAsync(new User { NikName = "Nikname9", Email = "example9email@gmail.com", Sex = "Жіноча" });
                await unitOfWork.Users.CreateAsync(new User { NikName = "Nikname10", Email = "example10email@gmail.com", Sex = "Чоловіча" });

                unitOfWork.Save();
                Console.WriteLine("Table [Users] is filled!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Write("\nClick to continue...");
                Console.ReadKey(); Console.Clear();
            }
        }
    }
}
