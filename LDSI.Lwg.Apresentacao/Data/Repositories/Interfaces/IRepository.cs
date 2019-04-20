using System;
using System.Linq;
using System.Threading.Tasks;

namespace LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces
{
  public interface IRepository<TEntity> : IDisposable where TEntity : class
  {
    void Add(TEntity obj);
    TEntity GetById(Guid id);
    Task<TEntity> GetByIdAsync(Guid id);
    IQueryable<TEntity> GetAll();
    void Update(TEntity obj);
    void Remove(Guid id);
    int SaveChanges();
    Task<int> SaveChangesAsync();
  }
}