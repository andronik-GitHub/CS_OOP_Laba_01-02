using System.Data.SqlClient;
using System.Data;
using Dapper;

using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Repositories.Interfaces;


namespace NLayerApp.DAL.Repositories.Classes
{
    public class TypeOfBook_Repository : Generic_Repository<TypeOfBook>, ITypeOfBook_Repository
    {
        public TypeOfBook_Repository(SqlConnection connection, IDbTransaction transaction)
            : base(connection, transaction, "TypesOfBooks")
        {
        }


        public override async Task<int> CreateAsync(TypeOfBook item)
        {
            int id = await _connection.ExecuteScalarAsync<int>(
                $@"INSERT INTO [{_tableName}] (NameType)
                    VALUES (N'{item.NameType}');
                SELECT CAST(SCOPE_IDENTITY() as int)",
                transaction: _transaction);

            return id;
        }
        public override async Task UpdateAsync(TypeOfBook item)
        {
            await _connection.ExecuteAsync(
                $@"UPDATE [{_tableName}] 
                SET NameType = @{item.NameType}
                WHERE Id = @{item.Id}",
                param: item,
                transaction: _transaction);
        }
    }
}
