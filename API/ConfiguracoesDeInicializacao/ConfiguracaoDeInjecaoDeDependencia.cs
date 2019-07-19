using Biblioteca.Infra.AcessoADados.Repositorio;
using Biblioteca.Infra.Log.AlteracaoDeEntidade;
using Biblioteca.Infra.Log.LogsGerais;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace Biblioteca.API.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDeInjecaoDeDependencia
    {
        public static void Configurar(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRegistrosDeLog>(
                provider => new RegistrosDeLogs(configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddScoped<LogsDeAlteracaoDeEntidade>();
            services.AddScoped<LogadorDeAlteracaoDeEntidade>();
            services.AddScoped<IInterceptor, LogInterceptor>();
        }
    }
}