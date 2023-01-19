namespace Proiect_Loredana.Models
{
    public class GameData
    {
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<GameCategory> GameCategories { get; set; }
    }
}
