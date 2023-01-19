using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Loredana.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        
        public ICollection<Game>? Games { get; set; }
    }
}
