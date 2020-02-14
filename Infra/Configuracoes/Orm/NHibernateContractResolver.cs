﻿using System;
using Newtonsoft.Json.Serialization;

namespace Departamento.De.Policia.Infra.Configuracoes.Orm
{
    public class NHibernateContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            if (typeof(NHibernate.Proxy.INHibernateProxy).IsAssignableFrom(objectType))
                return base.CreateContract(objectType.BaseType);

            return base.CreateContract(objectType);
        }
    }
}