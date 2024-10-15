using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP02.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillOfLadings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    Consignee = table.Column<string>(type: "TEXT", nullable: false),
                    Navio = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOfLadings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Tamanho = table.Column<int>(type: "INTEGER", nullable: false),
                    BillId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Containers_BillOfLadings_BillId",
                        column: x => x.BillId,
                        principalTable: "BillOfLadings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Containers_BillId",
                table: "Containers",
                column: "BillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "BillOfLadings");
        }
    }
}
