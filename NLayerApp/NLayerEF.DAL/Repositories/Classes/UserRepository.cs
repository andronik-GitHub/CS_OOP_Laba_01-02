using NLayerEF.DAL.Data;
using NLayerEF.DAL.Entities;
using NLayerEF.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerEF.DAL.Repositories.Classes
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyContext myContext)
            : base(myContext)
        {

        }

        public override Task<User> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
