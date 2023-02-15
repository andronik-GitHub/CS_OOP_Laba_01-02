using System.Data.SqlClient;
using System.Data;
using Dapper;

using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Repositories.Interfaces;


namespace NLayerApp.DAL.Repositories.Classes
{
    public class GenreOfBook_Repository : Generic_Repository<GenreOfBook>, IGenreOfBook_Repository
    {
        public GenreOfBook_Repository(SqlConnection connection, IDbTransaction transaction)
            : base(connection, transaction, "GenresOfBooks")
        {
        }


        public override async Task<int> CreateAsync(GenreOfBook item)
        {
            int id = await _connection.ExecuteScalarAsync<int>(
                $@"INSERT INTO {_tableName} (NameGenre)
                    VALUES (N'{item.NameGenre}');
                SELECT CAST(SCOPE_IDENTITY() as int)",
                transaction: _transaction);

            return id;
        }
        public override async Task UpdateAsync(GenreOfBook item)
        {
            await _connection.ExecuteAsync(
                $@"UPDATE {_tableName} 
                SET NameGenre = @{item.NameGenre}
                WHERE Id = @{item.Id}",
                param: item,
                transaction: _transaction);
        }
    }
}
