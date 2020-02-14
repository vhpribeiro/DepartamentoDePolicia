﻿using System;
using Departamento.De.Policia.Dominio._Comum;

namespace Departamento.De.Policia.Infra.Configuracoes.Excecoes
{
    public static class ExtensoesDeExcecao
    {
        public static ExcecaoParaApi ObterObjetoDoErro(this Exception excecao)
        {
            var excecaoParaApi = new ExcecaoParaApi
            {
                EhExcecaoDeDominio = excecao is ExcecaoDeDominio,
                Mensagens = new[] { excecao.Message }
            };
            if (excecaoParaApi.EhExcecaoDeDominio)
            {
                excecaoParaApi.Mensagens = ((ExcecaoDeDominio)excecao).Mensagens();
            }
            return excecaoParaApi;
        }
    }
}