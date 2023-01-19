using System.ComponentModel.DataAnnotations;

namespace Proiect_Loredana.Models
{
    public class Acquisition
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? GameID { get; set; }
        public Game? Game { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }
    }
}
