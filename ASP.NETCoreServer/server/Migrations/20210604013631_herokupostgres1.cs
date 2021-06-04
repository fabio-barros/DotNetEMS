using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class herokupostgres1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "cargos_fun_num_fkey",
                table: "cargos");

            migrationBuilder.DropForeignKey(
                name: "depar_func_depar_num_fkey",
                table: "depar_func");

            migrationBuilder.DropForeignKey(
                name: "depar_func_fun_num_fkey",
                table: "depar_func");

            migrationBuilder.DropForeignKey(
                name: "depar_geren_depar_num_fkey",
                table: "depar_geren");

            migrationBuilder.DropForeignKey(
                name: "salarios_fun_num_fkey",
                table: "salarios");

            migrationBuilder.DropIndex(
                name: "departamentos_depar_nome_key",
                table: "departamentos");

            migrationBuilder.DropPrimaryKey(
                name: "depar_func_pkey",
                table: "depar_func");

            migrationBuilder.RenameTable(
                name: "depar_geren",
                newName: "departamento_gerencia");

            migrationBuilder.RenameTable(
                name: "depar_func",
                newName: "departamento_funcionario");

            migrationBuilder.RenameColumn(
                name: "fun_num",
                table: "salarios",
                newName: "funcionario_numero");

            migrationBuilder.RenameColumn(
                name: "fun_num",
                table: "funcionarios",
                newName: "funcionario_numero");

            migrationBuilder.RenameColumn(
                name: "depar_num",
                table: "departamentos",
                newName: "departamento_numero");

            migrationBuilder.RenameColumn(
                name: "depar_nome",
                table: "departamentos",
                newName: "departamento_nome");

            migrationBuilder.RenameColumn(
                name: "fun_num",
                table: "cargos",
                newName: "funcionario_numero");

            migrationBuilder.RenameColumn(
                name: "fun_num",
                table: "departamento_gerencia",
                newName: "funcionario_numero");

            migrationBuilder.RenameColumn(
                name: "depar_num",
                table: "departamento_gerencia",
                newName: "departamento_numero");

            migrationBuilder.RenameIndex(
                name: "IX_depar_geren_fun_num",
                table: "departamento_gerencia",
                newName: "IX_departamento_gerencia_funcionario_numero");

            migrationBuilder.RenameIndex(
                name: "func_num_depar_num_idx",
                table: "departamento_gerencia",
                newName: "funcionario_numero_departamento_numero_idx");

            migrationBuilder.RenameColumn(
                name: "depar_num",
                table: "departamento_funcionario",
                newName: "departamento_numero");

            migrationBuilder.RenameColumn(
                name: "fun_num",
                table: "departamento_funcionario",
                newName: "funcionario_numero");

            migrationBuilder.RenameIndex(
                name: "depar_fun_depar_num_idx",
                table: "departamento_funcionario",
                newName: "departamento_funcionario_departamento_numero_idx");

            migrationBuilder.AddPrimaryKey(
                name: "departamento_funcionario_pkey",
                table: "departamento_funcionario",
                columns: new[] { "funcionario_numero", "departamento_numero" });

            migrationBuilder.CreateIndex(
                name: "cpf_idx",
                table: "funcionarios",
                column: "cpf");

            migrationBuilder.CreateIndex(
                name: "departamentos_departamento_nome_key",
                table: "departamentos",
                column: "departamento_numero",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "cargos_funcionario_numero_fkey",
                table: "cargos",
                column: "funcionario_numero",
                principalTable: "funcionarios",
                principalColumn: "funcionario_numero",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "departamento_funcionario_departamento_numero_fkey",
                table: "departamento_funcionario",
                column: "departamento_numero",
                principalTable: "departamentos",
                principalColumn: "departamento_numero",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "departamento_funcionario_funcionario_numero_fkey",
                table: "departamento_funcionario",
                column: "funcionario_numero",
                principalTable: "funcionarios",
                principalColumn: "funcionario_numero",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "departamento_gerencia_departamento_numero_fkey",
                table: "departamento_gerencia",
                column: "departamento_numero",
                principalTable: "departamentos",
                principalColumn: "departamento_numero",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "salarios_funcionario_numero_fkey",
                table: "salarios",
                column: "funcionario_numero",
                principalTable: "funcionarios",
                principalColumn: "funcionario_numero",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "cargos_funcionario_numero_fkey",
                table: "cargos");

            migrationBuilder.DropForeignKey(
                name: "departamento_funcionario_departamento_numero_fkey",
                table: "departamento_funcionario");

            migrationBuilder.DropForeignKey(
                name: "departamento_funcionario_funcionario_numero_fkey",
                table: "departamento_funcionario");

            migrationBuilder.DropForeignKey(
                name: "departamento_gerencia_departamento_numero_fkey",
                table: "departamento_gerencia");

            migrationBuilder.DropForeignKey(
                name: "salarios_funcionario_numero_fkey",
                table: "salarios");

            migrationBuilder.DropIndex(
                name: "cpf_idx",
                table: "funcionarios");

            migrationBuilder.DropIndex(
                name: "departamentos_departamento_nome_key",
                table: "departamentos");

            migrationBuilder.DropPrimaryKey(
                name: "departamento_funcionario_pkey",
                table: "departamento_funcionario");

            migrationBuilder.RenameTable(
                name: "departamento_gerencia",
                newName: "depar_geren");

            migrationBuilder.RenameTable(
                name: "departamento_funcionario",
                newName: "depar_func");

            migrationBuilder.RenameColumn(
                name: "funcionario_numero",
                table: "salarios",
                newName: "fun_num");

            migrationBuilder.RenameColumn(
                name: "funcionario_numero",
                table: "funcionarios",
                newName: "fun_num");

            migrationBuilder.RenameColumn(
                name: "departamento_numero",
                table: "departamentos",
                newName: "depar_num");

            migrationBuilder.RenameColumn(
                name: "departamento_nome",
                table: "departamentos",
                newName: "depar_nome");

            migrationBuilder.RenameColumn(
                name: "funcionario_numero",
                table: "cargos",
                newName: "fun_num");

            migrationBuilder.RenameColumn(
                name: "funcionario_numero",
                table: "depar_geren",
                newName: "fun_num");

            migrationBuilder.RenameColumn(
                name: "departamento_numero",
                table: "depar_geren",
                newName: "depar_num");

            migrationBuilder.RenameIndex(
                name: "IX_departamento_gerencia_funcionario_numero",
                table: "depar_geren",
                newName: "IX_depar_geren_fun_num");

            migrationBuilder.RenameIndex(
                name: "funcionario_numero_departamento_numero_idx",
                table: "depar_geren",
                newName: "func_num_depar_num_idx");

            migrationBuilder.RenameColumn(
                name: "departamento_numero",
                table: "depar_func",
                newName: "depar_num");

            migrationBuilder.RenameColumn(
                name: "funcionario_numero",
                table: "depar_func",
                newName: "fun_num");

            migrationBuilder.RenameIndex(
                name: "departamento_funcionario_departamento_numero_idx",
                table: "depar_func",
                newName: "depar_fun_depar_num_idx");

            migrationBuilder.AddPrimaryKey(
                name: "depar_func_pkey",
                table: "depar_func",
                columns: new[] { "fun_num", "depar_num" });

            migrationBuilder.CreateIndex(
                name: "departamentos_depar_nome_key",
                table: "departamentos",
                column: "depar_nome",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "cargos_fun_num_fkey",
                table: "cargos",
                column: "fun_num",
                principalTable: "funcionarios",
                principalColumn: "fun_num",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "depar_func_depar_num_fkey",
                table: "depar_func",
                column: "depar_num",
                principalTable: "departamentos",
                principalColumn: "depar_num",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "depar_func_fun_num_fkey",
                table: "depar_func",
                column: "fun_num",
                principalTable: "funcionarios",
                principalColumn: "fun_num",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "depar_geren_depar_num_fkey",
                table: "depar_geren",
                column: "depar_num",
                principalTable: "departamentos",
                principalColumn: "depar_num",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "salarios_fun_num_fkey",
                table: "salarios",
                column: "fun_num",
                principalTable: "funcionarios",
                principalColumn: "fun_num",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
