using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace LDSI.Lwg.Apresentacao.Models
{
  public class ApplicationUser: IdentityUser
  {
    public string Nome { get; set; }
    public Guid CursoId { get; set; }

    public virtual Curso Curso { get; set; }
    public virtual List<AlunoTurma> AlunosTurmas { get; set; }
    public virtual List<Turma> Turmas { get; set; }
    public virtual List<Integrante> Intregracoes { get; set; }
    public virtual  List<JulgamentoFatos> JulgamentosFatos { get; set; }

  }
}