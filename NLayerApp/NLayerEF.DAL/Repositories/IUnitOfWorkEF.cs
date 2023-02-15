using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerEF.DAL.Repositories
{
    public interface IUnitOfWorkEF
    {
        IUserRepository userRep { get; }
        Task SaveChangesAsync();
    }
}
