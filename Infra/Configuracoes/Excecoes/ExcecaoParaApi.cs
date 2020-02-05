using System.Collections.Generic;

namespace DepartamentoDePolicia.Infra.Configuracoes.Excecoes
{
    public struct ExcecaoParaApi
    {
        public bool EhExcecaoDeDominio { get; set; }
        public IEnumerable<string> Mensagens { get; set; }
    }
}