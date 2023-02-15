using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    public class User : BaseEntity
    {
        public string NikName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string AboutMyself { get; set; } = string.Empty;
        public string RegistrationDate { get; set; } = string.Empty;
    }
}
