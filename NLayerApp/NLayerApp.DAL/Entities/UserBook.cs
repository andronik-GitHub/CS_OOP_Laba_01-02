using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    public class UserBook
    {
        public int FirstId { get; set; } // UserId
        public int LastId { get; set; } // BookId

        public bool Reading { get; set; }
        public bool InThePlans { get; set; }
        public bool Abandoned { get; set; }
        public bool BeenRead { get; set; }
        public bool TheMostFavorite { get; set; }
    }
}
