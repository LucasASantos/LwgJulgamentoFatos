using LDSI.Lwg.Apresentacao.Data.Context;
using LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces;
using LDSI.Lwg.Apresentacao.Models;

namespace LDSI.Lwg.Apresentacao.Data.Repositories
{
  public class EquipeRepository:Repository<Equipe>,IEquipeRepository
  {
    public EquipeRepository(ApplicationDbContext context) : base(context)
    {
    }
  }
}