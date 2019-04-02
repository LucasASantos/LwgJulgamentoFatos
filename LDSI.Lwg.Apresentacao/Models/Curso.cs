using System;
using System.Collections.Generic;

namespace LDSI.Lwg.Apresentacao.Models
{
  public class Curso
  {
    public Curso()
    {
      CursoId = Guid.NewGuid();
    }
    public Guid CursoId { get; set; }
    public string Nome { get; set; }
    public string Unidade { get; set; }

    public virtual List<ApplicationUser> Alunos { get; set; }
    public virtual List<Disciplina> Disciplinas { get; set; }
  }
}