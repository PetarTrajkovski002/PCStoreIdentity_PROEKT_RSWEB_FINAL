using System.ComponentModel.DataAnnotations;

namespace PCStoreIdentity.Models
{
    public class MaticnaPloca
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Proizvoditel { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Model { get; set; }

        public string TipMemorija { get; set; }

        public string MaxRAMSpeed { get; set; }

        public string CPUSocket { get; set; }

        public string SlikaUrl {  get; set; }

        public string DetailsUrl { get; set; }
        public int Cena { get; set; }

    }
}
