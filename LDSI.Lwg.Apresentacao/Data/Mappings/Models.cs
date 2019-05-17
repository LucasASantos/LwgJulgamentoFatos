using LDSI.Lwg.Apresentacao.Models;
using Microsoft.EntityFrameworkCore;

namespace LDSI.Lwg.Apresentacao.Data.Mappings
{
    public static class Models
    {
        public static void MappingModels(ModelBuilder builder)
        {
            builder.Entity<Curso>().HasKey(c => c.CursoId);
            builder.Entity<Disciplina>().HasKey(c => c.DisciplinaId);
            builder.Entity<Turma>().HasKey(c => c.TurmaId);
            builder.Entity<Integrante>().HasKey(c => c.IntegranteId);
            builder.Entity<Equipe>().HasKey(c => c.EquipeId);
            builder.Entity<Resposta>().HasKey(c => c.RespostaId);
            builder.Entity<JulgamentoFatos>().HasKey(c => c.JulgamentoFatosId);
            builder.Entity<Fato>().HasKey(c => c.FatoId);
            builder.Entity<AlunoTurma>().HasKey(sc => new { sc.AlunoId, sc.TurmaId });

        }
    }
}