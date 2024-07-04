using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PCStoreIdentity.Models
{
    public class Konfiguracija
    {
        public int Id { get; set; }
        
        public string KorisnikId { get; set; }
        public IdentityUser Korisnik { get; set; }
        public int CPUId { get; set; }
        public Procesor CPU { get; set; }
        public int MBId { get; set; }
        public MaticnaPloca MB { get; set; }
        public int RAMId { get; set; }
        public RAM Memorija {  get; set; }
        
        public int GPUId { get; set; }
        
        public GrafickaKarta GPU { get; set; }

        public int DiskId { get; set; }

        public Disk SSD { get; set; }
        public int KukjisteId { get; set; }
        public Kukjiste Case { get; set; }

        public int PSUId { get; set; }

        public Napojuvanje PSU { get; set; }

        public int KulerId { get; set; }

       public Kuler Cooler { get; set; }
    }
}
