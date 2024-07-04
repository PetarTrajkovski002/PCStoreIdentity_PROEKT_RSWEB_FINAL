using System.ComponentModel.DataAnnotations;

namespace PCStoreIdentity.Models
{
    public class Napojuvanje
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =3)]
        public string Model { get; set; }

        public int Power { get; set; }

        public string? Rating { get; set; }

        public string SlikaUrl { get; set; }

        public string DetailsUrl {  get; set; }

        public int Cena {  get; set; }

    }
}
