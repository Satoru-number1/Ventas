using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroServicioVentas.Migrations
{
    /// <inheritdoc />
    public partial class part5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDireccion",
                table: "Visita",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Visita_IdDireccion",
                table: "Visita",
                column: "IdDireccion");

            migrationBuilder.AddForeignKey(
                name: "FK_Visita_Direccion_IdDireccion",
                table: "Visita",
                column: "IdDireccion",
                principalTable: "Direccion",
                principalColumn: "IdDireccion",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visita_Direccion_IdDireccion",
                table: "Visita");

            migrationBuilder.DropIndex(
                name: "IX_Visita_IdDireccion",
                table: "Visita");

            migrationBuilder.DropColumn(
                name: "IdDireccion",
                table: "Visita");
        }
    }
}
