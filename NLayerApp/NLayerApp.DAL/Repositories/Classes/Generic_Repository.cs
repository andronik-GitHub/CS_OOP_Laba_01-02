using System.Data.SqlClient;
using System.Data;
using Dapper;

using NLayerApp.DAL.Repositories.Interfaces;
using NLayerApp.DAL.App_Setting.DB_Tables.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace NLayerApp.DAL.Repositories.Classes
{
    public class Generic_Repository<T> : IGeneric_Repository<T> where T : class
    {
        protected SqlConnection _connection;
        protected IDbTransaction _transaction;
        protected readonly string _tableName;

        public Generic_Repository(
            SqlConnection connection, 
            IDbTransaction transaction, 
            string tableName)
        {
            _connection = connection;
            _transaction = transaction;
            _tableName = tableName;
        }


        public virtual async Task<int> CreateAsync(T item)
        {
            return await Task.FromResult(0);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _connection.QueryAsync<T>($"SELECT * FROM [{_tableName}]", transaction: _transaction);
        }
        public virtual async Task<T> GetAsync(int id)
        {
            var result = await _connection.QuerySingleOrDefaultAsync<T>($"SELECT * FROM [{_tableName}] WHERE Id=@Id",
                param: new { Id = id },
                transaction: _transaction);

            if (result == null) throw new Exception($"Error in: public virtual async Task<{typeof(T).Name}> GetAsync(int id)");
            else return result;
        }
        public virtual Task UpdateAsync(T item)
        {
            return Task.CompletedTask;
        }
        public virtual async Task DeleteAsync(int id)
        {
            await _connection.ExecuteAsync($"DELETE FROM [{_tableName}] WHERE Id=@Id",
                param: new { Id = id },
                transaction: _transaction);

            _transaction.Commit();
        }
    }
}
