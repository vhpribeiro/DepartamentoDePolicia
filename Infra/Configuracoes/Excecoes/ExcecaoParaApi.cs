using System.Collections.Generic;

namespace Biblioteca.Infra.Configuracoes.Excecoes
{
    public struct ExcecaoParaApi
    {
        public bool EhExcecaoDeDominio { get; set; }
        public IEnumerable<string> Mensagens { get; set; }
    }
}