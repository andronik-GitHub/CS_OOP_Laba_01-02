namespace NLayerApp.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUser_Repository Users { get; }
        IPassword_Repository Passwords { get; }
        IBook_Repository Books { get; }
        IGenreOfBook_Repository GenresOfBooks { get; }
        ITypeOfBook_Repository TypesOfBooks { get; }
        IBookWithGenre_Repository BooksWithGenre { get; }
        IUserBook_Repository UserBook { get; }

        void Save();
    }
}
