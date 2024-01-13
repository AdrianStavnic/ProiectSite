using System.ComponentModel.DataAnnotations;

namespace ProiectSite.Models
{
    public class Reservation
    {
        public int ID { get; set; }

        [Display(Name = "Nume")]
        public string FirstName { get; set; }
        [Display(Name = "Prenume")]
        public string LastName { get; set; }

        [Display(Name = "Vacanta")]
        public int VacationId { get; set; }
        public Vacation Vacation { get; set; }
    }
}
