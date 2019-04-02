using System;

namespace LDSI.Lwg.Apresentacao.Models
{
  public class Resposta
  {
    public Resposta()
    {
      RespostaId = Guid.NewGuid();
    }
    public Guid RespostaId { get; set; }
    public bool FatoVerdadeiro { get; set; }
    public Guid EqupeId { get; set; }
    public Guid FatoId { get; set; }

    public virtual Equipe Equipe { get; set; }
    public virtual Fato Fato { get; set; }
  }
}