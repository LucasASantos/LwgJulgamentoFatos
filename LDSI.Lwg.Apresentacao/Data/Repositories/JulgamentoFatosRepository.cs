using LDSI.Lwg.Apresentacao.Data.Context;
using LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces;
using LDSI.Lwg.Apresentacao.Models;

namespace LDSI.Lwg.Apresentacao.Data.Repositories
{
  public class JulgamentoFatosRepository:Repository<JulgamentoFatos>, IJulgamentoFatosRepository
  {
    public JulgamentoFatosRepository(ApplicationDbContext context) : base(context)
    {
    }
  }
}