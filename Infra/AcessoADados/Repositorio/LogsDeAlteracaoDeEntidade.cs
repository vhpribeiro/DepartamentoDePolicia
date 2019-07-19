using Biblioteca.Infra.Log.AlteracaoDeEntidade;
using NHibernate;

namespace Biblioteca.Infra.AcessoADados.Repositorio
{
    public class LogsDeAlteracaoDeEntidade
    {
        public virtual void Salvar(LogDeAlteracaoDeEntidade log, ISession session) =>
            session.Save(log);
    }
}