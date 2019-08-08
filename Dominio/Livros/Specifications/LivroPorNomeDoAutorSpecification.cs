using System;
using System.Linq.Expressions;
using Biblioteca.Dominio._Comum;

namespace Biblioteca.Dominio.Livros.Specifications
{
    public class LivroPorNomeDoAutorSpecification : Specification<Livro>
    {
        private readonly string _nomeDoAutor;

        public LivroPorNomeDoAutorSpecification(string nomeDoAutor)
        {
            _nomeDoAutor = nomeDoAutor;
        }

        public override Expression<Func<Livro, bool>> EhAtendidaPor()
        {
            if (string.IsNullOrWhiteSpace(_nomeDoAutor))
                return livro => true;

            return livro => livro.Autor.Nome.Contains(_nomeDoAutor);
        }
    }
}