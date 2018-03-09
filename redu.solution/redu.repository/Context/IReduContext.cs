using System.Linq;
using Microsoft.EntityFrameworkCore;
using redu.domain.Models;

namespace redu.repository.Context
{
    public class IReduContext : DbContext
    {
        public IReduContext(DbContextOptions<IReduContext> options) : base(options)
        {
        }

        public DbSet<alternativa> alternativas { get; set; }
        public DbSet<aluno> alunos { get; set; }
        public DbSet<aula> aulas { get; set; }
        public DbSet<desafio> desafios { get; set; }
        public DbSet<disciplina> disciplinas { get; set; }
        public DbSet<escola> escolas { get; set; }

        public DbSet<grupo> grupos { get; set; }

        public DbSet<grupos_aluno> grupos_alunos { get; set; }
        public DbSet<pergunta> perguntas { get; set; }
        public DbSet<professore> professores { get; set; }
        public DbSet<resposta> respostas { get; set; }
        public DbSet<respostas_grupo> respostas_grupos { get; set; }
        //public DbSet<series_turma> series_turma { get; set; }
        public DbSet<turma> turmas { get; set; }
        public DbSet<turmas_aluno> turmas_aluno { get; set; }
        public DbSet<usuario> usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<alternativa>().ToTable("alternativas");
            modelBuilder.Entity<aluno>().ToTable("alunos");
            modelBuilder.Entity<aula>().ToTable("aulas");
            modelBuilder.Entity<desafio>().ToTable("desafios");
            modelBuilder.Entity<disciplina>().ToTable("disciplinas");
            modelBuilder.Entity<escola>().ToTable("escolas");
            modelBuilder.Entity<grupo>().ToTable("grupos");
            modelBuilder.Entity<grupos_aluno>().ToTable("grupos_aluno");
            modelBuilder.Entity<pergunta>().ToTable("perguntas");
            modelBuilder.Entity<professore>().ToTable("professores");
            modelBuilder.Entity<resposta>().ToTable("respostas");
            modelBuilder.Entity<respostas_grupo>().ToTable("respostas_grupos");
            //modelBuilder.Entity<series_turma>().ToTable("series_turmas");
            modelBuilder.Entity<turma>().ToTable("turmas");
            modelBuilder.Entity<turmas_aluno>().ToTable("turmas_alunos");
            modelBuilder.Entity<usuario>().ToTable("usuarios");

            base.OnModelCreating(modelBuilder);
        }
    }
}