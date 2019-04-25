using LDSI.Lwg.Apresentacao.Data.Context;
using LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces;
using LDSI.Lwg.Apresentacao.Models;

namespace LDSI.Lwg.Apresentacao.Data.Repositories
{
  public class IntegranteRepository: Repository<Integrante>, IIntegranteRepository
  {
    public IntegranteRepository(ApplicationDbContext context) : base(context)
    {
    }
  }
}