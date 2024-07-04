using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStoreIdentity.Data.Migrations
{
    /// <inheritdoc />
    public partial class i1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Konfiguracija");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Konfiguracija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPUId = table.Column<int>(type: "int", nullable: false),
                    DiskId = table.Column<int>(type: "int", nullable: false),
                    GPUId = table.Column<int>(type: "int", nullable: false),
                    KukjisteId = table.Column<int>(type: "int", nullable: false),
                    KulerId = table.Column<int>(type: "int", nullable: false),
                    MBId = table.Column<int>(type: "int", nullable: false),
                    NapojuvanjeId = table.Column<int>(type: "int", nullable: false),
                    RAMId = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSUId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konfiguracija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_Disk_DiskId",
                        column: x => x.DiskId,
                        principalTable: "Disk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_GrafickaKarta_GPUId",
                        column: x => x.GPUId,
                        principalTable: "GrafickaKarta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_Kukjiste_KukjisteId",
                        column: x => x.KukjisteId,
                        principalTable: "Kukjiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_Kuler_KulerId",
                        column: x => x.KulerId,
                        principalTable: "Kuler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_MaticnaPloca_MBId",
                        column: x => x.MBId,
                        principalTable: "MaticnaPloca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_Napojuvanje_NapojuvanjeId",
                        column: x => x.NapojuvanjeId,
                        principalTable: "Napojuvanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_Procesor_CPUId",
                        column: x => x.CPUId,
                        principalTable: "Procesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_RAM_RAMId",
                        column: x => x.RAMId,
                        principalTable: "RAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_CPUId",
                table: "Konfiguracija",
                column: "CPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_DiskId",
                table: "Konfiguracija",
                column: "DiskId");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_GPUId",
                table: "Konfiguracija",
                column: "GPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_KukjisteId",
                table: "Konfiguracija",
                column: "KukjisteId");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_KulerId",
                table: "Konfiguracija",
                column: "KulerId");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_MBId",
                table: "Konfiguracija",
                column: "MBId");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_NapojuvanjeId",
                table: "Konfiguracija",
                column: "NapojuvanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_RAMId",
                table: "Konfiguracija",
                column: "RAMId");
        }
    }
}
