using System;
using Microsoft.AspNetCore.Mvc.Filters;
using NHibernate;

namespace DepartamentoDePolicia.API.Middlewares
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkFilter : ActionFilterAttribute
    {
        private readonly ISession _sessao;

        public UnitOfWorkFilter(ISession sessao)
        {
            _sessao = sessao;
        }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (!PossuiSessaoNoContexto()) return;
            _sessao.BeginTransaction();
        }

        private bool PossuiSessaoNoContexto()
        {
            return _sessao != null;
        }

        public override void OnResultExecuted(ResultExecutedContext contextoDaAcao)
        {
            if (!PossuiSessaoNoContexto()) return;

            var transacao = _sessao.Transaction;

            if (!TransacaoEhValida(transacao)) return;

            if (contextoDaAcao.Exception == null)
                transacao.Commit();
        }

        public override void OnActionExecuted(ActionExecutedContext contextoDaAcao)
        {
            if (!PossuiSessaoNoContexto()) return;

            var transacao = _sessao.Transaction;

            if (!TransacaoEhValida(transacao)) return;

            if (contextoDaAcao.Exception == null)
                transacao.Commit();
        }

        private static bool TransacaoEhValida(ITransaction transacao)
        {
            return transacao != null && transacao.IsActive;
        }
    }
}