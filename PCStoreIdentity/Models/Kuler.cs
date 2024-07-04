using System.ComponentModel.DataAnnotations;

namespace PCStoreIdentity.Models
{
    public class Kuler
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =3)]
        public string Model { get; set; }
        public int TDP { get; set; }

        public string DetailsUrl { get; set; }

        public string SlikaUrl { get; set; }
        public int Cena { get; set; }



    }
}
