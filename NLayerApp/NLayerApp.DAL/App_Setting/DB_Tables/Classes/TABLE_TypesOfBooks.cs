using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

using NLayerApp.DAL.Entities;
using NLayerApp.DAL.App_Setting.DB_Tables.Interfaces;
using NLayerApp.DAL.Repositories.Classes;
using NLayerApp.DAL.Repositories.Interfaces;

namespace NLayerApp.DAL.App_Setting.DB_Tables.Classes
{
    public class TABLE_TypesOfBooks : ICID_Table_TypesOfBooks
    {
        public async Task Create(SqlConnection connection)
        {
            var command = new SqlCommand() { Connection = connection };

            try
            {
                command.CommandText = @"
                    CREATE TABLE [TypesOfBooks]
                    (
	                    [Id] INT NOT NULL IDENTITY(1000, 1),
	                    [NameType] NVARCHAR(20) NOT NULL UNIQUE,
	
	                    PRIMARY KEY ([Id])
                    )";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Table [TypesOfBooks] created!");
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
                command.CommandText = @"DROP TABLE [TypesOfBooks]";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Table [TypesOfBooks] has been deleted!");
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
                await unitOfWork.TypesOfBooks.CreateAsync(new TypeOfBook { NameType = "Книга" });
                await unitOfWork.TypesOfBooks.CreateAsync(new TypeOfBook { NameType = "Комікс" });
                await unitOfWork.TypesOfBooks.CreateAsync(new TypeOfBook { NameType = "Манга" });
                await unitOfWork.TypesOfBooks.CreateAsync(new TypeOfBook { NameType = "Журнал" });
                await unitOfWork.TypesOfBooks.CreateAsync(new TypeOfBook { NameType = "Газета" });

                unitOfWork.Save();
                Console.WriteLine("Table [TypesOfBooks] is filled!");
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
