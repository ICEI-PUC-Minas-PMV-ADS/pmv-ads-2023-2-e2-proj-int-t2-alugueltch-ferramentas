using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MVC.Migrations
{
    public partial class V01Fe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    logradouro = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    complemento = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    bairro = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    cidade = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    estado = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    pais = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_ferramenta",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_ferramenta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_papel",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_papel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_permissao",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_permissao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_processo",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_processo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_situacao",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_situacao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    sexo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    data_nascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    telefone = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    endereco_id = table.Column<long>(type: "bigint", precision: 10, scale: 2, nullable: false),
                    tipo_pessoa = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cliente_pkey", x => new { x.id, x.cpf });
                    table.UniqueConstraint("AK_cliente_cpf", x => x.cpf);
                    table.ForeignKey(
                        name: "FK_Cliente_Endereco",
                        column: x => x.endereco_id,
                        principalTable: "endereco",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "funcionario",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    funcional = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    sexo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    data_nascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    telefone = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    senha = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    permissao_id = table.Column<short>(type: "smallint", nullable: false),
                    papel_id = table.Column<short>(type: "smallint", nullable: false),
                    endereco_id = table.Column<long>(type: "bigint", nullable: false),
                    data_admissao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_demissao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("funcionario_pkey", x => new { x.id, x.cpf, x.funcional });
                    table.UniqueConstraint("AK_funcionario_funcional", x => x.funcional);
                    table.ForeignKey(
                        name: "FK_Funcionario_Endereco",
                        column: x => x.endereco_id,
                        principalTable: "endereco",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Funcionario_Papel",
                        column: x => x.papel_id,
                        principalTable: "tipo_papel",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Funcionario_Permissao",
                        column: x => x.permissao_id,
                        principalTable: "tipo_permissao",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ferramenta",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    tipo_id = table.Column<long>(type: "bigint", nullable: false),
                    marca = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    situacao_id = table.Column<short>(type: "smallint", nullable: false),
                    funcionario_cadastro_funcional = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    quantidade = table.Column<long>(type: "bigint", nullable: true),
                    valor_diaria = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    valor_compra = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ferramenta_pkey", x => new { x.id, x.codigo });
                    table.UniqueConstraint("AK_ferramenta_codigo", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_Ferramenta_Situacao",
                        column: x => x.situacao_id,
                        principalTable: "tipo_situacao",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Ferramenta_Tipo",
                        column: x => x.tipo_id,
                        principalTable: "tipo_ferramenta",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Funcionario_Cadastro_Funcional",
                        column: x => x.funcionario_cadastro_funcional,
                        principalTable: "funcionario",
                        principalColumn: "funcional");
                });

            migrationBuilder.CreateTable(
                name: "emprestimo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cliente_cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    ferramenta_codigo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    indicador_devolucao = table.Column<char>(type: "char", nullable: false),
                    valor_total = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    data_emprestimo = table.Column<DateOnly>(type: "date", nullable: false),
                    data_devolucao = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("emprestimo_pkey", x => new { x.id, x.cliente_cpf, x.ferramenta_codigo });
                    table.ForeignKey(
                        name: "FK_Emprestimo_Cliente_Cpf",
                        column: x => x.cliente_cpf,
                        principalTable: "cliente",
                        principalColumn: "cpf");
                    table.ForeignKey(
                        name: "FK_Emprestimo_Ferramenta_Codigo",
                        column: x => x.ferramenta_codigo,
                        principalTable: "ferramenta",
                        principalColumn: "codigo");
                });

            migrationBuilder.CreateTable(
                name: "orcamento",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cliente_cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    ferramenta_codigo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    valor_total = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    data_orcamento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_validade = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("orcamento_pkey", x => new { x.id, x.cliente_cpf, x.ferramenta_codigo });
                    table.UniqueConstraint("AK_orcamento_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orcamento_Cliente_Cpf",
                        column: x => x.cliente_cpf,
                        principalTable: "cliente",
                        principalColumn: "cpf");
                    table.ForeignKey(
                        name: "FK_Orcamento_Ferramenta_Codigo",
                        column: x => x.ferramenta_codigo,
                        principalTable: "ferramenta",
                        principalColumn: "codigo");
                });

            migrationBuilder.CreateTable(
                name: "processo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    funcionario_responsavel_funcional = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    ferramenta_codigo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    tipo_processo_id = table.Column<short>(type: "smallint", nullable: false),
                    data = table.Column<DateOnly>(type: "date", nullable: false),
                    parecer = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("processo_pkey", x => new { x.id, x.funcionario_responsavel_funcional, x.ferramenta_codigo });
                    table.ForeignKey(
                        name: "FK_Processo_Ferramenta_Codigo",
                        column: x => x.ferramenta_codigo,
                        principalTable: "ferramenta",
                        principalColumn: "codigo");
                    table.ForeignKey(
                        name: "FK_Processo_Funcionario_Responsavel",
                        column: x => x.funcionario_responsavel_funcional,
                        principalTable: "funcionario",
                        principalColumn: "funcional");
                    table.ForeignKey(
                        name: "FK_Processo_Tipo",
                        column: x => x.tipo_processo_id,
                        principalTable: "tipo_processo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Orcamento_Ferramenta",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orcamento_ID = table.Column<long>(type: "bigint", nullable: true),
                    ferramenta_ID = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento_Ferramenta", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ferramenta",
                        column: x => x.ferramenta_ID,
                        principalTable: "ferramenta",
                        principalColumn: "codigo");
                    table.ForeignKey(
                        name: "Fk_Orcamento",
                        column: x => x.orcamento_ID,
                        principalTable: "orcamento",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_endereco_id",
                table: "cliente",
                column: "endereco_id");

            migrationBuilder.CreateIndex(
                name: "IX_emprestimo_cliente_cpf",
                table: "emprestimo",
                column: "cliente_cpf");

            migrationBuilder.CreateIndex(
                name: "IX_emprestimo_ferramenta_codigo",
                table: "emprestimo",
                column: "ferramenta_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_ferramenta_funcionario_cadastro_funcional",
                table: "ferramenta",
                column: "funcionario_cadastro_funcional");

            migrationBuilder.CreateIndex(
                name: "IX_ferramenta_situacao_id",
                table: "ferramenta",
                column: "situacao_id");

            migrationBuilder.CreateIndex(
                name: "IX_ferramenta_tipo_id",
                table: "ferramenta",
                column: "tipo_id");

            migrationBuilder.CreateIndex(
                name: "UQ_Ferramenta_Codigo",
                table: "ferramenta",
                column: "codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_endereco_id",
                table: "funcionario",
                column: "endereco_id");

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_papel_id",
                table: "funcionario",
                column: "papel_id");

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_permissao_id",
                table: "funcionario",
                column: "permissao_id");

            migrationBuilder.CreateIndex(
                name: "UQ_Funcionario_Email",
                table: "funcionario",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Funcionario_Funcional",
                table: "funcionario",
                column: "funcional",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orcamento_cliente_cpf",
                table: "orcamento",
                column: "cliente_cpf");

            migrationBuilder.CreateIndex(
                name: "IX_orcamento_ferramenta_codigo",
                table: "orcamento",
                column: "ferramenta_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_Ferramenta_ferramenta_ID",
                table: "Orcamento_Ferramenta",
                column: "ferramenta_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_Ferramenta_orcamento_ID",
                table: "Orcamento_Ferramenta",
                column: "orcamento_ID");

            migrationBuilder.CreateIndex(
                name: "IX_processo_ferramenta_codigo",
                table: "processo",
                column: "ferramenta_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_processo_funcionario_responsavel_funcional",
                table: "processo",
                column: "funcionario_responsavel_funcional");

            migrationBuilder.CreateIndex(
                name: "IX_processo_tipo_processo_id",
                table: "processo",
                column: "tipo_processo_id");

            migrationBuilder.CreateIndex(
                name: "UQ_Tipo_Ferramenta_Nome",
                table: "tipo_ferramenta",
                column: "nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Tipo_Papel_Nome",
                table: "tipo_papel",
                column: "nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Tipo_Permissao_Nome",
                table: "tipo_permissao",
                column: "nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Tipo_Processo_Nome",
                table: "tipo_processo",
                column: "nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Tipo_Situacao_Nome",
                table: "tipo_situacao",
                column: "nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emprestimo");

            migrationBuilder.DropTable(
                name: "Orcamento_Ferramenta");

            migrationBuilder.DropTable(
                name: "processo");

            migrationBuilder.DropTable(
                name: "orcamento");

            migrationBuilder.DropTable(
                name: "tipo_processo");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "ferramenta");

            migrationBuilder.DropTable(
                name: "tipo_situacao");

            migrationBuilder.DropTable(
                name: "tipo_ferramenta");

            migrationBuilder.DropTable(
                name: "funcionario");

            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropTable(
                name: "tipo_papel");

            migrationBuilder.DropTable(
                name: "tipo_permissao");
        }
    }
}
