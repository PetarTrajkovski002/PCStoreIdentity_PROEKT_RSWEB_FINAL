using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCStoreIdentity.Models;

namespace PCStoreIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PCStoreIdentity.Models.Procesor> Procesor { get; set; } = default!;
        public DbSet<PCStoreIdentity.Models.RAM> RAM { get; set; } = default!;
        public DbSet<PCStoreIdentity.Models.Napojuvanje> Napojuvanje { get; set; } = default!;
        public DbSet<PCStoreIdentity.Models.MaticnaPloca> MaticnaPloca { get; set; } = default!;
        public DbSet<PCStoreIdentity.Models.Kuler> Kuler { get; set; } = default!;
        public DbSet<PCStoreIdentity.Models.Kukjiste> Kukjiste { get; set; } = default!;
        public DbSet<PCStoreIdentity.Models.GrafickaKarta> GrafickaKarta { get; set; } = default!;
        public DbSet<PCStoreIdentity.Models.Disk> Disk { get; set; } = default!;

        public DbSet<PCStoreIdentity.Models.MaticnaRAM> MaticnaRAM { get; set; } = default!;

        public DbSet<PCStoreIdentity.Models.MaticnaProcesor> MaticnaProcesor { get; set; } = default!;
        public DbSet<PCStoreIdentity.Models.Konfiguracija> Konfiguracija { get; set; } = default!;
       
        
        
       

       

       
    }
}
