namespace Proiect_Loredana.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<GameCategory>? GameCategories { get; set; }
    }
}
