using Departamento.De.Policia.Infra.Log.AlteracaoDeEntidade;
using DepartamentoDePolicia.Infra.Log.AlteracaoDeEntidade;
using NHibernate;

namespace Departamento.De.Policia.Infra.AcessoADados.Repositorio
{
    public class LogsDeAlteracaoDeEntidade
    {
        public virtual void Salvar(LogDeAlteracaoDeEntidade log, ISession session) =>
            session.Save(log);
    }
}