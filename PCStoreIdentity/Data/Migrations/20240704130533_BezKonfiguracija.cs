using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStoreIdentity.Data.Migrations
{
    /// <inheritdoc />
    public partial class BezKonfiguracija : Migration
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
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPUid = table.Column<int>(type: "int", nullable: false),
                    Diskid = table.Column<int>(type: "int", nullable: false),
                    GPUid = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Kukjisteid = table.Column<int>(type: "int", nullable: false),
                    Kulerid = table.Column<int>(type: "int", nullable: false),
                    MBid = table.Column<int>(type: "int", nullable: false),
                    PSUid = table.Column<int>(type: "int", nullable: false),
                    RAMid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konfiguracija", x => x.id);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_Disk_Diskid",
                        column: x => x.Diskid,
                        principalTable: "Disk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_GrafickaKarta_GPUid",
                        column: x => x.GPUid,
                        principalTable: "GrafickaKarta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_Kukjiste_Kukjisteid",
                        column: x => x.Kukjisteid,
                        principalTable: "Kukjiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_Kuler_Kulerid",
                        column: x => x.Kulerid,
                        principalTable: "Kuler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_MaticnaPloca_MBid",
                        column: x => x.MBid,
                        principalTable: "MaticnaPloca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_Napojuvanje_PSUid",
                        column: x => x.PSUid,
                        principalTable: "Napojuvanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_Procesor_CPUid",
                        column: x => x.CPUid,
                        principalTable: "Procesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Konfiguracija_RAM_RAMid",
                        column: x => x.RAMid,
                        principalTable: "RAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_CPUid",
                table: "Konfiguracija",
                column: "CPUid");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_Diskid",
                table: "Konfiguracija",
                column: "Diskid");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_GPUid",
                table: "Konfiguracija",
                column: "GPUid");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_KorisnikId",
                table: "Konfiguracija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_Kukjisteid",
                table: "Konfiguracija",
                column: "Kukjisteid");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_Kulerid",
                table: "Konfiguracija",
                column: "Kulerid");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_MBid",
                table: "Konfiguracija",
                column: "MBid");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_PSUid",
                table: "Konfiguracija",
                column: "PSUid");

            migrationBuilder.CreateIndex(
                name: "IX_Konfiguracija_RAMid",
                table: "Konfiguracija",
                column: "RAMid");
        }
    }
}
