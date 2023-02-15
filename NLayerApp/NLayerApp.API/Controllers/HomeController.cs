using Microsoft.AspNetCore.Mvc;
using NLayerApp.DAL.Repositories.Classes;
using NLayerApp.DAL.Repositories.Interfaces;
using System.Data.SqlClient;

namespace NLayerApp.API.Controllers
{
    public class GetUsersController : Controller
    {
        [Route("/Users/GetAll")]
        public async Task<IEnumerable<DAL.Entities.User>> Index()
        {
            var con = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Collection_Books;Trusted_Connection=True;");
            con.Open();
            var tran = con.BeginTransaction();
            IUser_Repository uRep = new User_Repository(con, tran);

            return await uRep.GetAllAsync();
        }
    }
}
