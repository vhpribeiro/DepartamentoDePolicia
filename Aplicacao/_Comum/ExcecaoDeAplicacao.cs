using System;

namespace DepartamentoDePolicia.Aplicacao._Comum
{
    public class ExcecaoDeAplicacao : Exception
    {
        public ExcecaoDeAplicacao(string message) : base(message) { }
    }
}