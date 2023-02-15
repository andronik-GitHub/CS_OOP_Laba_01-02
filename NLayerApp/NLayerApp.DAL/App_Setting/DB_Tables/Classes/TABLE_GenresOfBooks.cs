using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

using NLayerApp.DAL.Entities;
using NLayerApp.DAL.App_Setting.DB_Tables.Interfaces;
using NLayerApp.DAL.Repositories.Classes;
using NLayerApp.DAL.Repositories.Interfaces;

namespace NLayerApp.DAL.App_Setting.DB_Tables.Classes
{
    public class TABLE_GenresOfBooks : ICID_Table_GenresOfBooks
    {
        public async Task Create(SqlConnection connection)
        {
            var command = new SqlCommand() { Connection = connection };

            try
            {
                command.CommandText = @"
                    CREATE TABLE [GenresOfBooks]
                    (
	                    [Id] INT NOT NULL IDENTITY(10000,1),
	                    [NameGenre] NVARCHAR(50) NOT NULL,
	
	                    PRIMARY KEY ([Id])
                    )";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Table [GenresOfBooks] created!");
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
                command.CommandText = @"DROP TABLE [GenresOfBooks]";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Table [GenresOfBooks] has been deleted!");
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
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Фентезі" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Детективи" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Еротика" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Жахи" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Пригоди" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Поезії" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Фантастика" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Романи" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Трилери" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Комікси і манга" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Проза" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Бізнес-література" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Психологія" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Мистецтво та культура" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Научна література" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Хоббі та дозвілля" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Вивчення мов" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Комп''ютерна література" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Історія" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Суспільство" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Мемуари" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Красота та здоров''я" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Драма" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Комедія" });
                await unitOfWork.GenresOfBooks.CreateAsync(new GenreOfBook { NameGenre = "Постапокаліпсис" });

                unitOfWork.Save();
                Console.WriteLine("Table [GenresOfBooks] is filled!");
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
