namespace Proiect_Loredana.Models
{
    public class GameCategory
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public Game Game { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
