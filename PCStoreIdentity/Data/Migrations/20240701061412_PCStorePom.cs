using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStoreIdentity.Data.Migrations
{
    /// <inheritdoc />
    public partial class PCStorePom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaticnaProcesor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcesorId = table.Column<int>(type: "int", nullable: false),
                    MaticnaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaticnaProcesor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaticnaRam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaticnaId = table.Column<int>(type: "int", nullable: false),
                    RAMId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaticnaRam", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaticnaProcesor");

            migrationBuilder.DropTable(
                name: "MaticnaRam");
        }
    }
}
