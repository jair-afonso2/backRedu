using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace redu.repository.Migrations
{
    public partial class DefaultConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "desafios",
                columns: table => new
                {
                    idDesafios = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_desafios", x => x.idDesafios);
                });

            migrationBuilder.CreateTable(
                name: "disciplinas",
                columns: table => new
                {
                    idDisciplina = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplinas", x => x.idDisciplina);
                });

            migrationBuilder.CreateTable(
                name: "professores",
                columns: table => new
                {
                    idProfessor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    cidade = table.Column<string>(maxLength: 100, nullable: false),
                    cpf = table.Column<string>(maxLength: 100, nullable: false),
                    estado = table.Column<string>(maxLength: 100, nullable: false),
                    nascimento = table.Column<string>(maxLength: 100, nullable: false),
                    telefone = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professores", x => x.idProfessor);
                });

            migrationBuilder.CreateTable(
                name: "perguntas",
                columns: table => new
                {
                    idPergunta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    idDesafio = table.Column<int>(nullable: false),
                    titulo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perguntas", x => x.idPergunta);
                    table.ForeignKey(
                        name: "FK_perguntas_desafios_idDesafio",
                        column: x => x.idDesafio,
                        principalTable: "desafios",
                        principalColumn: "idDesafios",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "alternativas",
                columns: table => new
                {
                    idAlternativas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    a = table.Column<string>(nullable: true),
                    b = table.Column<string>(nullable: true),
                    c = table.Column<string>(nullable: true),
                    correta = table.Column<string>(maxLength: 1, nullable: true),
                    d = table.Column<string>(nullable: true),
                    e = table.Column<string>(nullable: true),
                    idPergunta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alternativas", x => x.idAlternativas);
                    table.ForeignKey(
                        name: "FK_alternativas_perguntas_idPergunta",
                        column: x => x.idPergunta,
                        principalTable: "perguntas",
                        principalColumn: "idPergunta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "respostas",
                columns: table => new
                {
                    idRespostas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    idAlternativa = table.Column<int>(nullable: false),
                    idAluno = table.Column<int>(nullable: false),
                    opcao = table.Column<string>(maxLength: 1, nullable: true),
                    pontuacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_respostas", x => x.idRespostas);
                    table.ForeignKey(
                        name: "FK_respostas_alternativas_idAlternativa",
                        column: x => x.idAlternativa,
                        principalTable: "alternativas",
                        principalColumn: "idAlternativas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "respostas_grupos",
                columns: table => new
                {
                    idRespostasGrupo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    idAlternativa = table.Column<int>(nullable: false),
                    idGrupo = table.Column<int>(nullable: false),
                    opcao = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_respostas_grupos", x => x.idRespostasGrupo);
                    table.ForeignKey(
                        name: "FK_respostas_grupos_alternativas_idAlternativa",
                        column: x => x.idAlternativa,
                        principalTable: "alternativas",
                        principalColumn: "idAlternativas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "grupos_aluno",
                columns: table => new
                {
                    idGruposAluno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idAluno = table.Column<int>(nullable: false),
                    idGrupo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupos_aluno", x => x.idGruposAluno);
                });

            migrationBuilder.CreateTable(
                name: "turmas_alunos",
                columns: table => new
                {
                    idTurmasAluno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idAluno = table.Column<int>(nullable: false),
                    idTurma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turmas_alunos", x => x.idTurmasAluno);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    idUsuarios = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    flag = table.Column<int>(nullable: false),
                    idAluno_Professor = table.Column<int>(nullable: false),
                    nome = table.Column<string>(maxLength: 100, nullable: false),
                    senha = table.Column<string>(maxLength: 100, nullable: false),
                    sobrenome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.idUsuarios);
                    table.ForeignKey(
                        name: "FK_usuarios_professores_idAluno_Professor",
                        column: x => x.idAluno_Professor,
                        principalTable: "professores",
                        principalColumn: "idProfessor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "aulas",
                columns: table => new
                {
                    idAula = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    idDesafio = table.Column<int>(nullable: false),
                    idDisciplina = table.Column<int>(nullable: false),
                    idProfessor = table.Column<int>(nullable: false),
                    idTurma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aulas", x => x.idAula);
                    table.ForeignKey(
                        name: "FK_aulas_desafios_idDesafio",
                        column: x => x.idDesafio,
                        principalTable: "desafios",
                        principalColumn: "idDesafios",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_aulas_disciplinas_idDisciplina",
                        column: x => x.idDisciplina,
                        principalTable: "disciplinas",
                        principalColumn: "idDisciplina",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_aulas_professores_idProfessor",
                        column: x => x.idProfessor,
                        principalTable: "professores",
                        principalColumn: "idProfessor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "alunos",
                columns: table => new
                {
                    idAluno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    cidade = table.Column<string>(maxLength: 100, nullable: false),
                    cpf = table.Column<string>(maxLength: 100, nullable: true),
                    estado = table.Column<string>(maxLength: 100, nullable: false),
                    idEscola = table.Column<int>(nullable: false),
                    nascimento = table.Column<DateTime>(nullable: false),
                    nomeResponsavel = table.Column<string>(maxLength: 100, nullable: false),
                    telefone = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alunos", x => x.idAluno);
                });

            migrationBuilder.CreateTable(
                name: "turmas",
                columns: table => new
                {
                    idTurmas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ano = table.Column<string>(maxLength: 100, nullable: false),
                    descricao = table.Column<string>(maxLength: 100, nullable: false),
                    idEscola = table.Column<int>(nullable: false),
                    nome = table.Column<string>(maxLength: 100, nullable: false),
                    serie = table.Column<string>(maxLength: 100, nullable: false),
                    statusTurma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turmas", x => x.idTurmas);
                });

            migrationBuilder.CreateTable(
                name: "escolas",
                columns: table => new
                {
                    idEscola = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    cnpj = table.Column<string>(maxLength: 100, nullable: true),
                    endereco = table.Column<string>(nullable: false),
                    nome = table.Column<string>(maxLength: 100, nullable: false),
                    turmaidTurmas = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_escolas", x => x.idEscola);
                    table.ForeignKey(
                        name: "FK_escolas_turmas_turmaidTurmas",
                        column: x => x.turmaidTurmas,
                        principalTable: "turmas",
                        principalColumn: "idTurmas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "grupos",
                columns: table => new
                {
                    idGrupo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    ano = table.Column<string>(maxLength: 100, nullable: false),
                    descricao = table.Column<string>(maxLength: 100, nullable: false),
                    idTurmas = table.Column<int>(nullable: false),
                    nome = table.Column<string>(maxLength: 100, nullable: false),
                    statusGrupo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupos", x => x.idGrupo);
                    table.ForeignKey(
                        name: "FK_grupos_turmas_idTurmas",
                        column: x => x.idTurmas,
                        principalTable: "turmas",
                        principalColumn: "idTurmas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alternativas_idPergunta",
                table: "alternativas",
                column: "idPergunta");

            migrationBuilder.CreateIndex(
                name: "IX_alunos_idEscola",
                table: "alunos",
                column: "idEscola");

            migrationBuilder.CreateIndex(
                name: "IX_aulas_idDesafio",
                table: "aulas",
                column: "idDesafio");

            migrationBuilder.CreateIndex(
                name: "IX_aulas_idDisciplina",
                table: "aulas",
                column: "idDisciplina");

            migrationBuilder.CreateIndex(
                name: "IX_aulas_idProfessor",
                table: "aulas",
                column: "idProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_aulas_idTurma",
                table: "aulas",
                column: "idTurma");

            migrationBuilder.CreateIndex(
                name: "IX_escolas_turmaidTurmas",
                table: "escolas",
                column: "turmaidTurmas");

            migrationBuilder.CreateIndex(
                name: "IX_grupos_idTurmas",
                table: "grupos",
                column: "idTurmas");

            migrationBuilder.CreateIndex(
                name: "IX_grupos_aluno_idAluno",
                table: "grupos_aluno",
                column: "idAluno");

            migrationBuilder.CreateIndex(
                name: "IX_grupos_aluno_idGrupo",
                table: "grupos_aluno",
                column: "idGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_perguntas_idDesafio",
                table: "perguntas",
                column: "idDesafio");

            migrationBuilder.CreateIndex(
                name: "IX_respostas_idAlternativa",
                table: "respostas",
                column: "idAlternativa");

            migrationBuilder.CreateIndex(
                name: "IX_respostas_idAluno",
                table: "respostas",
                column: "idAluno");

            migrationBuilder.CreateIndex(
                name: "IX_respostas_grupos_idAlternativa",
                table: "respostas_grupos",
                column: "idAlternativa");

            migrationBuilder.CreateIndex(
                name: "IX_respostas_grupos_idGrupo",
                table: "respostas_grupos",
                column: "idGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_turmas_idEscola",
                table: "turmas",
                column: "idEscola");

            migrationBuilder.CreateIndex(
                name: "IX_turmas_alunos_idAluno",
                table: "turmas_alunos",
                column: "idAluno");

            migrationBuilder.CreateIndex(
                name: "IX_turmas_alunos_idTurma",
                table: "turmas_alunos",
                column: "idTurma");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_idAluno_Professor",
                table: "usuarios",
                column: "idAluno_Professor");

            migrationBuilder.AddForeignKey(
                name: "FK_respostas_alunos_idAluno",
                table: "respostas",
                column: "idAluno",
                principalTable: "alunos",
                principalColumn: "idAluno",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_respostas_grupos_grupos_idGrupo",
                table: "respostas_grupos",
                column: "idGrupo",
                principalTable: "grupos",
                principalColumn: "idGrupo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_grupos_aluno_alunos_idAluno",
                table: "grupos_aluno",
                column: "idAluno",
                principalTable: "alunos",
                principalColumn: "idAluno",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_grupos_aluno_grupos_idGrupo",
                table: "grupos_aluno",
                column: "idGrupo",
                principalTable: "grupos",
                principalColumn: "idGrupo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_turmas_alunos_turmas_idTurma",
                table: "turmas_alunos",
                column: "idTurma",
                principalTable: "turmas",
                principalColumn: "idTurmas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_turmas_alunos_alunos_idAluno",
                table: "turmas_alunos",
                column: "idAluno",
                principalTable: "alunos",
                principalColumn: "idAluno",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_alunos_idAluno_Professor",
                table: "usuarios",
                column: "idAluno_Professor",
                principalTable: "alunos",
                principalColumn: "idAluno",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_aulas_turmas_idTurma",
                table: "aulas",
                column: "idTurma",
                principalTable: "turmas",
                principalColumn: "idTurmas",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_alunos_escolas_idEscola",
                table: "alunos",
                column: "idEscola",
                principalTable: "escolas",
                principalColumn: "idEscola",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_turmas_escolas_idEscola",
                table: "turmas",
                column: "idEscola",
                principalTable: "escolas",
                principalColumn: "idEscola",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_turmas_escolas_idEscola",
                table: "turmas");

            migrationBuilder.DropTable(
                name: "aulas");

            migrationBuilder.DropTable(
                name: "grupos_aluno");

            migrationBuilder.DropTable(
                name: "respostas");

            migrationBuilder.DropTable(
                name: "respostas_grupos");

            migrationBuilder.DropTable(
                name: "turmas_alunos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "disciplinas");

            migrationBuilder.DropTable(
                name: "alternativas");

            migrationBuilder.DropTable(
                name: "grupos");

            migrationBuilder.DropTable(
                name: "alunos");

            migrationBuilder.DropTable(
                name: "professores");

            migrationBuilder.DropTable(
                name: "perguntas");

            migrationBuilder.DropTable(
                name: "desafios");

            migrationBuilder.DropTable(
                name: "escolas");

            migrationBuilder.DropTable(
                name: "turmas");
        }
    }
}
