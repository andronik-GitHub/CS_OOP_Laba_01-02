using System.Data.SqlClient;
using System.Data;
using Dapper;

using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Repositories.Interfaces;


namespace NLayerApp.DAL.Repositories.Classes
{
    public class UserBook_Repository : Generic_Repository_Two_Id<UserBook>, IUserBook_Repository
    {
        public UserBook_Repository(SqlConnection connection, IDbTransaction transaction)
            : base(connection, transaction, "UserBooks")
        {
        }


        public override async Task<int> CreateAsync(UserBook item)
        {
            // FirstId => UserId
            // LastId => BookId
            int id = await _connection.ExecuteScalarAsync<int>(
                $@"INSERT INTO [{_tableName}] ( FirstId,
                                                LastId,

                                                Reading,
                                                InThePlans,
                                                Abandoned,
                                                BeenRead,
                                                TheMostFavorite)
                    VALUES ({item.FirstId},
                            {item.LastId},

                            {(item.Reading ? 1 : 0)},
                            {(item.InThePlans ? 1 : 0)},
                            {(item.Abandoned ? 1 : 0)},
                            {(item.BeenRead ? 1 : 0)},
                            {(item.TheMostFavorite ? 1 : 0)});
                SELECT CAST(SCOPE_IDENTITY() AS INT);",
                transaction: _transaction);

            return id;
        }
        public override async Task UpdateAsync(UserBook item)
        {
            // FirstId => UserId
            // LastId => BookId
            await _connection.ExecuteAsync(
                $@"UPDATE [{_tableName}] 
                SET FirstId = @{item.FirstId}, 
                    LastId = @{item.LastId},

                    Reading = @{item.Reading},
                    InThePlans = @{item.InThePlans},
                    Abandoned = @{item.Abandoned},
                    BeenRead = @{item.BeenRead},
                    TheMostFavorite = @{item.TheMostFavorite}
                WHERE FirstId = @{item.FirstId} AND LastId = @{item.LastId}",
                param: item,
                transaction: _transaction);
        }
    }
}
