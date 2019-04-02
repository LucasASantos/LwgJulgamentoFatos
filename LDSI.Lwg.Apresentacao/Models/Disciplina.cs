using System;
using System.Collections.Generic;

namespace LDSI.Lwg.Apresentacao.Models
{
  public class Disciplina
  {
    public Disciplina()
    {
      DisciplinaId = Guid.NewGuid();
    }
    public Guid DisciplinaId { get; set; }
    public string Nome { get; set; }
    public Guid CursoId { get; set; }

    public virtual Curso Curso { get; set; }
    public virtual List<Turma> Turmas { get; set; }
  }
}