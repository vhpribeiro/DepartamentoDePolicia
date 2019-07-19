using System.Collections.Generic;
using System.Linq;
using Biblioteca.Aplicacao.Dtos;
using Biblioteca.Aplicacao.Mapeadores;

namespace Biblioteca.Aplicacao.Livros.Consulta
{
    public class ConsultaDeLivros : IConsultaDeLivros
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public ConsultaDeLivros(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public IEnumerable<LivroDto> ConsultarPorTitulo(string tituloDoLivro)
        {
            var livros = _livroRepositorio.ObterPorTitulo(tituloDoLivro);

            var livrosDtos = livros.Select(MapeadorDeLivro.Mapear);
            return livrosDtos;
        }

        public IEnumerable<LivroDto> ConsultarPorNomeDoAutor(string nomeDoAutor)
        {
            var livros = _livroRepositorio.ObterPorNomeDoAutor(nomeDoAutor);

            var livrosDtos = livros.Select(MapeadorDeLivro.Mapear);
            return livrosDtos;
        }
    }
}