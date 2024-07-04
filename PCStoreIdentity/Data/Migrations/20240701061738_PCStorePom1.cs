using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStoreIdentity.Data.Migrations
{
    /// <inheritdoc />
    public partial class PCStorePom1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MaticnaRam",
                table: "MaticnaRam");

            migrationBuilder.RenameTable(
                name: "MaticnaRam",
                newName: "MaticnaRAM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaticnaRAM",
                table: "MaticnaRAM",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MaticnaRAM",
                table: "MaticnaRAM");

            migrationBuilder.RenameTable(
                name: "MaticnaRAM",
                newName: "MaticnaRam");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaticnaRam",
                table: "MaticnaRam",
                column: "Id");
        }
    }
}
