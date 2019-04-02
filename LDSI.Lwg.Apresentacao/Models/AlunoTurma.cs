using System;
using Microsoft.Net.Http.Headers;

namespace LDSI.Lwg.Apresentacao.Models
{
  public class AlunoTurma
  {
    public string AlunoId { get; set; }
    public Guid TurmaId { get; set; }

    public virtual ApplicationUser Aluno { get; set; }
    public virtual Turma Turma { get; set; }
  }
}