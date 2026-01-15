using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAccountant.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    IssuerTaxId = table.Column<string>(type: "TEXT", nullable: false),
                    ReceiverTaxId = table.Column<string>(type: "TEXT", nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    Pit = table.Column<float>(type: "REAL", nullable: true),
                    Vat = table.Column<float>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => new { x.IssuerTaxId, x.ReceiverTaxId, x.Number });
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
