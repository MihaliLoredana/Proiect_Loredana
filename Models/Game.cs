using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Proiect_Loredana.Models
{
    public class Game
    {
        public int ID { get; set; }
        [Display(Name = "Game Title")]

        [Required(ErrorMessage = "Title is rquired!")]
        [StringLength(150, MinimumLength =3)]
        public string Title { get; set; }
        
        public int? AuthorID { get; set; }
        [Display(Name = "Company")]
        public Author? Author { get; set; } 

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Publishing Date")]
        public DateTime PublishingDate { get; set; }
        public string Description { get; set; }
        [Display(Name = "Game Categories")]
        public ICollection<GameCategory>? GameCategories { get; set; }
    }
}
