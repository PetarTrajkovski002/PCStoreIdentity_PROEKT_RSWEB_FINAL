using System.ComponentModel.DataAnnotations;

namespace PCStoreIdentity.Models
{
    public class Kukjiste
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =3)]
        public string Model { get; set; }

        public string FormFactor { get; set; }

        public string SlikaUrl { get; set; }

        public string DetailsUrl { get; set; }

        public int Cena {  get; set; }

    }
}
