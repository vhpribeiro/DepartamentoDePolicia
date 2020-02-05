using DepartamentoDePolicia.Infra.Mapeamento;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;

namespace DepartamentoDePolicia.Infra.Configuracoes.Orm
{
    public class ConfiguracoesNHibernate
    {
        private const string TempoDeExpiracaoDoCache = "1800";
        private static volatile ISessionFactory _sessionFactory;
        private static readonly object SyncRoot = new object();

        public static ISessionFactory ConfigurarSessionFactory(string connectionString, bool exibirSql = false, bool criarBanco = false)
        {
            if (_sessionFactory != null)
                return _sessionFactory;

            lock (SyncRoot)
            {
                if (_sessionFactory == null)
                    _sessionFactory = CreateSessionFactory(connectionString, exibirSql, criarBanco);
            }

            return _sessionFactory;
        }

        private static ISessionFactory CreateSessionFactory(string connectionString, bool exibirSql, bool criarBanco)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .CurrentSessionContext<WebSessionContext>()
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<LogDeAlteracaoDeEntidadeMap>()
                    .Conventions.Add<PrimaryKeyConvention>()
                    //.Conventions.Add<EnumConvention>()
                    .Conventions.Add<CustomForeignKeyConvention>())
                //.ExposeConfiguration(config =>
                //{
                //    config.SetProperty(Environment.CacheDefaultExpiration, TempoDeExpiracaoDoCache);
                //    new SchemaExport(config).Create(exibirSql, criarBanco);
                //})
                .BuildSessionFactory();
        }
    }
}