using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCM.Infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acessorio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessorio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(30)", nullable: true)
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
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true)
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
                    Rua = table.Column<string>(type: "varchar(200)", nullable: true),
                    CEP = table.Column<string>(type: "varchar(9)", nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(400)", nullable: true),
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
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(type: "varchar(10)", nullable: true),
                    Renavam = table.Column<string>(type: "varchar(15)", nullable: true),
                    MarcaId = table.Column<int>(nullable: true),
                    ProprietarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veiculo_Proprietario_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcessorioVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    VeiculoId = table.Column<int>(nullable: false),
                    AcessorioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessorioVeiculo", x => new { x.AcessorioId, x.VeiculoId });
                    table.ForeignKey(
                        name: "FK_AcessorioVeiculo_Acessorio_AcessorioId",
                        column: x => x.AcessorioId,
                        principalTable: "Acessorio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcessorioVeiculo_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Infracao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<decimal>(nullable: false),
                    Pontuacao = table.Column<double>(nullable: false),
                    VeiculoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infracao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Infracao_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Acessorio",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Roda esportiva" },
                    { 2, "Aerofolio" },
                    { 3, "Banco esportivo" }
                });

            migrationBuilder.InsertData(
                table: "Marca",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "VW" },
                    { 2, "FIAT" },
                    { 3, "Ford" }
                });

            migrationBuilder.InsertData(
                table: "Proprietario",
                columns: new[] { "Id", "Email", "Nome" },
                values: new object[,]
                {
                    { 1, "neemias@teste.com", "Neemias" },
                    { 2, "marcio@teste.com", "Marcio" }
                });

            migrationBuilder.InsertData(
                table: "Veiculo",
                columns: new[] { "Id", "MarcaId", "Placa", "ProprietarioId", "Renavam" },
                values: new object[] { 1, null, "ABC-1234", 1, "12212121212" });

            migrationBuilder.InsertData(
                table: "Veiculo",
                columns: new[] { "Id", "MarcaId", "Placa", "ProprietarioId", "Renavam" },
                values: new object[] { 2, null, "ABC-1235", 2, "67676766767" });

            migrationBuilder.InsertData(
                table: "AcessorioVeiculo",
                columns: new[] { "AcessorioId", "VeiculoId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 4 },
                    { 1, 2, 2 },
                    { 2, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Infracao",
                columns: new[] { "Id", "Pontuacao", "Valor", "VeiculoId" },
                values: new object[,]
                {
                    { 1, 10.0, 200m, 1 },
                    { 3, 50.0, 700m, 1 },
                    { 2, 30.0, 500m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcessorioVeiculo_VeiculoId",
                table: "AcessorioVeiculo",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ProprietarioId",
                table: "Endereco",
                column: "ProprietarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Infracao_VeiculoId",
                table: "Infracao",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_MarcaId",
                table: "Veiculo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_ProprietarioId",
                table: "Veiculo",
                column: "ProprietarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcessorioVeiculo");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Infracao");

            migrationBuilder.DropTable(
                name: "Acessorio");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Proprietario");
        }
    }
}
