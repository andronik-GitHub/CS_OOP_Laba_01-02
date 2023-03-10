using NLayerEF.DAL.Data;
using NLayerEF.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerEF.DAL.Repositories.Classes
{
    public class UnitOfWorkEF : IUnitOfWorkEF
    {

        protected readonly MyContext databaseContext;

        public IUserRepository userRep { get; }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public UnitOfWorkEF(
            MyContext databaseContext,
            IUserRepository userRep)
        {
            this.databaseContext = databaseContext;
            this.userRep = userRep;
        }
    }
}
