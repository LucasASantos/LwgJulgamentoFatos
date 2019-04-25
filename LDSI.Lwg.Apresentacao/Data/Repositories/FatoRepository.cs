using LDSI.Lwg.Apresentacao.Data.Context;
using LDSI.Lwg.Apresentacao.Models;

namespace LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces
{
  public class FatoRepository: Repository<Fato>, IFatoRepository
  {
    public FatoRepository(ApplicationDbContext context) : base(context)
    {
    }
  }
}