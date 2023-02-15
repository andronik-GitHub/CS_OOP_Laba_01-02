using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

using NLayerApp.DAL.Entities;
using NLayerApp.DAL.App_Setting.DB_Tables.Interfaces;
using NLayerApp.DAL.Repositories.Classes;
using NLayerApp.DAL.Repositories.Interfaces;

namespace NLayerApp.DAL.App_Setting.DB_Tables.Classes
{
    public class TABLE_UserBooks : ICID_Table_UserBooks
    {
        public async Task Create(SqlConnection connection)
        {
            var command = new SqlCommand() { Connection = connection };

            try
            {
                // FirstId => UserId
                // LastId => BookId
                command.CommandText = @"
                    CREATE TABLE [UserBooks]
                    (
	                    [FirstId] INT NOT NULL,
	                    [LastId] INT NOT NULL,

	                    [Reading] BIT NOT NULL DEFAULT 0,
	                    [InThePlans] BIT NOT NULL DEFAULT 0,
	                    [Abandoned] BIT NOT NULL DEFAULT 0,
	                    [BeenRead] BIT NOT NULL DEFAULT 0,
	                    [TheMostFavorite] BIT NOT NULL DEFAULT 0,

	                    PRIMARY KEY([FirstId],[LastId]),
	                    CONSTRAINT FK_UserBooks_To_Books FOREIGN KEY([LastId])
		                    REFERENCES [Books] ([Id]) ON DELETE CASCADE,
	                    CONSTRAINT FK_UserBooks_To_Users FOREIGN KEY([FirstId])
		                    REFERENCES [Users] ([Id]) ON DELETE CASCADE
                    )";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Table [UserBooks] created!");
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
                command.CommandText = @"DROP TABLE [UserBooks]";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Table [UserBooks] has been deleted!");
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
                await unitOfWork.UserBook.CreateAsync(new UserBook { FirstId = 1000002, LastId = 1000005, Reading = false,  InThePlans = false, Abandoned = false,  BeenRead = false,   TheMostFavorite = false });
                await unitOfWork.UserBook.CreateAsync(new UserBook { FirstId = 1000007, LastId = 1000001, Reading = false,  InThePlans = true,  Abandoned = false,  BeenRead = false,   TheMostFavorite = false });
                await unitOfWork.UserBook.CreateAsync(new UserBook { FirstId = 1000004, LastId = 1000009, Reading = true,   InThePlans = false, Abandoned = false,  BeenRead = false,   TheMostFavorite = true });
                await unitOfWork.UserBook.CreateAsync(new UserBook { FirstId = 1000004, LastId = 1000007, Reading = false,  InThePlans = false, Abandoned = false,  BeenRead = true,    TheMostFavorite = false });
                await unitOfWork.UserBook.CreateAsync(new UserBook { FirstId = 1000006, LastId = 1000009, Reading = false,  InThePlans = false, Abandoned = true,   BeenRead = false,   TheMostFavorite = false });
                await unitOfWork.UserBook.CreateAsync(new UserBook { FirstId = 1000001, LastId = 1000004, Reading = true,   InThePlans = false, Abandoned = false,  BeenRead = false,   TheMostFavorite = false });
                await unitOfWork.UserBook.CreateAsync(new UserBook { FirstId = 1000005, LastId = 1000008, Reading = true,   InThePlans = false, Abandoned = false,  BeenRead = false,   TheMostFavorite = false });
                await unitOfWork.UserBook.CreateAsync(new UserBook { FirstId = 1000002, LastId = 1000003, Reading = true,   InThePlans = false, Abandoned = false,  BeenRead = false,   TheMostFavorite = true });

                unitOfWork.Save();
                Console.WriteLine("Table [UserBooks] is filled!");
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
