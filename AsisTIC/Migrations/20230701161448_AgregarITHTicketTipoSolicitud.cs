using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsisTIC.Migrations
{
    /// <inheritdoc />
    public partial class AgregarITHTicketTipoSolicitud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ITHtipoSolicitud",
                columns: table => new
                {
                    idsolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    solicitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITHtipoSolicitud", x => x.idsolicitud);
                });

            migrationBuilder.CreateTable(
                name: "ITHticket",
                columns: table => new
                {
                    IdTicket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false),
                    ITHTipoSolicitudidsolicitud = table.Column<int>(type: "int", nullable: false),
                    Solicitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    UsrSolicita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adjunto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITHticket", x => x.IdTicket);
                    table.ForeignKey(
                        name: "FK_ITHticket_ITHtipoSolicitud_ITHTipoSolicitudidsolicitud",
                        column: x => x.ITHTipoSolicitudidsolicitud,
                        principalTable: "ITHtipoSolicitud",
                        principalColumn: "idsolicitud",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITHticket_ITHTipoSolicitudidsolicitud",
                table: "ITHticket",
                column: "ITHTipoSolicitudidsolicitud");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITHticket");

            migrationBuilder.DropTable(
                name: "ITHtipoSolicitud");
        }
    }
}
