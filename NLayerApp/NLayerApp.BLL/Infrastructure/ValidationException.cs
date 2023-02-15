using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.Infrastructure
{
    public class ValidationException : Exception
    {
        // Дозволяє зберегти назву властивості моделі, яка некоректна і не проходить валідацію
        public string Property { get; protected set; }
        public ValidationException (string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
