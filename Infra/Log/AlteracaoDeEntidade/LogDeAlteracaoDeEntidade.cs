using System;
using DepartamentoDePolicia.Infra.Log.AlteracaoDeEntidade;
using Newtonsoft.Json;

namespace Departamento.De.Policia.Infra.Log.AlteracaoDeEntidade
{
    public class LogDeAlteracaoDeEntidade
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new LogContractResolver(),
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        public virtual Guid Id { get; set; }
        public virtual DateTimeOffset Data { get; set; }
        public virtual TipoDeAcaoDoBanco TipoDeAcaoDoBanco { get; set; }
        public virtual string EntidadeId { get; set; }
        public virtual string Entidade { get; set; }
        public virtual string Estado { get; set; }

        protected LogDeAlteracaoDeEntidade() { }

        public LogDeAlteracaoDeEntidade(string entidadeId, object entidade, TipoDeAcaoDoBanco tipoDeAcaoDoBanco)
        {
            Data = DateTimeOffset.Now;
            TipoDeAcaoDoBanco = tipoDeAcaoDoBanco;
            EntidadeId = entidadeId;
            Entidade = entidade.GetType().Name;
            Estado = JsonConvert.SerializeObject(entidade, Settings);
        }
    }
}