using Biblioteca.API.Middlewares;
using Biblioteca.Infra.Configuracoes.Orm;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace Biblioteca.API.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDeSessaoDoBanco
    {
        public static void Configurar(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(provider => ConfiguracoesNHibernate
                .ConfigurarSessionFactory(configuration["Data:DefaultConnection:ConnectionString"])
                .WithOptions()
                .Interceptor(provider.GetService<IInterceptor>())
                .OpenSession());
            services.AddScoped<UnitOfWorkFilter>();
        }
    }
}