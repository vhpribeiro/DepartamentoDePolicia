using Biblioteca.Dominio._Comum;
using System;
using System.Linq.Expressions;

namespace Biblioteca.Dominio.Livros.Specifications
{
    public class LivroPorTituloSpecification : Specification<Livro>
    {
        private readonly string _tituloDoLivro;

        public LivroPorTituloSpecification(string tituloDoLivro)
        {
            _tituloDoLivro = tituloDoLivro;
        }

        public override Expression<Func<Livro, bool>> EhAtendidaPor()
        {
            if (string.IsNullOrWhiteSpace(_tituloDoLivro))
                return livro => true;

            return livro => livro.Titulo.Contains(_tituloDoLivro);
        }
    }
}