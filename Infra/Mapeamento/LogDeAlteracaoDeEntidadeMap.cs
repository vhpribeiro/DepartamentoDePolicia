using DepartamentoDePolicia.Infra.Log.AlteracaoDeEntidade;
using FluentNHibernate.Mapping;

namespace DepartamentoDePolicia.Infra.Mapeamento
{
    public class LogDeAlteracaoDeEntidadeMap : ClassMap<LogDeAlteracaoDeEntidade>
    {
        public LogDeAlteracaoDeEntidadeMap()
        {
            Table("LogDeAlteracaoDeEntidade");
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Data);
            Map(x => x.TipoDeAcaoDoBanco).CustomType<int>();
            Map(x => x.EntidadeId);
            Map(x => x.Entidade);
            Map(x => x.Estado).CustomType("StringClob").CustomSqlType("nvarchar(max)");
        }
    }
}