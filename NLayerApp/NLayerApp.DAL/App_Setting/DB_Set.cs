using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using NLayerApp.DAL.App_Setting.DB_Tables.Interfaces;


namespace NLayerApp.DAL.App_Setting
{
    public class DB_Set
    {
        public static async Task Create(ICreateInsertDrop item, SqlConnection connection) => await item.Create(connection); // створення БД/таблиці
        public static async Task Insert(ICreateInsertDrop item, SqlConnection connection) => await item.Insert(connection); // заповнення таблиці
        public static async Task Drop(ICreateInsertDrop item, SqlConnection connection) => await item.Drop(connection); // видалення БД/таблиці
    
        public static async Task CreateAll(IServiceProvider serviceProv, SqlConnection connection) // створення всіх таблиць
        {
            await Create(serviceProv.GetRequiredService<ICID_Table_Users>(), connection); // створення таблиці [Users]
            await Create(serviceProv.GetRequiredService<ICID_Table_Passwords>(), connection); // створення таблиці [Passwords]
            await Create(serviceProv.GetRequiredService<ICID_Table_GenresOfBooks>(), connection); // створення таблиці [GenresOfBooks]
            await Create(serviceProv.GetRequiredService<ICID_Table_TypesOfBooks>(), connection); // створення таблиці [TypesOfBooks]
            await Create(serviceProv.GetRequiredService<ICID_Table_Books>(), connection); // створення таблиці [Books]
            await Create(serviceProv.GetRequiredService<ICID_Table_BooksWithGenres>(), connection); // створення таблиці [BooksWithGenres]
            await Create(serviceProv.GetRequiredService<ICID_Table_UserBooks>(), connection); // створення таблиці [UserBooks]
        }
        public static async Task InsertAll(IServiceProvider serviceProv, SqlConnection connection) // заповнення всіх таблиць
        {
            await Insert(serviceProv.GetRequiredService<ICID_Table_Users>(), connection); // заповнення таблиці [Users]
            await Insert(serviceProv.GetRequiredService<ICID_Table_Passwords>(), connection); // заповнення таблиці [Passwords]
            await Insert(serviceProv.GetRequiredService<ICID_Table_TypesOfBooks>(), connection); // заповнення таблиці [TypesOfBooks]
            await Insert(serviceProv.GetRequiredService<ICID_Table_Books>(), connection); // заповнення таблиці [Books]
            await Insert(serviceProv.GetRequiredService<ICID_Table_GenresOfBooks>(), connection); // заповнення таблиці [GenresOfBooks]
            await Insert(serviceProv.GetRequiredService<ICID_Table_BooksWithGenres>(), connection); // заповнення таблиці [BooksWithGenres]
            await Insert(serviceProv.GetRequiredService<ICID_Table_UserBooks>(), connection); // заповнення таблиці [UserBooks]
        }
        public static async Task DropAll(IServiceProvider serviceProv, SqlConnection connection) // видалення всіх таблиць
        {
            await Drop(serviceProv.GetRequiredService<ICID_Table_UserBooks>(), connection); // видалення таблиці [UserBooks]
            await Drop(serviceProv.GetRequiredService<ICID_Table_BooksWithGenres>(), connection); // видалення таблиці [BooksWithGenres]
            await Drop(serviceProv.GetRequiredService<ICID_Table_Books>(), connection); // видалення таблиці [Books]
            await Drop(serviceProv.GetRequiredService<ICID_Table_TypesOfBooks>(), connection); // видалення таблиці [TypesOfBooks]
            await Drop(serviceProv.GetRequiredService<ICID_Table_GenresOfBooks>(), connection); // видалення таблиці [GenresOfBooks]
            await Drop(serviceProv.GetRequiredService<ICID_Table_Passwords>(), connection); // видалення таблиці [Passwords]
            await Drop(serviceProv.GetRequiredService<ICID_Table_Users>(), connection); // видалення таблиці [Users]
        }
    }
}
