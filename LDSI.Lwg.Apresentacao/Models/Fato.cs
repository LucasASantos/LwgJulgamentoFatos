using System;
using System.Collections.Generic;

namespace LDSI.Lwg.Apresentacao.Models
{
  public class Fato 
  {
    public Fato()
    {
      FatoId = Guid.NewGuid();
    }
    public Guid FatoId { get; set; }
    public string Texto { get; set; }
    public bool Verdadeiro { get; set; }
    public int Ordem { get; set; }
    public string Topicos { get; set; }
    public Guid JulgamentoFatosId { get; set; }

    public virtual List<Resposta> Respostas { get; set; }
    public virtual JulgamentoFatos JulgamentoFatos { get; set; }


  }
}