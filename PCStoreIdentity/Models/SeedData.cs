using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using PCStoreIdentity.Data;
using PCStoreIdentity.Models;

namespace PCStoreIdentity.Models
{
    public class SeedData
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            IdentityResult roleResult;
            //Add Admin Role
            string [] ulogi = { "Admin", "User" };
            foreach (string u in ulogi) 
            {
                var roleCheck = await RoleManager.RoleExistsAsync(u);
                if (!roleCheck) { roleResult = await RoleManager.CreateAsync(new IdentityRole(u)); }
            }
            
            IdentityUser user = await UserManager.FindByEmailAsync("admin@pcstore.com");
            if (user == null)
            {
                var User = new IdentityUser();
                User.Email = "admin@pcstore.com";
                User.UserName = "admin@pcstore.com";
                string userPWD = "Admin123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "User"); }
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(

                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                CreateUserRoles(serviceProvider).Wait();
                if (context.RAM.Any() || context.Procesor.Any() || context.MaticnaPloca.Any() || context.GrafickaKarta.Any() || context.Disk.Any() || context.Kukjiste.Any() || context.Napojuvanje.Any() || context.Kuler.Any())
                {
                    return;
                }

                context.Procesor.AddRange(


                    new Procesor { Proizvoditel = "Intel", Model = "i3-10100", Cores = 4, Threads = 8, Speed = 4, Generation = "Comet Lake", Power = 65, SlikaUrl = "./wwwroot/sliki/procesori/i310100box_1.jpg", DetailsUrl = "https://www.intel.com/content/www/us/en/products/sku/199283/intel-core-i310100-processor-6m-cache-up-to-4-30-ghz/specifications.html", Cena = 6380 },
                    new Procesor { Proizvoditel = "Intel", Model = "i5-10400", Cores = 6, Threads = 12, Speed = 3, Generation = "Comet Lake", Power = 65, SlikaUrl = "./wwwroot/sliki/procesori/i510400box_1.jpg", DetailsUrl = "https://www.intel.com/content/www/us/en/products/sku/199271/intel-core-i510400-processor-12m-cache-up-to-4-30-ghz/specifications.html", Cena = 7890 },
                    new Procesor { Proizvoditel = "Intel", Model = "i7-10700", Cores = 8, Threads = 16, Speed = 3, Generation = "Comet Lake", Power = 65, SlikaUrl = "./wwwroot/sliki/procesori/i710700box_1.jpg", DetailsUrl = "https://www.intel.com/content/www/us/en/products/sku/199316/intel-core-i710700-processor-16m-cache-up-to-4-80-ghz/specifications.html", Cena = 14280 },


                    new Procesor { Proizvoditel = "Intel", Model = "i3-14100", Cores = 4, Threads = 8, Speed = 3, Generation = "Raptor Lake", Power = 60, SlikaUrl = "./wwwroot/sliki/procesori/i314100box.jpg", DetailsUrl = "https://www.intel.com/content/www/us/en/products/sku/236774/intel-core-i3-processor-14100-12m-cache-up-to-4-70-ghz/specifications.html", Cena = 10500 },
                    new Procesor { Proizvoditel = "Intel", Model = "i5-14600K", Cores = 14, Threads = 20, Speed = 2, Generation = "Raptor Lake", Power = 125, SlikaUrl = "./wwwroot/sliki/procesori/i514600kbox.jpg", DetailsUrl = "https://www.intel.com/content/www/us/en/products/sku/236799/intel-core-i5-processor-14600k-24m-cache-up-to-5-30-ghz/specifications.html", Cena = 19500 },
                    new Procesor { Proizvoditel = "Intel", Model = "i7-14700K", Cores = 20, Threads = 28, Speed = 3, Generation = "Raptor Lake", Power = 125, SlikaUrl = "./wwwroot/sliki/procesori/i714700kbox.jpg", DetailsUrl = "https://www.intel.com/content/www/us/en/products/sku/236781/intel-core-i7-processor-14700-33m-cache-up-to-5-40-ghz/specifications.html", Cena = 28490 },
                    new Procesor { Proizvoditel = "Intel", Model = "i9-14900K", Cores = 24, Threads = 32, Speed = 4, Generation = "Raptor Lake", Power = 125, SlikaUrl = "./wwwroot/sliki/procesori/i914900kbox.jpg", DetailsUrl = "https://www.intel.com/content/www/us/en/products/sku/236773/intel-core-i9-processor-14900k-36m-cache-up-to-6-00-ghz/specifications.html", Cena = 39480 },


                    new Procesor { Proizvoditel = "AMD", Model = "Ryzen 5 7600", Cores = 6, Threads = 12, Speed = 4, Generation = "Zen 4", Power = 65, SlikaUrl = "./wwwroot/sliki/procesori/100100001015box.jpg", DetailsUrl = "https://www.amd.com/en/products/processors/desktops/ryzen/7000-series/amd-ryzen-5-7600.html", Cena = 12980 },
                    new Procesor { Proizvoditel = "AMD", Model = "Ryzen 7 7700X", Cores = 8, Threads = 16, Speed = 5, Generation = "Zen 4", Power = 105, SlikaUrl = "./wwwroot/sliki/procesori/100100000591wof.jpg", DetailsUrl = "https://www.amd.com/en/products/processors/desktops/ryzen/7000-series/amd-ryzen-7-7700x.html", Cena=21480 },
                    new Procesor { Proizvoditel = "AMD", Model = "Ryzen 7 7900X", Cores = 12, Threads = 24, Speed = 5, Generation = "Zen 4", Power = 105, SlikaUrl = "./wwwroot/sliki/procesori/100100000589wof.jpg", DetailsUrl = "https://www.amd.com/en/products/processors/desktops/ryzen/7000-series/amd-ryzen-9-7900x.html", Cena = 24780 }


                    );

                context.SaveChanges();

                context.MaticnaPloca.AddRange(

                    new MaticnaPloca { Proizvoditel="Gigabyte",Model = "H410M-H-V2 ", CPUSocket ="LGA 1200", MaxRAMSpeed="2933 MHz", TipMemorija="DDR4", SlikaUrl= "./wwwroot/sliki/maticni_ploci/gah410mhv2_1.jpg", DetailsUrl= "https://www.gigabyte.com/Motherboard/H410M-H-V2-rev-10#kf", Cena= 3780},
                    new MaticnaPloca { Proizvoditel="MSI", Model= "H510M PRO-E",CPUSocket="LGA 1200", MaxRAMSpeed="3200 MHz", TipMemorija="DDR4", SlikaUrl="./wwwroot/sliki/maticni_ploci/h510mproe.jpg", DetailsUrl= "https://www.msi.com/Motherboard/H510M-PRO-E", Cena=4280 },
                    new MaticnaPloca { Proizvoditel = "MSI", Model = "B560M PRO-E", CPUSocket = "LGA 1200", MaxRAMSpeed = "4800 MHz", TipMemorija = "DDR4", SlikaUrl = "./wwwroot/sliki/maticni_ploci/prob56ome.jpg", DetailsUrl = "https://www.msi.com/Motherboard/B560M-PRO-E",Cena =5280 },
                    new MaticnaPloca { Proizvoditel= "Gigabyte", Model="H610M SVH V2", CPUSocket="LGA 1700", MaxRAMSpeed="5600 MHz", TipMemorija="DDR5", SlikaUrl= "./wwwroot/sliki/maticni_ploci/gah610ms2hv2ddr5.jpg", DetailsUrl= "https://www.gigabyte.com/Motherboard/H610M-S2H-rev-10#kf", Cena=5280 },
                    new MaticnaPloca { Proizvoditel = "Gigabyte", Model = "B760M DS3H", CPUSocket="LGA 1700", MaxRAMSpeed="7600 MHz", TipMemorija="DDR5", SlikaUrl="./wwwroot/sliki/maticni_ploci/gab760mds3hddr5.jpg", DetailsUrl= "https://www.gigabyte.com/Motherboard/B760M-DS3H-rev-10", Cena=8280 },
                    new MaticnaPloca { Proizvoditel="MSI", Model="PRO B650M-B", CPUSocket="AM5", MaxRAMSpeed="6800 MHz", TipMemorija="DDR5", SlikaUrl= "./wwwroot/sliki/maticni_ploci/prob650mb.jpg", DetailsUrl= "https://www.msi.com/Motherboard/PRO-B650M-B",Cena=6780},
                    new MaticnaPloca { Proizvoditel = "MSI", Model = "B650M D3SH", CPUSocket = "AM5", MaxRAMSpeed = "6400 MHz", TipMemorija = "DDR5", SlikaUrl = "./wwwroot/sliki/maticni_ploci/gab650d3sh.jpg", DetailsUrl = "https://www.gigabyte.com/Motherboard/B650M-DS3H-rev-10-11-12#kf", Cena = 11180 }
                    );

                
                context.SaveChanges();

                context.RAM.AddRange(

                    new RAM { Proizvoditel="Kingston", Model="FURY", Kapacitet="8GB", Tip="DDR4", Speed="3200 MHz", SlikaUrl= "./wwwroot/sliki/RAM/ram8gbddr4.jpg", DetailsUrl= "https://www.kingston.com/dataSheets/KF432C16BB_8.pdf", Cena=1280 },

                    new RAM { Proizvoditel = "Kingston", Model = "FURY", Kapacitet = "16GB", Tip = "DDR4", Speed = "3200 MHz", SlikaUrl = "./wwwroot/sliki/RAM/ram8gbddr4.jpg", DetailsUrl= "https://www.kingston.com/datasheets/KF432C16BB1_16.pdf", Cena=2390 },

                    new RAM { Proizvoditel="Kingston", Model= "FURY", Kapacitet="16GB", Tip="DDR5", Speed="5600 MHz", SlikaUrl="./wwwroot/sliki/RAM/dual8gb.jpg", DetailsUrl= "https://www.kingston.com/datasheets/KF556C40BB-16.pdf", Cena=4450 }


                    );
                context.SaveChanges();

                context.GrafickaKarta.AddRange(

                    new GrafickaKarta { Proizvoditel="Gigabyte", Model="NVIDIA GEFORCE RTX 3060", CoreClock="1792 MHz", MemoryClock="15000 MHz", TipMemorija="GDDR6X", Power=120, VRAM="12GB", SlikaUrl="./wwwroot/sliki/gfx/rtx3060.jpg", DetailsUrl= "https://www.gigabyte.com/Graphics-Card/GV-N3060WF2OC-12GD-rev-20#kf", Cena=19280 },
                    new GrafickaKarta { Proizvoditel = "MSI", Model = "NVIDIA GEFORCE RTX 4070", CoreClock = "2520 MHz", MemoryClock = "18000 Mhz", TipMemorija = "GDDR6X", Power = 200, VRAM = "12GB", SlikaUrl= "./wwwroot/sliki/gfx/rtx4070ventus2xoc.jpg", DetailsUrl= "https://www.msi.com/Graphics-Card/GeForce-RTX-4070-VENTUS-2X-12G-OC/Overview",Cena= 38480 },
                    new GrafickaKarta { Proizvoditel="Sapphire", Model= "AMD RADEON RX 7800 XT", CoreClock="2430 MHz", MemoryClock="10000 MHz", TipMemorija="GDDR6", VRAM="16GB", Power=266, SlikaUrl= "./wwwroot/sliki/gfx/7800xt.jpg", DetailsUrl= "https://www.sapphiretech.com/en/consumer/pulse-radeon-rx-7800-xt-16g-gddr6", Cena=35980 }

                    );
                context.SaveChanges();

                context.Napojuvanje.AddRange(

                    new Napojuvanje { Model="DEEPCOOL PK650D", Power=650, Rating="80Plus Bronze", SlikaUrl="./wwwroot/sliki/psu/deepcool650w.jpg", DetailsUrl= "https://www.deepcool.com/products/PowerSupplyUnits/powersupplyunits/PK650D-80-PLUS-Bronze-Power-Supply/2022/15619.shtml", Cena=4080 },
                    new Napojuvanje { Model= "MSI MSI MAG A650BN", Power = 650, Rating = "80Plus Bronze", SlikaUrl="./wwwroot/sliki/psu/msimag650.jpg", DetailsUrl= "https://www.msi.com/Power-Supply/MAG-A650BN/Overview", Cena=4680 },
                    new Napojuvanje { Model= "DEEPCOOL DQ850-M-V2L", Power=850, Rating="80Plus Bronze", SlikaUrl="./wwwroot/sliki/psu/850wgold.jpg", DetailsUrl= "https://us.deepcool.com/products/PowerSupplyUnits/powersupplyunits/2021/8727.shtml",Cena=8880 }



                    );
                context.SaveChanges();
                context.Kukjiste.AddRange(
                    
                    new Kukjiste {  Model= "Genesis Irid 503 V2", FormFactor="ATX", SlikaUrl="./wwwroot/sliki/cases/kukjiste1.jpg", DetailsUrl= "https://genesis-zone.com/product/irid-503-argb?ir=1", Cena=4480 }

                    );
                context.SaveChanges();
                context.Disk.AddRange(
                    
                    new Disk {  Model="Kingston A400", Kapacitet=240, Tip="SATA", SlikaUrl="./wwwroot/sliki/diskovi/kingston_a400.jpg", DetailsUrl = "https://www.kingston.com/en/ssd/a400-solid-state-drive", Cena=1590 },
                    new Disk {  Model="Samsung 870 EVO", Kapacitet=256, Tip="SATA", SlikaUrl="./wwwroot/sliki/diskovi/ssd-870-evo.jpg", DetailsUrl= "https://www.samsung.com/uk/memory-storage/sata-ssd/870-evo-250gb-sata-3-2-5-ssd-mz-77e250b-eu/", Cena=2380 },
                    new Disk { Model= "Kingson Renegade Fury 500GB", Kapacitet=500, Tip="M.2", SlikaUrl="./wwwroot/sliki/diskovi/renegade.jpg", DetailsUrl= "https://www.kingston.com/en/ssd/gaming/kingston-fury-renegade-nvme-m2-ssd", Cena= 4480},
                    new Disk { Model="Samsung 980 PRO", Kapacitet=1024, Tip="M.2", SlikaUrl="./wwwroot/sliki/diskovi/980pro.jpg", DetailsUrl= "https://www.samsung.com/sg/memory-storage/nvme-ssd/980-pro-pcle-4-0-nvme-m-2-ssd-1tb-mz-v8p1t0bw/", Cena=6180 }

                    );
                context.SaveChanges();
                context.Kuler.AddRange(
                    
                     new Kuler {  Model="DEEPCOOL AG620", TDP=260, Cena=3380, SlikaUrl="./wwwroot/sliki/kuler/ag620.jpg", DetailsUrl= "https://www.deepcool.com/products/Cooling/cpuaircoolers/GAMMAXX-AG620-Dual-Tower-CPU-Cooler/2022/15900.shtml" }

                    );

                context.SaveChanges();

                context.MaticnaProcesor.AddRange(
                    
                    new MaticnaProcesor { ProcesorId=1, MaticnaId=1},
                    new MaticnaProcesor { ProcesorId = 1, MaticnaId = 2 },
                    new MaticnaProcesor { ProcesorId = 1, MaticnaId = 3 },
                    new MaticnaProcesor { ProcesorId = 2, MaticnaId = 1 },
                    new MaticnaProcesor { ProcesorId = 2, MaticnaId = 2 },
                    new MaticnaProcesor { ProcesorId = 2, MaticnaId = 3 },
                    new MaticnaProcesor { ProcesorId = 3, MaticnaId = 1 },
                    new MaticnaProcesor { ProcesorId = 3, MaticnaId = 2 },
                    new MaticnaProcesor { ProcesorId = 3, MaticnaId = 3 },

                    new MaticnaProcesor { ProcesorId = 4, MaticnaId = 4 },
                    new MaticnaProcesor { ProcesorId = 4, MaticnaId = 5 },
                    new MaticnaProcesor { ProcesorId = 5, MaticnaId = 4 },
                    new MaticnaProcesor { ProcesorId = 5, MaticnaId = 5 },
                    new MaticnaProcesor { ProcesorId = 6, MaticnaId = 4 },
                    new MaticnaProcesor { ProcesorId = 6, MaticnaId = 5 },
                    new MaticnaProcesor { ProcesorId = 7, MaticnaId = 4 },
                    new MaticnaProcesor { ProcesorId = 7, MaticnaId = 5 },

                    new MaticnaProcesor { ProcesorId=8, MaticnaId=6},
                    new MaticnaProcesor { ProcesorId = 8, MaticnaId = 7 },
                    new MaticnaProcesor { ProcesorId = 9, MaticnaId = 6 },
                    new MaticnaProcesor { ProcesorId = 9, MaticnaId = 7 },
                    new MaticnaProcesor { ProcesorId = 9, MaticnaId = 6 },
                    new MaticnaProcesor { ProcesorId = 9, MaticnaId = 7 }
                    );
                context.SaveChanges();

                context.MaticnaRAM.AddRange(
                    
                    new MaticnaRAM { MaticnaId=1,RAMId=1},
                    new MaticnaRAM { MaticnaId = 1, RAMId = 2},
                    new MaticnaRAM { MaticnaId = 2, RAMId = 1 },
                    new MaticnaRAM { MaticnaId = 2, RAMId = 2 },
                    new MaticnaRAM { MaticnaId = 3, RAMId = 1 },
                    new MaticnaRAM { MaticnaId = 3, RAMId = 2 },
                    new MaticnaRAM { MaticnaId = 4, RAMId = 3 },
                    new MaticnaRAM { MaticnaId = 5, RAMId = 3 },
                    new MaticnaRAM { MaticnaId = 6, RAMId = 3 },
                    new MaticnaRAM { MaticnaId = 7, RAMId = 3 }

                    );
                context.SaveChanges();



            }
            
        }
    }
}
