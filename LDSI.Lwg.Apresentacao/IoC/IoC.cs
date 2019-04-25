

using LDSI.Lwg.Apresentacao.Data.Context;
using LDSI.Lwg.Apresentacao.Data.Repositories;
using LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LDSI.Lwg.Apresentacao.IoC
{
  public static class IoC
  {
    public static void Configure(IServiceCollection services)
    {
        services.AddScoped<ICursoRepository, CursoRepository>();
        services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
        services.AddScoped<ITurmaRepository, TurmaRepository>();
        services.AddScoped<IFatoRepository, FatoRepository>();
        services.AddScoped<IJulgamentoFatosRepository, JulgamentoFatosRepository>();
        services.AddScoped<IEquipeRepository, EquipeRepository>();
        services.AddScoped<IIntegranteRepository, IntegranteRepository>();
        services.AddScoped<ApplicationDbContext>();
    }
  }
}