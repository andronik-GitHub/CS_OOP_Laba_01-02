using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    public class Book : BaseEntity
    {
        public string BookTitle { get; set; } = "";
        public int TypeId { get; set; }
        public int YearOfRelease { get; set; }
        public string Author { get; set; } = "";
        public string AlternativeBookTitle { get; set; } = "";
        public string TitleStatus { get; set; } = "";
        public string TranslationStatus { get; set; } = "";
        public float Rating { get; set; }
    }
}
