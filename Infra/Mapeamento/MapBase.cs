using Biblioteca.Dominio._Comum;
using FluentNHibernate.Mapping;

namespace Biblioteca.Infra.Mapeamento
{
    public class MapBase<TEntidade> : ClassMap<TEntidade> where TEntidade : Entidade<TEntidade>
    {
        public MapBase()
        {
            Id(entidade => entidade.Id);
        }
    }
}