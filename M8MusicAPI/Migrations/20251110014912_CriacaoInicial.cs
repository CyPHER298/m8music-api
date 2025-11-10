using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M8MusicAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NmCliente = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    idMusic = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    artista = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    genre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.idMusic);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    IdAvalicao = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    IdMusic = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    ClienteId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nota = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.IdAvalicao);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Musics_IdMusic",
                        column: x => x.IdMusic,
                        principalTable: "Musics",
                        principalColumn: "idMusic",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ClienteId",
                table: "Avaliacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_IdMusic",
                table: "Avaliacoes",
                column: "IdMusic");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Musics");
        }
    }
}
