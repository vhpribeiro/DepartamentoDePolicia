using System;

namespace Departamento.De.Policia.Aplicacao._Comum
{
    public class ExcecaoDeAplicacao : Exception
    {
        public ExcecaoDeAplicacao(string message) : base(message) { }
    }
}