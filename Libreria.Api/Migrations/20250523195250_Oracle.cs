using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria.Api.Migrations
{
    /// <inheritdoc />
    public partial class Oracle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Precio = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Lugar = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descripcion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Modalidad = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    ParticipanteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Dni = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Nombres = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Apellidos = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Institucion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Correo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefono = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.ParticipanteId);
                });

            migrationBuilder.CreateTable(
                name: "Ponentes",
                columns: table => new
                {
                    PonenteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombres = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Apellidos = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Institucion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Correo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Especialidad = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponentes", x => x.PonenteId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Capacidad = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Ubicacion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "HistorialEventos",
                columns: table => new
                {
                    HistolialEventoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Fecha = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    participantes = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    recaudacion = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    certificados = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialEventos", x => x.HistolialEventoId);
                    table.ForeignKey(
                        name: "FK_HistorialEventos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    InscripcionId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EstadoPago = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ParticipanteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.InscripcionId);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "ParticipanteId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EventoPonentes",
                columns: table => new
                {
                    EventoPonenteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PonenteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoPonentes", x => x.EventoPonenteId);
                    table.ForeignKey(
                        name: "FK_EventoPonentes_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EventoPonentes_Ponentes_PonenteId",
                        column: x => x.PonenteId,
                        principalTable: "Ponentes",
                        principalColumn: "PonenteId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    SesionId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SalaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.SesionId);
                    table.ForeignKey(
                        name: "FK_Sesiones_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Sesiones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    CertificadoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Detalles = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    InscripcionId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.CertificadoId);
                    table.ForeignKey(
                        name: "FK_Certificados_Inscripciones_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "Inscripciones",
                        principalColumn: "InscripcionId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Monto = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    FechaPago = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MetodoPago = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ComprobantePago = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    InscripcionId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pagos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Pagos_Inscripciones_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "Inscripciones",
                        principalColumn: "InscripcionId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    AsistenciaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FechaRegistro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Estado = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    ParticipanteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SesionId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => x.AsistenciaId);
                    table.ForeignKey(
                        name: "FK_Asistencias_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "ParticipanteId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Asistencias_Sesiones_SesionId",
                        column: x => x.SesionId,
                        principalTable: "Sesiones",
                        principalColumn: "SesionId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_ParticipanteId",
                table: "Asistencias",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_SesionId",
                table: "Asistencias",
                column: "SesionId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_InscripcionId",
                table: "Certificados",
                column: "InscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoPonentes_EventoId",
                table: "EventoPonentes",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoPonentes_PonenteId",
                table: "EventoPonentes",
                column: "PonenteId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialEventos_EventoId",
                table: "HistorialEventos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EventoId",
                table: "Inscripciones",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ParticipanteId",
                table: "Inscripciones",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_EventoId",
                table: "Pagos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_InscripcionId",
                table: "Pagos",
                column: "InscripcionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_EventoId",
                table: "Sesiones",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_SalaId",
                table: "Sesiones",
                column: "SalaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencias");

            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "EventoPonentes");

            migrationBuilder.DropTable(
                name: "HistorialEventos");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Ponentes");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
