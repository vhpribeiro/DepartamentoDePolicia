using Departamento.De.Policia.Aplicacao;
using Departamento.De.Policia.Dominio.Armas;
using Departamento.De.Policia.Dominio.DepartamentosDePolicias;
using Departamento.De.Policia.Dominio.Policiais;
using Departamento.De.Policia.Infra.AcessoADados.Repositorio;
using Departamento.De.Policia.Infra.Log.AlteracaoDeEntidade;
using Departamento.De.Policia.Infra.Log.LogsGerais;
using DepartamentoDePolicia.Infra.Log.AlteracaoDeEntidade;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace DepartamentoDePolicia.API.ConfiguracoesDeInicializacao
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
            services.AddScoped<IServicoDeDistribuicaoDePoliciais, ServicoDeDistribuicaoDePoliciais>();
            services.AddScoped<IDepartamentoDePoliciaisRepositorio, DepartamentosDePoliciaisRepositorio>();
            services.AddScoped<IPolicialRepositorio, PolicialRepositorio>();
            services.AddScoped<IArmaRepositorio, ArmaRepositorio>();
            services.AddScoped<ICentralDeEmergencias, CentralDeEmergencias>();
        }
    }
}