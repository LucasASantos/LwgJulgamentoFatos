using System;
using System.Collections.Generic;

namespace LDSI.Lwg.Apresentacao.Models
{
  public class Turma
  {
    public Turma()
    {
      TurmaId = Guid.NewGuid();
    }
    public Guid TurmaId { get; set; }
    public string Codigo { get; set; }
    public Guid DisciplinaId { get; set; }
    public string UserId { get; set; }

    public virtual List<AlunoTurma> AlunosTurmas { get; set; }
    public virtual Disciplina Disciplina { get; set; }
    public virtual ApplicationUser Professor { get; set; }

  }
}