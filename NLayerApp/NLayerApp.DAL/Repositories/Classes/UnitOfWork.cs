using System.Data;

using NLayerApp.DAL.App_Setting.DB_Tables.Interfaces;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Repositories.Interfaces;


namespace NLayerApp.DAL.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUser_Repository Users { get; }
        public IPassword_Repository Passwords { get; }
        public IBook_Repository Books { get; }
        public IGenreOfBook_Repository GenresOfBooks { get; }
        public ITypeOfBook_Repository TypesOfBooks { get; }
        public IBookWithGenre_Repository BooksWithGenre { get; }
        public IUserBook_Repository UserBook { get; }

        readonly IDbTransaction _transaction;


        public UnitOfWork(
            IUser_Repository users,
            IPassword_Repository passwords,
            IBook_Repository books,
            IGenreOfBook_Repository genresOfBooks,
            ITypeOfBook_Repository typesOfBooks,
            IDbTransaction transaction,
            IBookWithGenre_Repository booksWithGenre,
            IUserBook_Repository userBook_Repository)
        {
            Users = users;
            Passwords = passwords;
            Books = books;
            GenresOfBooks = genresOfBooks;
            TypesOfBooks = typesOfBooks;
            BooksWithGenre = booksWithGenre;
            UserBook = userBook_Repository;
            _transaction = transaction;
        }


        public void Dispose()
        {
            // Закриття SQL під'єднання і видалення об'єктів
            _transaction.Connection?.Close();
            _transaction.Connection?.Dispose();
            _transaction.Dispose();
        }
        public void Save()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
