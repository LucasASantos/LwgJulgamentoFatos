using System;
using System.Collections.Generic;

namespace LDSI.Lwg.Apresentacao.Models
{
  public class Equipe
  {
    public Equipe()
    {
      EquipeId = Guid.NewGuid();
    }
    public Guid EquipeId { get; set; }
    public virtual List<Resposta> Respostas { get; set; }
    public virtual List<Integrante> Integrantes { get; set; }

  }
}