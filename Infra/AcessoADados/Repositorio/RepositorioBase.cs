using System.Collections.Generic;
using System.Linq;
using DepartamentoDePolicia.Dominio._Comum;
using NHibernate;
using NHibernate.Linq;

namespace DepartamentoDePolicia.Infra.AcessoADados.Repositorio
{
    public abstract class RepositorioBase<TEntidade> where TEntidade : Entidade<TEntidade>
    {
        protected ISession Sessao { get; }

        protected RepositorioBase(ISession sessao)
        {
            Sessao = sessao;
        }

        protected IQueryable<TEntidade> Entidades()
        {
            return Sessao.Query<TEntidade>().WithOptions(o => o.SetCacheMode(CacheMode.Normal));
        }

        protected IEnumerable<TEntidade> Enumerar()
        {
            return Sessao.CreateCriteria(typeof(TEntidade)).List<TEntidade>();
        }

        public TEntidade ObterPor(int id)
        {
            return Sessao.Get<TEntidade>(id);
        }

        public IEnumerable<TEntidade> ObterPorSpecification(ISpecification<TEntidade> specification)
        {
            return Entidades().Where(specification.EhAtendidaPor());
        }

        public virtual IEnumerable<TEntidade> ObterTodos()
        {
            return Entidades();
        }

        public virtual void Salvar(TEntidade entidade)
        {
            Sessao.SaveOrUpdate(entidade);
            Sessao.Flush();
        }
    }
}