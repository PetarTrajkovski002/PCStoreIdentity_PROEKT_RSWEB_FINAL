using Microsoft.AspNetCore.Identity;
using PCStoreIdentity.Models;

namespace PCStoreIdentity.ViewModels
{
    public class VMKonfiguracija
    {
        

        public Konfiguracija konfiguracija { get; set; }
        public IdentityUser Korisnik { get; set; }
        public Procesor CPU { get; set; }
        public MaticnaPloca MB {  get; set; }
        public RAM RAM {  get; set; }

        public GrafickaKarta GPU { get; set; }

        public Disk Disk { get; set; }

        public Kukjiste Case{ get; set;}

        public Kuler Cooler { get; set; }

        public Napojuvanje PSU { get; set; }






    }
}
