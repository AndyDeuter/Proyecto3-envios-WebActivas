using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcia1.Migrations
{
    /// <inheritdoc />
    public partial class InicialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinatarios",
                columns: table => new
                {
                    DestinatariosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinatarios", x => x.DestinatariosId);
                });

            migrationBuilder.CreateTable(
                name: "EstadosEnvio",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosEnvio", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "RolUsuario",
                columns: table => new
                {
                    RolUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuario", x => x.RolUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    RolUsuarioId = table.Column<int>(type: "int", nullable: false),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Detalles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auditorias_RolUsuario_RolUsuarioId",
                        column: x => x.RolUsuarioId,
                        principalTable: "RolUsuario",
                        principalColumn: "RolUsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RolUsuarioId = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_RolUsuario_RolUsuarioId",
                        column: x => x.RolUsuarioId,
                        principalTable: "RolUsuario",
                        principalColumn: "RolUsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Envio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    DestinatariosId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    RolUsuarioId = table.Column<int>(type: "int", nullable: false),
                    PaquetesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Envio_Destinatarios_DestinatariosId",
                        column: x => x.DestinatariosId,
                        principalTable: "Destinatarios",
                        principalColumn: "DestinatariosId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Envio_EstadosEnvio_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadosEnvio",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Envio_RolUsuario_RolUsuarioId",
                        column: x => x.RolUsuarioId,
                        principalTable: "RolUsuario",
                        principalColumn: "RolUsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Envio_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    PaquetesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnvioId = table.Column<int>(type: "int", nullable: false),
                    peso = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.PaquetesId);
                    table.ForeignKey(
                        name: "FK_Paquetes_Envio_EnvioId",
                        column: x => x.EnvioId,
                        principalTable: "Envio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_RolUsuarioId",
                table: "Auditorias",
                column: "RolUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_DestinatariosId",
                table: "Envio",
                column: "DestinatariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_EstadoId",
                table: "Envio",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_PaquetesId",
                table: "Envio",
                column: "PaquetesId");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_RolUsuarioId",
                table: "Envio",
                column: "RolUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_UsuarioId",
                table: "Envio",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_EnvioId",
                table: "Paquetes",
                column: "EnvioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolUsuarioId",
                table: "Usuario",
                column: "RolUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Paquetes_PaquetesId",
                table: "Envio",
                column: "PaquetesId",
                principalTable: "Paquetes",
                principalColumn: "PaquetesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envio_RolUsuario_RolUsuarioId",
                table: "Envio");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_RolUsuario_RolUsuarioId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Destinatarios_DestinatariosId",
                table: "Envio");

            migrationBuilder.DropForeignKey(
                name: "FK_Envio_EstadosEnvio_EstadoId",
                table: "Envio");

            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Paquetes_PaquetesId",
                table: "Envio");

            migrationBuilder.DropTable(
                name: "Auditorias");

            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.DropTable(
                name: "Destinatarios");

            migrationBuilder.DropTable(
                name: "EstadosEnvio");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "Envio");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
