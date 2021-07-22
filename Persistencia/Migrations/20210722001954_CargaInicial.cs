using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Persistencia.Migrations
{
    public partial class CargaInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carreras",
                columns: table => new
                {
                    CarreraId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    CostoCredito = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carreras", x => x.CarreraId);
                });

            migrationBuilder.CreateTable(
                name: "estudiantes",
                columns: table => new
                {
                    EstudianteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiantes", x => x.EstudianteId);
                });

            migrationBuilder.CreateTable(
                name: "materias",
                columns: table => new
                {
                    MateriaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Area = table.Column<string>(type: "text", nullable: true),
                    Creditos = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materias", x => x.MateriaId);
                });

            migrationBuilder.CreateTable(
                name: "periodos",
                columns: table => new
                {
                    PeriodoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodos", x => x.PeriodoId);
                });

            migrationBuilder.CreateTable(
                name: "mallas",
                columns: table => new
                {
                    MallaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nivel = table.Column<string>(type: "text", nullable: true),
                    CarreraId = table.Column<int>(type: "integer", nullable: false),
                    MateriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mallas", x => x.MallaId);
                    table.ForeignKey(
                        name: "FK_mallas_carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "carreras",
                        principalColumn: "CarreraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mallas_materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "materias",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "configuracion",
                columns: table => new
                {
                    ConfiguracionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EscuelaNombre = table.Column<string>(type: "text", nullable: true),
                    PeriodoVigenteId = table.Column<int>(type: "integer", nullable: false),
                    CreditosMaximo = table.Column<int>(type: "integer", nullable: false),
                    PesoNota1 = table.Column<float>(type: "real", nullable: false),
                    PesoNota2 = table.Column<float>(type: "real", nullable: false),
                    PesoNota3 = table.Column<float>(type: "real", nullable: false),
                    NotaMinima = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuracion", x => x.ConfiguracionId);
                    table.ForeignKey(
                        name: "FK_configuracion_periodos_PeriodoVigenteId",
                        column: x => x.PeriodoVigenteId,
                        principalTable: "periodos",
                        principalColumn: "PeriodoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Jornada = table.Column<string>(type: "text", nullable: true),
                    CarreraId = table.Column<int>(type: "integer", nullable: false),
                    PeriodoId = table.Column<int>(type: "integer", nullable: false),
                    MateriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos", x => x.CursoId);
                    table.ForeignKey(
                        name: "FK_cursos_carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "carreras",
                        principalColumn: "CarreraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cursos_materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "materias",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cursos_periodos_PeriodoId",
                        column: x => x.PeriodoId,
                        principalTable: "periodos",
                        principalColumn: "PeriodoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "matriculas",
                columns: table => new
                {
                    MatriculaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: true),
                    EstudianteId = table.Column<int>(type: "integer", nullable: false),
                    CarreraId = table.Column<int>(type: "integer", nullable: false),
                    PeriodoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matriculas", x => x.MatriculaId);
                    table.ForeignKey(
                        name: "FK_matriculas_carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "carreras",
                        principalColumn: "CarreraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_matriculas_estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "estudiantes",
                        principalColumn: "EstudianteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_matriculas_periodos_PeriodoId",
                        column: x => x.PeriodoId,
                        principalTable: "periodos",
                        principalColumn: "PeriodoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prerequisitos",
                columns: table => new
                {
                    MallaId = table.Column<int>(type: "integer", nullable: false),
                    MateriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prerequisitos", x => new { x.MallaId, x.MateriaId });
                    table.ForeignKey(
                        name: "FK_prerequisitos_mallas_MallaId",
                        column: x => x.MallaId,
                        principalTable: "mallas",
                        principalColumn: "MallaId");
                    table.ForeignKey(
                        name: "FK_prerequisitos_materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "materias",
                        principalColumn: "MateriaId");
                });

            migrationBuilder.CreateTable(
                name: "matriculas_Det",
                columns: table => new
                {
                    Matricula_DetId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MatriculaId = table.Column<int>(type: "integer", nullable: false),
                    CursoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matriculas_Det", x => x.Matricula_DetId);
                    table.ForeignKey(
                        name: "FK_matriculas_Det_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_matriculas_Det_matriculas_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "matriculas",
                        principalColumn: "MatriculaId");
                });

            migrationBuilder.CreateTable(
                name: "calificaciones",
                columns: table => new
                {
                    CalificacionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Matricula_DetId = table.Column<int>(type: "integer", nullable: false),
                    Nota1 = table.Column<float>(type: "real", nullable: false),
                    Nota2 = table.Column<float>(type: "real", nullable: false),
                    Nota3 = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calificaciones", x => x.CalificacionId);
                    table.ForeignKey(
                        name: "FK_calificaciones_matriculas_Det_Matricula_DetId",
                        column: x => x.Matricula_DetId,
                        principalTable: "matriculas_Det",
                        principalColumn: "Matricula_DetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_calificaciones_Matricula_DetId",
                table: "calificaciones",
                column: "Matricula_DetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_configuracion_PeriodoVigenteId",
                table: "configuracion",
                column: "PeriodoVigenteId");

            migrationBuilder.CreateIndex(
                name: "IX_cursos_CarreraId",
                table: "cursos",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_cursos_MateriaId",
                table: "cursos",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_cursos_PeriodoId",
                table: "cursos",
                column: "PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_mallas_CarreraId",
                table: "mallas",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_mallas_MateriaId",
                table: "mallas",
                column: "MateriaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_matriculas_CarreraId",
                table: "matriculas",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_matriculas_EstudianteId",
                table: "matriculas",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_matriculas_PeriodoId",
                table: "matriculas",
                column: "PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_matriculas_Det_CursoId",
                table: "matriculas_Det",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_matriculas_Det_MatriculaId",
                table: "matriculas_Det",
                column: "MatriculaId");

            migrationBuilder.CreateIndex(
                name: "IX_prerequisitos_MateriaId",
                table: "prerequisitos",
                column: "MateriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calificaciones");

            migrationBuilder.DropTable(
                name: "configuracion");

            migrationBuilder.DropTable(
                name: "prerequisitos");

            migrationBuilder.DropTable(
                name: "matriculas_Det");

            migrationBuilder.DropTable(
                name: "mallas");

            migrationBuilder.DropTable(
                name: "cursos");

            migrationBuilder.DropTable(
                name: "matriculas");

            migrationBuilder.DropTable(
                name: "materias");

            migrationBuilder.DropTable(
                name: "carreras");

            migrationBuilder.DropTable(
                name: "estudiantes");

            migrationBuilder.DropTable(
                name: "periodos");
        }
    }
}
