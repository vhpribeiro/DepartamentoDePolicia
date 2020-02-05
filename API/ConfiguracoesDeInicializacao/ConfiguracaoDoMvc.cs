using DepartamentoDePolicia.API.Middlewares;
using DepartamentoDePolicia.Infra.Configuracoes.Orm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DepartamentoDePolicia.API.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDoMvc
    {
        public static void Configurar(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("pt-BR");
            });

            services
                .AddMvc(configuracaoDoMvc =>
                {
                    var politicaDeAutorizacao = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                    configuracaoDoMvc.Filters.Add(new AuthorizeFilter(politicaDeAutorizacao));
                    configuracaoDoMvc.Filters.AddService(typeof(UnitOfWorkFilter));
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.ContractResolver = new NHibernateContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.DateFormatString = "dd/MM/yyyy";
                });
        }
    }
}