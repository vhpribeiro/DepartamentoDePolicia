using System.Linq;
using Biblioteca.Aplicacao.Dtos;
using Biblioteca.Aplicacao.Livros;
using Biblioteca.Aplicacao.Livros.Consulta;
using Biblioteca.Aplicacao.Mapeadores;
using Biblioteca.Dominio.Autores;
using Biblioteca.Dominio.Livros;
using Biblioteca.Dominio.Livros.Specifications;
using Biblioteca.Dominio._Comum;
using ExpectedObjects;
using Moq;
using Nosbor.FluentBuilder.Br;
using Xunit;

namespace Biblioteca.Testes.Teste_de_Unidade.Aplicacao.Livros.Consulta
{
    public class ConsultaDeLivrosTeste
    {
        private readonly string _tituloDoLivro;
        private readonly Livro[] _livros;
        private readonly Mock<ILivroRepositorio> _livroRepositorio;
        private readonly ConsultaDeLivros _consultaDeLivros;
        private readonly string _nomeDoAutor;
        private readonly int _pagina;
        private readonly int _quantidadeDeItensPorPagina;

        public ConsultaDeLivrosTeste()
        {
            _tituloDoLivro = "Harry Potter";
            _nomeDoAutor = "J. K. Rowling";
            _pagina = 1;
            _quantidadeDeItensPorPagina = 20;
            const CategoriaDeLivros categoria = CategoriaDeLivros.Fantasia;
            var autor = FluentBuilder<Autor>.Novo()
                .Com(a => a.Nome, _nomeDoAutor)
                .Com(a => a.QuantidadeDeLivrosVendidos, 800000)
                .Criar();
            var livroUm = FluentBuilder<Livro>.Novo()
                .Com(l => l.Titulo, "Harry Potter e o Prisioneiro de Askaban")
                .Com(l => l.Categoria, categoria)
                .Com(l => l.Autor, autor)
                .Criar();
            var livroDois = FluentBuilder<Livro>.Novo()
                .Com(l => l.Titulo, "Harry Potter e a Ordem da Fênix")
                .Com(l => l.Categoria, categoria)
                .Com(l => l.Autor, autor)
                .Criar();
            _livros = new[] { livroUm, livroDois };
            _livroRepositorio = new Mock<ILivroRepositorio>();
            _consultaDeLivros = new ConsultaDeLivros(_livroRepositorio.Object);
        }

        [Fact]
        public void Deve_obter_todos_os_livros_paginados_com_os_filtros_informados()
        {
            _livroRepositorio.Setup(lr => lr.ObterPor(It.IsAny<ISpecification<Livro>>()))
                .Returns(_livros);
            var livrosEsperados = _livros.Select(MapeadorDeLivro.Mapear);
            var listaDeLivrosPaginadosEsperada = new ListaPaginada<LivroDto>(livrosEsperados,
                _quantidadeDeItensPorPagina, _pagina);

            var listaDeLivrosPaginadosObtida = _consultaDeLivros.ConsultarPorFiltros(_tituloDoLivro, _nomeDoAutor, 
                _pagina, _quantidadeDeItensPorPagina);

            listaDeLivrosPaginadosEsperada.ToExpectedObject().ShouldMatch(listaDeLivrosPaginadosObtida);
        }

        [Fact]
        public void Deve_obter_todos_os_livros_por_specification()
        {
            var specificationPorTitulo = new LivroPorTituloSpecification(_tituloDoLivro);
            var specificationPorNomeDoAutor = new LivroPorNomeDoAutorSpecification(_nomeDoAutor);
            var specificationEsperada = specificationPorTitulo.E(specificationPorNomeDoAutor);
            _livroRepositorio.Setup(lr => lr.ObterPor(It.IsAny<ISpecification<Livro>>())).Returns(_livros);

            _consultaDeLivros.ConsultarPorFiltros(_tituloDoLivro, _nomeDoAutor, _pagina, _quantidadeDeItensPorPagina);

            _livroRepositorio.Verify(lr => lr.ObterPor(It.Is<ISpecification<Livro>>(s => s.ToExpectedObject()
                .Matches(specificationEsperada))));
        }
    }
}