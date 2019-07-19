using System;

namespace Biblioteca.Aplicacao.Mapeadores
{
    public class ExcecaoDeMapeamento : Exception
    {
        public ExcecaoDeMapeamento(string message) : base(message) { }
    }
}