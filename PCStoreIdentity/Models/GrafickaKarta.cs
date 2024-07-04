using System.ComponentModel.DataAnnotations;

namespace PCStoreIdentity.Models
{
    public class GrafickaKarta
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Proizvoditel { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Model { get; set; }

        public string TipMemorija {  get; set; }

        public string VRAM { get; set; }

        public string CoreClock { get; set; }

        public string MemoryClock { get; set; }

        public int Power { get; set; }

        public string SlikaUrl { get; set; }

        public string DetailsUrl {  get; set; }

        public int Cena {  get; set; }







        


    }
}
