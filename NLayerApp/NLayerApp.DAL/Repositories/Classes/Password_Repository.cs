using System.Data.SqlClient;
using System.Data;
using Dapper;

using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Repositories.Interfaces;


namespace NLayerApp.DAL.Repositories.Classes
{
    public class Password_Repository : Generic_Repository<Password>, IPassword_Repository
    {
        public Password_Repository(SqlConnection connection, IDbTransaction transaction)
            : base(connection, transaction, "Passwords")
        {
        }


        public override async Task<int> CreateAsync(Password item)
        {
            int id = await _connection.ExecuteScalarAsync<int>(
                $@"INSERT INTO [{_tableName}] (Id, password)
                    VALUES ({item.Id}, N'{item.password}');
                SELECT CAST(SCOPE_IDENTITY() as int)",
                transaction: _transaction);

            return id;
        }
        public override async Task UpdateAsync(Password item)
        {
            await _connection.ExecuteAsync(
                $@"UPDATE [{_tableName}] 
                SET password = @{item.password}
                WHERE Id = @{item.Id}",
                param: item,
                transaction: _transaction);
        }
    }
}
