using LDSI.Lwg.Apresentacao.Data.Context;
using LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces;
using LDSI.Lwg.Apresentacao.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDSI.Lwg.Apresentacao.Data.Repositories
{
  public class JulgamentoFatosRepository:Repository<JulgamentoFatos>, IJulgamentoFatosRepository
  {
    public JulgamentoFatosRepository(ApplicationDbContext context) : base(context)
    {
    }

        public  Task<List<JulgamentoFatos>> GetJulagementosOfTurmasAsync(Guid turmaId) => base
            .GetAll()
            .Where(c => c.Fatos != null && c.Fatos.Any(f => f.TurmaId == turmaId))
            .ToListAsync();
  }
}