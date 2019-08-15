using Biblioteca.Aplicacao.Dtos;
using Biblioteca.Aplicacao.Mapeadores;
using Biblioteca.Dominio._Comum;
using Biblioteca.Dominio.Livros.Specifications;
using System.Linq;

namespace Biblioteca.Aplicacao.Livros.Consulta
{
    public class ConsultaDeLivros : IConsultaDeLivros
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public ConsultaDeLivros(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public ListaPaginada<LivroDto> ConsultarPorFiltros(string titulo, string nomeDoAutor,
            int pagina, int quantidadeDeItensPorPagina)
        {
            var specificationPorTituloDoLivro = new LivroPorTituloSpecification(titulo);
            var specificationPorNomeDoAutorDoLivro = new LivroPorNomeDoAutorSpecification(nomeDoAutor);

            var livros =
                _livroRepositorio.ObterPor(specificationPorTituloDoLivro.E(specificationPorNomeDoAutorDoLivro));

            var livrosDtos = livros.Select(MapeadorDeLivro.Mapear);
            var listaPaginada = new ListaPaginada<LivroDto>(livrosDtos, quantidadeDeItensPorPagina, pagina);
            return listaPaginada;
        }
    }
}