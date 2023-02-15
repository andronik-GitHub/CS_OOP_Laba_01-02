using System.Data.SqlClient;
using System.Data;
using Dapper;

using NLayerApp.DAL.Repositories.Interfaces;


namespace NLayerApp.DAL.Repositories.Classes
{
    // Для таблиць з двома ключовими полями
    public class Generic_Repository_Two_Id<T> : IGeneric_Repository<T> where T : class
    {
        protected SqlConnection _connection;
        protected IDbTransaction _transaction;
        protected readonly string _tableName;


        public Generic_Repository_Two_Id(
            SqlConnection connection,
            IDbTransaction transaction,
            string tableName)
        {
            _connection = connection;
            _transaction = transaction;
            _tableName = tableName;
        }


        public virtual Task<int> CreateAsync(T item)
        {
            return Task.FromResult(0);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _connection.QueryAsync<T>($"SELECT * FROM {_tableName}", transaction: _transaction);
        }
        public async Task<T> GetAsync(int id)
        {
            var result = await _connection.QuerySingleOrDefaultAsync<T>(
                $@"SELECT * FROM {_tableName} WHERE FirstId = @FirstId AND LastId = @LastId",
                param: new { Id = id },
                transaction: _transaction);

            if (result == null)
                throw new Exception("");
            else
                return result;
        }
        public virtual Task UpdateAsync(T item)
        {
            return Task.CompletedTask;
        }
        public async Task DeleteAsync(int id)
        {
            await _connection.ExecuteAsync(
                $"DELETE FROM {_tableName} WHERE FirstId = @FirstId AND LastId = @LastId",
                param: new { Id = id },
                transaction: _transaction);
        }
    }
}
