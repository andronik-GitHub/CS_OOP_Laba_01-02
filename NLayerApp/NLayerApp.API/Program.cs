using NLayerApp.DAL.App_Setting.DB_Tables.Classes;
using NLayerApp.DAL.App_Setting.DB_Tables.Interfaces;
using NLayerApp.DAL.Repositories.Classes;
using NLayerApp.DAL.Repositories.Interfaces;
using NLayerApp.DAL.App_Setting;

using System.Data.SqlClient;
using System.Data;
using NLayerApp.BLL.Services.Interfaces;
using NLayerApp.BLL.Services.Classes;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

{
    // DAL
    {

        builder.Services.AddScoped((s) => {
            return new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Collection_Books;Trusted_Connection=True;");
        });
        builder.Services.AddScoped<IDbTransaction>((s) =>
        {
            var conn = s.GetRequiredService<SqlConnection>();
            conn.Open();
            return conn.BeginTransaction();
        });


        // Generic_Repository
        builder.Services.AddScoped<IBook_Repository, Book_Repository>();
        builder.Services.AddScoped<IBookWithGenre_Repository, BookWithGenre_Repository>();
        builder.Services.AddScoped<IGenreOfBook_Repository, GenreOfBook_Repository>();
        builder.Services.AddScoped<IPassword_Repository, Password_Repository>();
        builder.Services.AddScoped<ITypeOfBook_Repository, TypeOfBook_Repository>();
        builder.Services.AddScoped<IUser_Repository, User_Repository>();
        builder.Services.AddScoped<IUserBook_Repository, UserBook_Repository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Application Setting (Для створення БД/Таблиць та заповнення їх)
        builder.Services.AddScoped<ICID_Database, DB_Collection_Books>();
        builder.Services.AddScoped<ICID_Table_Books, TABLE_Books>();
        builder.Services.AddScoped<ICID_Table_BooksWithGenres, TABLE_BooksWithGenres>();
        builder.Services.AddScoped<ICID_Table_GenresOfBooks, TABLE_GenresOfBooks>();
        builder.Services.AddScoped<ICID_Table_Passwords, TABLE_Passwords>();
        builder.Services.AddScoped<ICID_Table_TypesOfBooks, TABLE_TypesOfBooks>();
        builder.Services.AddScoped<ICID_Table_UserBooks, TABLE_UserBooks>();
        builder.Services.AddScoped<ICID_Table_Users, TABLE_Users>();
        DB_Collection_Books.services = builder.Services;
    }

    // BLL
    {
        builder.Services.AddScoped<IUserService, UserService>();
    }
}


var app = builder.Build();

// Створення БД/Таблиць та заповнення їх
//await App_Set.Setting("Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;", builder.Services);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.Run();