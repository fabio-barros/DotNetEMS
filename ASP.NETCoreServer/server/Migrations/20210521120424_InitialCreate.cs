using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departamentos",
                columns: table => new
                {
                    depar_num = table.Column<string>(type: "character(4)", fixedLength: true, maxLength: 4, nullable: false),
                    depar_nome = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("departamentos_pkey", x => x.depar_num);
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    fun_num = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    nome = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    sobrenome = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    genero = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    data_contratacao = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("funcionarios_pkey", x => x.fun_num);
                });

            migrationBuilder.CreateTable(
                name: "cargos",
                columns: table => new
                {
                    fun_num = table.Column<int>(type: "integer", nullable: false),
                    titulo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    inicio = table.Column<DateTime>(type: "date", nullable: false),
                    termino = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cargos_pkey", x => new { x.fun_num, x.titulo, x.inicio });
                    table.ForeignKey(
                        name: "cargos_fun_num_fkey",
                        column: x => x.fun_num,
                        principalTable: "funcionarios",
                        principalColumn: "fun_num",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "depar_func",
                columns: table => new
                {
                    depar_num = table.Column<string>(type: "character(4)", fixedLength: true, maxLength: 4, nullable: false),
                    fun_num = table.Column<int>(type: "integer", nullable: false),
                    inicio = table.Column<DateTime>(type: "date", nullable: false),
                    termino = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("depar_func_pkey", x => new { x.fun_num, x.depar_num });
                    table.ForeignKey(
                        name: "depar_func_depar_num_fkey",
                        column: x => x.depar_num,
                        principalTable: "departamentos",
                        principalColumn: "depar_num",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "depar_func_fun_num_fkey",
                        column: x => x.fun_num,
                        principalTable: "funcionarios",
                        principalColumn: "fun_num",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "depar_geren",
                columns: table => new
                {
                    depar_num = table.Column<string>(type: "character(4)", fixedLength: true, maxLength: 4, nullable: false),
                    fun_num = table.Column<int>(type: "integer", nullable: false),
                    incio = table.Column<DateTime>(type: "date", nullable: false),
                    termino = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("depar_geren_pkey", x => new { x.depar_num, x.fun_num });
                    table.ForeignKey(
                        name: "depar_geren_depar_num_fkey",
                        column: x => x.depar_num,
                        principalTable: "departamentos",
                        principalColumn: "depar_num",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "depar_geren_fun_num_fkey",
                        column: x => x.fun_num,
                        principalTable: "funcionarios",
                        principalColumn: "fun_num",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "salarios",
                columns: table => new
                {
                    fun_num = table.Column<int>(type: "integer", nullable: false),
                    inicio = table.Column<DateTime>(type: "date", nullable: false),
                    salario = table.Column<decimal>(type: "numeric", nullable: false),
                    termino = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("salarios_pkey", x => new { x.fun_num, x.inicio });
                    table.ForeignKey(
                        name: "salarios_fun_num_fkey",
                        column: x => x.fun_num,
                        principalTable: "funcionarios",
                        principalColumn: "fun_num",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "depar_fun_depar_num_idx",
                table: "depar_func",
                column: "depar_num");

            migrationBuilder.CreateIndex(
                name: "func_num_depar_num_idx",
                table: "depar_geren",
                column: "depar_num");

            migrationBuilder.CreateIndex(
                name: "IX_depar_geren_fun_num",
                table: "depar_geren",
                column: "fun_num");

            migrationBuilder.CreateIndex(
                name: "departamentos_depar_nome_key",
                table: "departamentos",
                column: "depar_nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cargos");

            migrationBuilder.DropTable(
                name: "depar_func");

            migrationBuilder.DropTable(
                name: "depar_geren");

            migrationBuilder.DropTable(
                name: "salarios");

            migrationBuilder.DropTable(
                name: "departamentos");

            migrationBuilder.DropTable(
                name: "funcionarios");
        }
    }
}
