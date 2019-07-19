using System.Collections.Generic;
using Biblioteca.Dominio.Livros;
using Biblioteca.Dominio._Comum;

namespace Biblioteca.Aplicacao.Livros
{
    public interface ILivroRepositorio : IRepositorioBase<Livro>
    {
        IList<Livro> ObterPorTitulo(string titulo);
        IList<Livro> ObterPorNomeDoAutor(string nomeDoAutor);
    }
}