using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStoreIdentity.Data.Migrations
{
    /// <inheritdoc />
    public partial class konf : Migration
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
                    KorisnikId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Kukjisteid = table.Column<int>(type: "int", nullable: false),
                    Kulerid = table.Column<int>(type: "int", nullable: false),
                    MBid = table.Column<int>(type: "int", nullable: false),
                    PSUid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konfiguracija", x => x.id);
                });
        }
    }
}
