using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

using NLayerApp.DAL.App_Setting.DB_Tables.Interfaces;


namespace NLayerApp.DAL.App_Setting.DB_Tables.Classes
{
    public class DB_Collection_Books : ICID_Database
    {
        public static IServiceCollection services = new ServiceCollection();

        public async Task Create(SqlConnection connection) // створення БД
        {
            var command = new SqlCommand() { Connection = connection };

            try
            {
                command.CommandText = "CREATE DATABASE [Collection_Books]";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Database [Collection_Books] created!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Write("\nClick to continue...");
                Console.ReadKey(); Console.Clear();
            }
        }
        public async Task Drop(SqlConnection connection) // видалення БД
        {
            var command = new SqlCommand() { Connection = connection };

            try
            {
                command.CommandText = "DROP DATABASE [Collection_Books]";

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Database [Collection_Books] deleted!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Write("\nClick to continue...");
                Console.ReadKey(); Console.Clear();
            }
        }
        public async Task Insert(SqlConnection connection) // створення та заповнення таблиць
        {
            await DB_Set.CreateAll(services.BuildServiceProvider(), connection);
            await DB_Set.InsertAll(services.BuildServiceProvider(), connection);
        }
    }
}
