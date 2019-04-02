using LDSI.Lwg.Apresentacao.Models;
using Microsoft.EntityFrameworkCore;

namespace LDSI.Lwg.Apresentacao.Data.Mappings
{
  public static class Relations
  {
    public static void MappingRelations(ModelBuilder builder)
    {
      builder.Entity<ApplicationUser>()
        .HasOne(c => c.Curso)
        .WithMany(c => c.Alunos);
      builder.Entity<ApplicationUser>()
        .HasMany(c => c.Intregracoes)
        .WithOne(c => c.Aluno)
        .HasForeignKey(c => c.UserId);
      builder.Entity<ApplicationUser>()
        .HasMany(c => c.Turmas)
        .WithOne(c => c.Professor)
        .HasForeignKey(c => c.UserId);

      builder.Entity<Turma>()
        .HasOne(c => c.Professor)
        .WithMany(c => c.Turmas)
        .HasForeignKey(c => c.UserId);

      builder.Entity<AlunoTurma>()
        .HasOne(sc => sc.Aluno)
        .WithMany(s => s.AlunosTurmas)
        .HasForeignKey(sc => sc.AlunoId);
      builder.Entity<AlunoTurma>()
        .HasOne(sc => sc.Turma)
        .WithMany(s => s.AlunosTurmas)
        .HasForeignKey(sc => sc.TurmaId);

      builder.Entity<Curso>()
        .HasMany(c => c.Alunos)
        .WithOne(c => c.Curso)
        .HasForeignKey(c => c.CursoId);
      builder.Entity<Curso>()
        .HasMany(c => c.Disciplinas)
        .WithOne(c => c.Curso)
        .HasForeignKey(c => c.DisciplinaId);

      builder.Entity<Disciplina>()
        .HasMany(c => c.Turmas)
        .WithOne(c => c.Disciplina)
        .HasForeignKey(c => c.TurmaId);
      builder.Entity<Disciplina>()
        .HasOne(c => c.Curso)
        .WithMany(c => c.Disciplinas)
        .HasForeignKey(c => c.CursoId);


      builder.Entity<Turma>()
        .HasMany(c => c.AlunosTurmas)
        .WithOne(c => c.Turma)
        .HasForeignKey(c => c.TurmaId);
      builder.Entity<Turma>()
        .HasOne(c => c.Disciplina)
        .WithMany(c => c.Turmas)
        .HasForeignKey(c => c.DisciplinaId);

      builder.Entity<Integrante>()
        .HasOne(c => c.Aluno)
        .WithMany(c => c.Intregracoes)
        .HasForeignKey(c => c.UserId);
      builder.Entity<Integrante>()
        .HasOne(c => c.Equipe)
        .WithMany(c => c.Integrantes)
        .HasForeignKey(c => c.EquipeId);

      builder.Entity<Equipe>()
        .HasMany(c => c.Respostas)
        .WithOne(c => c.Equipe)
        .HasForeignKey(c => c.EqupeId);
      builder.Entity<Equipe>()
        .HasMany(c => c.Integrantes)
        .WithOne(c => c.Equipe)
        .HasForeignKey(c => c.IntegranteId);

      builder.Entity<Resposta>()
        .HasOne(c => c.Equipe)
        .WithMany(c => c.Respostas)
        .HasForeignKey(c => c.EqupeId);
      builder.Entity<Resposta>()
        .HasOne(c => c.Fato)
        .WithMany(c => c.Respostas)
        .HasForeignKey(c => c.FatoId);

      builder.Entity<Fato>()
        .HasMany(c => c.Respostas)
        .WithOne(c => c.Fato)
        .HasForeignKey(c => c.RespostaId);
      builder.Entity<Fato>()
        .HasOne(c => c.JulgamentoFatos)
        .WithMany(c => c.Fatos)
        .HasForeignKey(c => c.JulgamentoFatosId);

      builder.Entity<JulgamentoFatos>()
        .HasMany(c => c.Fatos)
        .WithOne(c => c.JulgamentoFatos)
        .HasForeignKey(c => c.FatoId);
      builder.Entity<JulgamentoFatos>()
        .HasOne(c => c.Professor)
        .WithMany(c => c.JulgamentosFatos)
        .HasForeignKey(c => c.UserId);




    }
  }
}