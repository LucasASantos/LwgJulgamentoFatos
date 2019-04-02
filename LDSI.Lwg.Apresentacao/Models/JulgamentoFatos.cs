using System;
using System.Collections.Generic;
using LDSI.Lwg.Apresentacao.Enums;

namespace LDSI.Lwg.Apresentacao.Models
{
  public class JulgamentoFatos
  {
    public JulgamentoFatos()
    {
      JulgamentoFatosId = Guid.NewGuid();
    }
    public Guid JulgamentoFatosId { get; set; }
    public int TamanhoEquipe { get; set; }
    public TimeSpan TempoExibicao { get; set; }
    public  StatusJugamentoFatos Status { get; set; }
    public string UserId { get; set; }



    public virtual List<Fato> Fatos { get; set; }
    public virtual ApplicationUser Professor { get; set; }

  }
}