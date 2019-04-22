using LDSI.Lwg.Apresentacao.Data.Context;
using LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces;
using LDSI.Lwg.Apresentacao.Models;

namespace LDSI.Lwg.Apresentacao.Data.Repositories
{
  public class DisciplinaRepository: Repository<Disciplina>, IDisciplinaRepository
  {
    public DisciplinaRepository(ApplicationDbContext context) : base(context)
    {
    }
  }
}