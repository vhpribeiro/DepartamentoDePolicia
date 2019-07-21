using System;
using Newtonsoft.Json.Serialization;

namespace Biblioteca.Infra.Log.AlteracaoDeEntidade
{
    public class LogContractResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType) =>
            base.CreateContract(typeof(NHibernate.Proxy.INHibernateProxy).IsAssignableFrom(objectType) ?
                objectType.BaseType : objectType);
    }
}