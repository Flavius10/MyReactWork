using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Rezultate
    {
        [Key]
        
        public int ConcurentId { get; set; }

        [Required]

        public string ConcurentName { get; set; } = null!;

        public int Punctaj {  get; set; }

    }
}
