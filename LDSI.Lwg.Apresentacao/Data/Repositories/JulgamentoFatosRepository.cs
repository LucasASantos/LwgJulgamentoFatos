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

        public  Task<List<JulgamentoFatos>> GetJulagementosOfTurmasAsync(Guid turmaId)
        {
            var a = Db.Set<Fato>().Where(f => f.TurmaId == turmaId).Select(f => f.JulgamentoFatosId);
            return GetAll().Where(j => a.Any(id => id == j.JulgamentoFatosId)).Include(c=> c.Professor).ToListAsync();
        }

        public override JulgamentoFatos GetById(Guid id)
        {
            return DbSet.Include(c => c.Fatos).ThenInclude((Fato d) => d.Turma).FirstOrDefault(c => c.JulgamentoFatosId == id);
        }
    }
}