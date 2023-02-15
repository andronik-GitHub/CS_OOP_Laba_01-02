using System.Data.SqlClient;
using System.Data;
using Dapper;

using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Repositories.Interfaces;


namespace NLayerApp.DAL.Repositories.Classes
{
    public class Book_Repository : Generic_Repository<Book>, IBook_Repository
    {
        public Book_Repository(SqlConnection connection, IDbTransaction transaction)
            : base(connection, transaction, "Books")
        {
        }


        public override async Task<int> CreateAsync(Book item)
        {
            int id = await _connection.ExecuteScalarAsync<int>(
                $@" INSERT INTO [{_tableName}] (BookTitle,
                                                TypeId,
                                                YearOfRelease,
                                                Author,
                                                AlternativeBookTitle,
                                                TitleStatus,
                                                TranslationStatus,
                                                Rating)
                    VALUES (N'{item.BookTitle}', 
                            {item.TypeId}, 
                            {item.YearOfRelease}, 
                            N'{item.Author}', 
                            N'{item.AlternativeBookTitle}', 
                            N'{item.TitleStatus}', 
                            N'{item.TranslationStatus}', 
                            {item.Rating.ToString().Replace(",",".")});
                SELECT CAST(SCOPE_IDENTITY() AS INT);",
                transaction: _transaction);
            // {item.Rating.ToString().Replace(",",".")} - тому що число може бути записане
            // через кому, а для SQL це значить що далі іде наступне значення

            return id;
        }
        public override async Task UpdateAsync(Book item)
        {
            await _connection.ExecuteAsync(
                $@"UPDATE {_tableName} 
                SET BookTitle = @{item.BookTitle}, 
                    TypeId = @{item.TypeId},
                    YearOfRelease = @{item.YearOfRelease}, 
                    Author = @{item.Author}, 
                    AlternativeBookTitle = @{item.AlternativeBookTitle}, 
                    TitleStatus = @{item.TitleStatus}, 
                    TranslationStatus = @{item.TranslationStatus}, 
                    Rating = @{item.Rating}
                WHERE Id = @{item.Id}",
                param: item,
                transaction: _transaction);
        }
    }
}
