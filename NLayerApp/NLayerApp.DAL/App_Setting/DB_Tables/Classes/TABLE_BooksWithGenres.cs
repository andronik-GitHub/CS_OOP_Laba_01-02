using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

using NLayerApp.DAL.Entities;
using NLayerApp.DAL.App_Setting.DB_Tables.Interfaces;
using NLayerApp.DAL.Repositories.Classes;
using NLayerApp.DAL.Repositories.Interfaces;

namespace NLayerApp.DAL.App_Setting.DB_Tables.Classes
{
    public class TABLE_BooksWithGenres : ICID_Table_BooksWithGenres
    {
        public async Task Create(SqlConnection connection)
        {
            var command = new SqlCommand() { Connection = connection };

            try
            {
                // FirstId => BookId
                // LastId => GenreId
                command.CommandText = @"
                    CREATE TABLE [BooksWithGenres]
                    (
	                    [FirstId] INT NOT NULL,
	                    [LastId] INT NOT NULL,
	
	                    PRIMARY KEY ([FirstId],[LastId]),
	                    CONSTRAINT FK_BooksWithGenres_To_GenresOfBooks FOREIGN KEY([LastId])
		                    REFERENCES [GenresOfBooks] ([Id]) ON DELETE CASCADE,
	                    CONSTRAINT FK_BooksWithGenres_To_Books FOREIGN KEY([FirstId])
		                    REFERENCES [Books] ([Id]) ON DELETE CASCADE
                    )";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Table [BooksWithGenres] created!");
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
                command.CommandText = @"DROP TABLE [BookWithGenre]";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Table [BookWithGenre] has been deleted!");
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
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000000, LastId = 10000 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000000, LastId = 10004 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000000, LastId = 10006 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000000, LastId = 10003 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000001, LastId = 10000 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000001, LastId = 10004 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000001, LastId = 10006 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000001, LastId = 10003 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000002, LastId = 10004 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000002, LastId = 10001 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000002, LastId = 10008 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000002, LastId = 10005 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000003, LastId = 10000 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000003, LastId = 10004 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000003, LastId = 10006 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000003, LastId = 10009 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000004, LastId = 10000 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000004, LastId = 10004 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000004, LastId = 10006 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000004, LastId = 10009 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000005, LastId = 10000 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000005, LastId = 10004 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000005, LastId = 10006 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000005, LastId = 10009 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000006, LastId = 10000 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000006, LastId = 10007 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000007, LastId = 10000 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000007, LastId = 10007 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000008, LastId = 10001 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000008, LastId = 10004 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000009, LastId = 10001 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000009, LastId = 10004 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000009, LastId = 10005 });
                await unitOfWork.BooksWithGenre.CreateAsync(new BookWithGenre { FirstId = 1000009, LastId = 10007 });

                unitOfWork.Save();
                Console.WriteLine("Table [BookWithGenre] is filled!");
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
