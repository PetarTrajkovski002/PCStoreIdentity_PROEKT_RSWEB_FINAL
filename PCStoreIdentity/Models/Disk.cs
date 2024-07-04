using System.ComponentModel.DataAnnotations;

namespace PCStoreIdentity.Models
{
    public class Disk
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Model { get; set; }
        public int Kapacitet { get; set; }

        public string Tip { get; set; }

        public string SlikaUrl { get; set; }

        public string DetailsUrl {  get; set; }

        public int Cena { get; set; }

    }
}
