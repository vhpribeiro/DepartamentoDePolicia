using DepartamentoDePolicia.API.Middlewares;
using DepartamentoDePolicia.Infra.Configuracoes.Orm;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DepartamentoDePolicia.API.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDeSessaoDoBanco
    {
        public static void Configurar(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(provider => ConfiguracoesNHibernate
                .ConfigurarSessionFactory(configuration["Data:DefaultConnection:ConnectionString"])
                .OpenSession());
            services.AddScoped<UnitOfWorkFilter>();
        }
    }
}