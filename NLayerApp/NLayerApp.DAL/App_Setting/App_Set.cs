using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

using NLayerApp.DAL.App_Setting.DB_Tables.Classes;
using NLayerApp.DAL.App_Setting.DB_Tables.Interfaces;


namespace NLayerApp.DAL.App_Setting
{
    public class App_Set
    {
        public static async Task<string> Setting(string connectionString, IServiceProvider provider)
        {
            try // створення БД
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    await DB_Set.Create(provider.GetRequiredService<ICID_Database>(), connection); // створення БД

                    // Зміна строки підключення
                    connectionString = "Server=(localdb)\\mssqllocaldb;Database=Collection_Books;Trusted_Connection=True;";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Write("\nClick to continue...");
                Console.ReadKey(); Console.Clear();
            }

            try // створення і заповнення таблиць
            {
                using (var connection = provider.GetRequiredService<SqlConnection>())
                {
                    await connection.OpenAsync();

                    // Cтворення і заповнення таблиць
                    await DB_Set.Insert(provider.GetRequiredService<ICID_Database>(), connection);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Write("\nClick to continue...");
                Console.ReadKey(); Console.Clear();
            }


            return connectionString;
        }
    }
}
