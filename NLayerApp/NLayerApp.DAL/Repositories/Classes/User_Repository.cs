using System.Data.SqlClient;
using System.Data;
using Dapper;

using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Repositories.Interfaces;
using NLayerApp.DAL.App_Setting.DB_Tables.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace NLayerApp.DAL.Repositories.Classes
{
    public class User_Repository : Generic_Repository<User>, IUser_Repository
    {
        public User_Repository(SqlConnection connection, IDbTransaction transaction)
            : base(connection, transaction, "Users")
        {
        }
        
        public override async Task<int> CreateAsync(User item)
        {
            int id = await _connection.ExecuteScalarAsync<int>(
                $@"INSERT INTO [{_tableName}] (NikName, Email, Sex, AboutMyself)
                    VALUES (N'{item.NikName}',
                            N'{item.Email}',
                            N'{item.Sex}',
                            N'{item.AboutMyself}');
                SELECT SCOPE_IDENTITY();",
                transaction: _transaction);

            return id;
        }
        public override async Task UpdateAsync(User item)
        {
            await _connection.ExecuteAsync(
                $@"UPDATE [{_tableName}] 
                SET NikName = @{item.NikName}, 
                    Email = @{item.Email},
                    Sex = @{item.Sex}, 
                    AboutMyself = @{item.AboutMyself}, 
                    RegistrationDate = @{item.RegistrationDate}
                WHERE Id = @{item.Id}",
                param: item,
                transaction: _transaction);
        }
    }
}
