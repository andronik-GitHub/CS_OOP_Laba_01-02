using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

using NLayerApp.DAL.Entities;
using NLayerApp.DAL.App_Setting.DB_Tables.Interfaces;
using NLayerApp.DAL.Repositories.Classes;
using NLayerApp.DAL.Repositories.Interfaces;


namespace NLayerApp.DAL.App_Setting.DB_Tables.Classes
{
    public class TABLE_Passwords : ICID_Table_Passwords
    {
        public async Task Create(SqlConnection connection)
        {
            var command = new SqlCommand() { Connection = connection };

            try
            {
                command.CommandText = @"
                    CREATE TABLE [Passwords]
                    (
	                    [Id] INT NOT NULL,
	                    [password] NVARCHAR(30) NOT NULL,
	
	                    PRIMARY KEY ([Id]),
	                    CONSTRAINT FK_Passwords_To_Users FOREIGN KEY([Id])
		                    REFERENCES [Users] ([Id]) ON DELETE CASCADE
                    )";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Table [Passwords] created!");
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
                command.CommandText = @"DROP TABLE [Passwords]";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Table [Passwords] has been deleted!");
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
                await unitOfWork.Passwords.CreateAsync(new Password { Id = 1000000, password = "qwerty123456" });
                await unitOfWork.Passwords.CreateAsync(new Password { Id = 1000001, password = "qwerty123456" });
                await unitOfWork.Passwords.CreateAsync(new Password { Id = 1000002, password = "qwerty123456" });
                await unitOfWork.Passwords.CreateAsync(new Password { Id = 1000003, password = "qwerty123456" });
                await unitOfWork.Passwords.CreateAsync(new Password { Id = 1000004, password = "qwerty123456" });
                await unitOfWork.Passwords.CreateAsync(new Password { Id = 1000005, password = "qwerty123456" });
                await unitOfWork.Passwords.CreateAsync(new Password { Id = 1000006, password = "qwerty123456" });
                await unitOfWork.Passwords.CreateAsync(new Password { Id = 1000007, password = "qwerty123456" });
                await unitOfWork.Passwords.CreateAsync(new Password { Id = 1000008, password = "qwerty123456" });
                await unitOfWork.Passwords.CreateAsync(new Password { Id = 1000009, password = "qwerty123456" });

                unitOfWork.Save();
                Console.WriteLine("Table [Passwords] is filled!");
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
