using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.Data;

using NLayerApp.DAL.App_Setting.DB_Tables.Interfaces;
using NLayerApp.DAL.App_Setting.DB_Tables.Classes;
using NLayerApp.DAL.Repositories.Interfaces;
using NLayerApp.DAL.Repositories.Classes;
using NLayerApp.DAL.App_Setting;

namespace NLayerApp.NET
{
    public class Program
    {
        private static async Task Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((services) =>
                {
                    services.AddScoped((s) => {
                        return new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Collection_Books;Trusted_Connection=True;");
                    });
                    services.AddScoped<IDbTransaction>((s) =>
                    {
                        var conn = s.GetRequiredService<SqlConnection>();
                        conn.Open();
                        return conn.BeginTransaction();
                    });


                    // Generic_Repository
                    services.AddScoped<IBook_Repository, Book_Repository>();
                    services.AddScoped<IBookWithGenre_Repository, BookWithGenre_Repository>();
                    services.AddScoped<IGenreOfBook_Repository, GenreOfBook_Repository> ();
                    services.AddScoped<IPassword_Repository, Password_Repository>();
                    services.AddScoped<ITypeOfBook_Repository, TypeOfBook_Repository>();
                    services.AddScoped<IUser_Repository, User_Repository>();
                    services.AddScoped<IUserBook_Repository, UserBook_Repository>();
                    services.AddScoped<IUnitOfWork, UnitOfWork>();

                    // Application Setting
                    services.AddScoped<ICID_Database, DB_Collection_Books>();
                    services.AddScoped<ICID_Table_Books, TABLE_Books>();
                    services.AddScoped<ICID_Table_BooksWithGenres, TABLE_BooksWithGenres>();
                    services.AddScoped<ICID_Table_GenresOfBooks, TABLE_GenresOfBooks>();
                    services.AddScoped<ICID_Table_Passwords, TABLE_Passwords>();
                    services.AddScoped<ICID_Table_TypesOfBooks, TABLE_TypesOfBooks>();
                    services.AddScoped<ICID_Table_UserBooks, TABLE_UserBooks>();
                    services.AddScoped<ICID_Table_Users, TABLE_Users>();

                    DB_Collection_Books.services = services;
                })
                .Build();


            using (IServiceScope serviceScope = host.Services.CreateScope())
            {
                IServiceProvider provider = serviceScope.ServiceProvider;
                try
                {
                    // Створення БД/Таблиць та заповнення їх
                    //await App_Set.Setting("Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;", host.Services);


                    var temp = provider.GetRequiredService<IUnitOfWork>();
                    foreach (var t in await temp!.Users.GetAllAsync())
                        Console.WriteLine(t.Id + " " + t.NikName + " " + t.Email + " " + t.Sex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DateTime.UtcNow + " => " + "Запит до БД... Щось пішло не так: " + ex.Message);
                }
            }


            Console.WriteLine("Program work is completed...");
            Console.ReadKey();
        }
    }
}