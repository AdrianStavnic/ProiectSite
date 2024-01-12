using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Pipelines;

namespace ProiectSite.Models
{
    public class Vacation
    {
        public int Id { get; set; }
        [Display(Name = "Oras")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
    }
}
