using Departamento.De.Policia.Dominio._Comum;
using FluentNHibernate.Mapping;

namespace Departamento.De.Policia.Infra.Mapeamento
{
    public class MapBase<TEntidade> : ClassMap<TEntidade> where TEntidade : Entidade<TEntidade>
    {
        public MapBase()
        {
            Id(entidade => entidade.Id);
        }
    }
}