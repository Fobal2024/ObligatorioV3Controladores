using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Obligatorio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responsables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeMaquina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeMaquina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoRutinas",
                columns: table => new
                {
                    IdTipoRutina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRutinas", x => x.IdTipoRutina);
                });

            migrationBuilder.CreateTable(
                name: "Local",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Local", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Local_Responsables_ResponsableId",
                        column: x => x.ResponsableId,
                        principalTable: "Responsables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rutinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalificacionPromedio = table.Column<int>(type: "int", nullable: false),
                    IdTipoRutina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rutinas_TipoRutinas_IdTipoRutina",
                        column: x => x.IdTipoRutina,
                        principalTable: "TipoRutinas",
                        principalColumn: "IdTipoRutina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maquina",
                columns: table => new
                {
                    IdMaquina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioCompra = table.Column<int>(type: "int", nullable: false),
                    VidaUtil = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    TipoDeMaquinaId = table.Column<int>(type: "int", nullable: false),
                    LocalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.IdMaquina);
                    table.ForeignKey(
                        name: "FK_Maquina_Local_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Local",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maquina_TipoDeMaquina_TipoDeMaquinaId",
                        column: x => x.TipoDeMaquinaId,
                        principalTable: "TipoDeMaquina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Socios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalId = table.Column<int>(type: "int", nullable: false),
                    IdTipoRutina = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Socios_Local_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Local",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ejercicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaquinaNecesariaIdMaquina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ejercicio_Maquina_MaquinaNecesariaIdMaquina",
                        column: x => x.MaquinaNecesariaIdMaquina,
                        principalTable: "Maquina",
                        principalColumn: "IdMaquina");
                });

            migrationBuilder.CreateTable(
                name: "SocioRutinas",
                columns: table => new
                {
                    IdSocio = table.Column<int>(type: "int", nullable: false),
                    IdRutina = table.Column<int>(type: "int", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocioRutinas", x => new { x.IdSocio, x.IdRutina });
                    table.ForeignKey(
                        name: "FK_SocioRutinas_Rutinas_IdRutina",
                        column: x => x.IdRutina,
                        principalTable: "Rutinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocioRutinas_Socios_IdSocio",
                        column: x => x.IdSocio,
                        principalTable: "Socios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EjercicioRutina",
                columns: table => new
                {
                    EjerciciosId = table.Column<int>(type: "int", nullable: false),
                    RutinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjercicioRutina", x => new { x.EjerciciosId, x.RutinaId });
                    table.ForeignKey(
                        name: "FK_EjercicioRutina_Ejercicio_EjerciciosId",
                        column: x => x.EjerciciosId,
                        principalTable: "Ejercicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EjercicioRutina_Rutinas_RutinaId",
                        column: x => x.RutinaId,
                        principalTable: "Rutinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RutinaEjercicio",
                columns: table => new
                {
                    IdRutina = table.Column<int>(type: "int", nullable: false),
                    IdEjercicio = table.Column<int>(type: "int", nullable: false),
                    Repeticiones = table.Column<int>(type: "int", nullable: false),
                    Series = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutinaEjercicio", x => new { x.IdRutina, x.IdEjercicio });
                    table.ForeignKey(
                        name: "FK_RutinaEjercicio_Ejercicio_IdEjercicio",
                        column: x => x.IdEjercicio,
                        principalTable: "Ejercicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RutinaEjercicio_Rutinas_IdRutina",
                        column: x => x.IdRutina,
                        principalTable: "Rutinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ejercicio",
                columns: new[] { "Id", "MaquinaNecesariaIdMaquina", "Nombre" },
                values: new object[,]
                {
                    { 1, null, "Remo" },
                    { 2, null, "Sentadilla" },
                    { 3, null, "Jalon de Pecho" },
                    { 4, null, "Abdominales" },
                    { 5, null, "Bicicleta" },
                    { 6, null, "Caminar en Cinta" },
                    { 7, null, "Peso Muerto" }
                });

            migrationBuilder.InsertData(
                table: "Responsables",
                columns: new[] { "Id", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "María Díaz", "3457436" },
                    { 2, "Ana Fernandez", "43545428" },
                    { 3, "Facundo Lopez", "67254127" },
                    { 4, "Flavia Rodriguez", "32871451726" },
                    { 5, "Karen Gonzalez", "23572673" },
                    { 6, "Nicolas Pereira", "2387625" },
                    { 7, "Marcelo Dominguez", "127457615" }
                });

            migrationBuilder.InsertData(
                table: "TipoDeMaquina",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Bicicleta fija" },
                    { 2, "Cinta Corredor" },
                    { 3, "Escaladora" },
                    { 4, "Máquina de Remo" },
                    { 5, "Prensa de Piernas" },
                    { 6, "Banco de Pecho" },
                    { 7, "Maquina Femorales" }
                });

            migrationBuilder.InsertData(
                table: "TipoRutinas",
                columns: new[] { "IdTipoRutina", "Nombre" },
                values: new object[,]
                {
                    { 1, "Salud" },
                    { 2, "Competición Amateur" },
                    { 3, "Competición Profesional" }
                });

            migrationBuilder.InsertData(
                table: "Local",
                columns: new[] { "Id", "Ciudad", "Direccion", "Nombre", "ResponsableId", "Telefono" },
                values: new object[,]
                {
                    { 1, "Colonia", "Artigas1190", "Local 1", 1, "45220047" },
                    { 2, "Carmelo", "Rivera 1866", "Local 2", 2, "3827562" },
                    { 3, "Nueva Palmira", "Lavalleja 1654", "Local 3", 3, "1847162" },
                    { 4, "Juan Lacaze", "Gral. Flores 1452", "Local 4", 4, "2837426" },
                    { 5, "Nueva Helvecia", "Montevideo 1164", "Local 5", 5, "823746" },
                    { 6, "Rosario", "Argentina 1526", "Local 6", 6, "23874623" },
                    { 7, "Colonia Valdense", "Ruta 1 y Manton", "Local 7", 7, "283746" }
                });

            migrationBuilder.InsertData(
                table: "Rutinas",
                columns: new[] { "Id", "CalificacionPromedio", "Descripcion", "IdTipoRutina" },
                values: new object[,]
                {
                    { 1, 8, "Pecho", 1 },
                    { 2, 9, "Espalda", 1 },
                    { 3, 8, "Hombros", 2 },
                    { 4, 7, "Biceps", 2 },
                    { 5, 9, "Piernas", 3 },
                    { 6, 8, "Dorsales", 3 }
                });

            migrationBuilder.InsertData(
                table: "Maquina",
                columns: new[] { "IdMaquina", "Disponible", "FechaCompra", "LocalId", "PrecioCompra", "TipoDeMaquinaId", "VidaUtil" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2022, 12, 22, 12, 15, 0, 0, DateTimeKind.Unspecified), 1, 15000, 1, 6 },
                    { 2, true, new DateTime(2023, 6, 5, 9, 49, 0, 0, DateTimeKind.Unspecified), 4, 17400, 2, 6 },
                    { 3, true, new DateTime(2024, 3, 21, 14, 51, 0, 0, DateTimeKind.Unspecified), 5, 23050, 3, 5 },
                    { 4, true, new DateTime(2022, 9, 5, 13, 55, 0, 0, DateTimeKind.Unspecified), 5, 26000, 5, 7 },
                    { 5, false, new DateTime(2023, 12, 15, 8, 56, 0, 0, DateTimeKind.Unspecified), 6, 30000, 7, 4 }
                });

            migrationBuilder.InsertData(
                table: "RutinaEjercicio",
                columns: new[] { "IdEjercicio", "IdRutina", "Repeticiones", "Series" },
                values: new object[,]
                {
                    { 3, 1, 8, 4 },
                    { 1, 2, 10, 3 },
                    { 7, 4, 10, 3 },
                    { 5, 5, 12, 4 }
                });

            migrationBuilder.InsertData(
                table: "Socios",
                columns: new[] { "Id", "Email", "IdTipoRutina", "LocalId", "Nombre", "Telefono", "Tipo" },
                values: new object[,]
                {
                    { 1, "jsdfwheuu@gmail.com", 0, 1, "Alberto Dalmas", "23752", "Estandar" },
                    { 2, "hegfiweufgw@hotmail.com", 0, 5, "Martina Perez", "23874253", "Premium" },
                    { 3, "sbakjsfkjasf@hotmail.com", 0, 2, "Carlos Dominicci", "23764253", "Estandar" },
                    { 4, "dhhdk@gmail.com", 0, 6, "Pablo Ayala", "375263", "Estandar" },
                    { 5, "fuhaiuhak@gmail.com", 0, 7, "Daniela Chevalier", "3172652", "Premium" },
                    { 6, "hjgduwfyge@gmail.com", 0, 1, "Manuela Sosa", "8472364", "Premium" }
                });

            migrationBuilder.InsertData(
                table: "SocioRutinas",
                columns: new[] { "IdRutina", "IdSocio", "Calificacion" },
                values: new object[,]
                {
                    { 2, 1, 8 },
                    { 3, 1, 8 },
                    { 3, 3, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicio_MaquinaNecesariaIdMaquina",
                table: "Ejercicio",
                column: "MaquinaNecesariaIdMaquina");

            migrationBuilder.CreateIndex(
                name: "IX_EjercicioRutina_RutinaId",
                table: "EjercicioRutina",
                column: "RutinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Local_ResponsableId",
                table: "Local",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_LocalId",
                table: "Maquina",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_TipoDeMaquinaId",
                table: "Maquina",
                column: "TipoDeMaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_RutinaEjercicio_IdEjercicio",
                table: "RutinaEjercicio",
                column: "IdEjercicio");

            migrationBuilder.CreateIndex(
                name: "IX_Rutinas_IdTipoRutina",
                table: "Rutinas",
                column: "IdTipoRutina");

            migrationBuilder.CreateIndex(
                name: "IX_SocioRutinas_IdRutina",
                table: "SocioRutinas",
                column: "IdRutina");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_LocalId",
                table: "Socios",
                column: "LocalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EjercicioRutina");

            migrationBuilder.DropTable(
                name: "RutinaEjercicio");

            migrationBuilder.DropTable(
                name: "SocioRutinas");

            migrationBuilder.DropTable(
                name: "Ejercicio");

            migrationBuilder.DropTable(
                name: "Rutinas");

            migrationBuilder.DropTable(
                name: "Socios");

            migrationBuilder.DropTable(
                name: "Maquina");

            migrationBuilder.DropTable(
                name: "TipoRutinas");

            migrationBuilder.DropTable(
                name: "Local");

            migrationBuilder.DropTable(
                name: "TipoDeMaquina");

            migrationBuilder.DropTable(
                name: "Responsables");
        }
    }
}
