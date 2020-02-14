using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Departamento.De.Policia.Infra.Configuracoes.Orm
{
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column("Id");
        }
    }
}