using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetinho.Migrations
{
    /// <inheritdoc />
    public partial class AjusteModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_lotes_minerio",
                schema: "public",
                table: "lotes_minerio");

            migrationBuilder.DropIndex(
                name: "IX_lotes_minerio_CodigoLote",
                schema: "public",
                table: "lotes_minerio");

            migrationBuilder.RenameTable(
                name: "lotes_minerio",
                schema: "public",
                newName: "LotesMinerio");

            migrationBuilder.AlterColumn<decimal>(
                name: "Umidade",
                table: "LotesMinerio",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Toneladas",
                table: "LotesMinerio",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TeorFe",
                table: "LotesMinerio",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SiO2",
                table: "LotesMinerio",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "P",
                table: "LotesMinerio",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MinaOrigem",
                table: "LotesMinerio",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "LocalizacaoAtual",
                table: "LotesMinerio",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoLote",
                table: "LotesMinerio",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LotesMinerio",
                table: "LotesMinerio",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LotesMinerio",
                table: "LotesMinerio");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "LotesMinerio",
                newName: "lotes_minerio",
                newSchema: "public");

            migrationBuilder.AlterColumn<decimal>(
                name: "Umidade",
                schema: "public",
                table: "lotes_minerio",
                type: "numeric(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Toneladas",
                schema: "public",
                table: "lotes_minerio",
                type: "numeric(12,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "TeorFe",
                schema: "public",
                table: "lotes_minerio",
                type: "numeric(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "SiO2",
                schema: "public",
                table: "lotes_minerio",
                type: "numeric(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "P",
                schema: "public",
                table: "lotes_minerio",
                type: "numeric(5,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MinaOrigem",
                schema: "public",
                table: "lotes_minerio",
                type: "character varying(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LocalizacaoAtual",
                schema: "public",
                table: "lotes_minerio",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoLote",
                schema: "public",
                table: "lotes_minerio",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_lotes_minerio",
                schema: "public",
                table: "lotes_minerio",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_lotes_minerio_CodigoLote",
                schema: "public",
                table: "lotes_minerio",
                column: "CodigoLote",
                unique: true);
        }
    }
}
