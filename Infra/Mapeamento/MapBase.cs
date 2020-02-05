using DepartamentoDePolicia.Dominio._Comum;
using FluentNHibernate.Mapping;

namespace DepartamentoDePolicia.Infra.Mapeamento
{
    public class MapBase<TEntidade> : ClassMap<TEntidade> where TEntidade : Entidade<TEntidade>
    {
        public MapBase()
        {
            Id(entidade => entidade.Id);
        }
    }
}