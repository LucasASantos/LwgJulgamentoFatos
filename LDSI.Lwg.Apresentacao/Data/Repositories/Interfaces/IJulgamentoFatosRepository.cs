using LDSI.Lwg.Apresentacao.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces
{
    public interface IJulgamentoFatosRepository : IRepository<JulgamentoFatos>
    {
        Task<List<JulgamentoFatos>> GetJulagementosOfTurmasAsync(Guid turmaId);
    }
}