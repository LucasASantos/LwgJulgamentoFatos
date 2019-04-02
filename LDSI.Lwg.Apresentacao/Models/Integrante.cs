using System;

namespace LDSI.Lwg.Apresentacao.Models
{
  public class Integrante
  {
    public Integrante()
    {
      IntegranteId = Guid.NewGuid();
    }
    public Guid IntegranteId { get; set; }
    public bool EhLider { get; set; }
    public string UserId { get; set; }
    public Guid EquipeId { get; set; }


    public virtual ApplicationUser Aluno { get; set; }
    public virtual Equipe Equipe { get; set; }
  }
}