using System.ComponentModel.DataAnnotations;

namespace PCStoreIdentity.Models
{
    public class Procesor
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Proizvoditel { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Model {  get; set; }

        public string Generation { get; set; }

        public int Cores { get; set; }

        public int Threads { get; set; }

        public float Speed { get; set; }

        public int Power { get; set; }
        
        public string DetailsUrl { get; set; }

        public string SlikaUrl { get; set; }
        public int Cena {  get; set; }


      



    }
}
