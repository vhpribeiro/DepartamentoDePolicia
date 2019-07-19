using System;

namespace Biblioteca.Aplicacao._Comum
{
    public class ExcecaoDeAplicacao : Exception
    {
        public ExcecaoDeAplicacao(string message) : base(message) { }
    }
}