using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vasis.Erp.Facil.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial_MDFE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    InscricaoMunicipal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportadoras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ie = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfCnpj = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RgIe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPessoa = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Cnh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CategoriaCnh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ValidadeCnh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransportadoraId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motoristas_Transportadoras_TransportadoraId",
                        column: x => x.TransportadoraId,
                        principalTable: "Transportadoras",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Renavam = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AnoFabricacao = table.Column<int>(type: "int", nullable: false),
                    TransportadoraId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Transportadoras_TransportadoraId",
                        column: x => x.TransportadoraId,
                        principalTable: "Transportadoras",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_TransportadoraId",
                table: "Motoristas",
                column: "TransportadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_EmpresaId",
                table: "Pessoa",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_TransportadoraId",
                table: "Veiculos",
                column: "TransportadoraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Transportadoras");
        }
    }
}
