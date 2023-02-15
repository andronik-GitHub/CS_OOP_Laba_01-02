using System.Data.SqlClient;
using System.Data;
using Dapper;

using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Repositories.Interfaces;


namespace NLayerApp.DAL.Repositories.Classes
{
    public class BookWithGenre_Repository : Generic_Repository_Two_Id<BookWithGenre>, IBookWithGenre_Repository
    {
        public BookWithGenre_Repository(SqlConnection connection, IDbTransaction transaction)
            : base(connection, transaction, "BooksWithGenres")
        {
        }


        public override async Task<int> CreateAsync(BookWithGenre item)
        {
            // FirstId => BookId
            // LastId => GenreId
            int id = await _connection.ExecuteScalarAsync<int>(
                $@"INSERT INTO [{_tableName}] (FirstId, LastId)
                    VALUES ({item.FirstId}, {item.LastId});
                SELECT CAST(SCOPE_IDENTITY() as int)",
                transaction: _transaction);

            return id;
        }
        public override async Task UpdateAsync(BookWithGenre item)
        {
            // FirstId => BookId
            // LastId => GenreId
            await _connection.ExecuteAsync(
                $@"UPDATE [{_tableName}]
                SET FirstId = @{item.FirstId}, 
                    LastId = @{item.LastId}
                WHERE FirstId = @{item.FirstId} AND LastId = @{item.LastId}",
                param: item,
                transaction: _transaction);
        }
    }
}
