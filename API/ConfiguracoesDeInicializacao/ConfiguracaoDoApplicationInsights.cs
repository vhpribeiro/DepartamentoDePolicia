using System;
using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.SnapshotCollector;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Biblioteca.API.ConfiguracoesDeInicializacao
{
    public class ConfiguracaoDoApplicationInsights
    {
        public static void Configurar(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SnapshotCollectorConfiguration>(configuration.GetSection(nameof(SnapshotCollectorConfiguration)));
            services.AddSingleton<ITelemetryProcessorFactory>(serviceProvider => new SnapshotCollectorTelemetryProcessorFactory(serviceProvider));
        }

        private class SnapshotCollectorTelemetryProcessorFactory : ITelemetryProcessorFactory
        {
            private readonly IServiceProvider _serviceProvider;

            public SnapshotCollectorTelemetryProcessorFactory(IServiceProvider serviceProvider) =>
                _serviceProvider = serviceProvider;

            public ITelemetryProcessor Create(ITelemetryProcessor next)
            {
                var snapshotConfigurationOptions = _serviceProvider.GetService<IOptions<SnapshotCollectorConfiguration>>();
                return new SnapshotCollectorTelemetryProcessor(next, configuration: snapshotConfigurationOptions.Value);
            }
        }
    }
}