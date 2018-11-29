using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCM.Infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proprietario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rua = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    ProprietarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Proprietario_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(nullable: true),
                    Renavam = table.Column<string>(nullable: true),
                    MarcaId = table.Column<int>(nullable: true),
                    ProprietarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbVeiculo_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TbVeiculo_Proprietario_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbInfracao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<decimal>(nullable: false),
                    Pontuacao = table.Column<double>(nullable: false),
                    VeiculoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbInfracao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbInfracao_TbVeiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TbVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ProprietarioId",
                table: "Endereco",
                column: "ProprietarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbInfracao_VeiculoId",
                table: "TbInfracao",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TbVeiculo_MarcaId",
                table: "TbVeiculo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_TbVeiculo_ProprietarioId",
                table: "TbVeiculo",
                column: "ProprietarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "TbInfracao");

            migrationBuilder.DropTable(
                name: "TbVeiculo");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Proprietario");
        }
    }
}
