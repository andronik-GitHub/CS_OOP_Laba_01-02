using System.Data.SqlClient;

namespace NLayerApp.DAL.App_Setting.DB_Tables.Interfaces
{
    public interface ICreateInsertDrop
    {
        Task Create(SqlConnection connection);
        Task Insert(SqlConnection connection);
        Task Drop(SqlConnection connection);
    }
}
