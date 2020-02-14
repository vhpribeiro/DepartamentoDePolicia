using Departamento.De.Policia.Infra.Configuracoes.Orm;
using DepartamentoDePolicia.API.Middlewares;
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