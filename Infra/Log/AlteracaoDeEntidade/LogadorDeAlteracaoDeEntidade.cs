using System;
using System.Collections.Generic;
using System.Linq;
using DepartamentoDePolicia.Infra.AcessoADados.Repositorio;
using NHibernate;

namespace DepartamentoDePolicia.Infra.Log.AlteracaoDeEntidade
{
    public class LogadorDeAlteracaoDeEntidade
    {
        private readonly LogsDeAlteracaoDeEntidade _logs;

        private List<Tuple<object, TipoDeAcaoDoBanco>> Logs { get; } = new List<Tuple<object, TipoDeAcaoDoBanco>>();

        public LogadorDeAlteracaoDeEntidade(LogsDeAlteracaoDeEntidade logs)
        {
            _logs = logs;
        }

        public virtual void AdicionarEntidade(object entity, TipoDeAcaoDoBanco tipoDeAcaoDoBanco)
        {
            if (entity is LogDeAlteracaoDeEntidade)
                return;

            Logs.Add(new Tuple<object, TipoDeAcaoDoBanco>(entity, tipoDeAcaoDoBanco));
        }

        public virtual void Logar(ISession session)
        {
            if (!Logs.Any()) return;

            Logs.ForEach(log =>
            {
                var id = log.Item1.GetType().GetProperty("Id").GetValue(log.Item1);

                _logs.Salvar(new LogDeAlteracaoDeEntidade(id.ToString(), log.Item1, log.Item2), session);
            });

            Logs.Clear();
            session.Flush();
        }
    }
}