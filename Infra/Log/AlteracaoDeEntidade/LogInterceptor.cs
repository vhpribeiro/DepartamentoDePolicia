using System.Collections;
using NHibernate;

namespace DepartamentoDePolicia.Infra.Log.AlteracaoDeEntidade
{
    public class LogInterceptor : EmptyInterceptor
    {
        private readonly LogadorDeAlteracaoDeEntidade _logadorDeAlteracaoDeEntidade;
        private ISession session;

        public LogInterceptor(LogadorDeAlteracaoDeEntidade logadorDeAlteracaoDeEntidade)
        {
            _logadorDeAlteracaoDeEntidade = logadorDeAlteracaoDeEntidade;
        }

        public override void SetSession(ISession session)
        {
            base.SetSession(session);
            this.session = session;
        }

        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames,
            NHibernate.Type.IType[] types)
        {
            _logadorDeAlteracaoDeEntidade.AdicionarEntidade(entity, TipoDeAcaoDoBanco.Create);
            return base.OnSave(entity, id, state, propertyNames, types);
        }

        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState,
            string[] propertyNames, NHibernate.Type.IType[] types)
        {
            _logadorDeAlteracaoDeEntidade.AdicionarEntidade(entity, TipoDeAcaoDoBanco.Update);
            return base.OnFlushDirty(entity, id, currentState, previousState, propertyNames, types);
        }

        public override void OnDelete(object entity, object id, object[] state, string[] propertyNames,
            NHibernate.Type.IType[] types)
        {
            _logadorDeAlteracaoDeEntidade.AdicionarEntidade(entity, TipoDeAcaoDoBanco.Delete);
            base.OnDelete(entity, id, state, propertyNames, types);
        }

        public override void PostFlush(ICollection entities)
        {
            _logadorDeAlteracaoDeEntidade.Logar(session);
            base.PostFlush(entities);
        }
    }
}