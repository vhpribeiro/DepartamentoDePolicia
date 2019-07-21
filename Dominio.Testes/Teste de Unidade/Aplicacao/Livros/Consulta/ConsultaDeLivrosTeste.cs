using System.Linq;
using Biblioteca.Aplicacao.Livros;
using Biblioteca.Aplicacao.Livros.Consulta;
using Biblioteca.Aplicacao.Mapeadores;
using Biblioteca.Dominio.Autores;
using Biblioteca.Dominio.Livros;
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

        public ConsultaDeLivrosTeste()
        {
            _tituloDoLivro = "Harry Potter";
            _nomeDoAutor = "J. K. Rowling";
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
        public void Deve_obter_os_livros_do_repositorio_por_titulo()
        {
            _livroRepositorio.Setup(lr => lr.ObterPorTitulo(_tituloDoLivro)).Returns(_livros);

            _consultaDeLivros.ConsultarPorTitulo(_tituloDoLivro);

            _livroRepositorio.Verify(lr => lr.ObterPorTitulo(_tituloDoLivro));
        }

        [Fact]
        public void Deve_consultar_os_livros_pelo_titulo()
        {
            _livroRepositorio.Setup(lr => lr.ObterPorTitulo(_tituloDoLivro)).Returns(_livros);
            var livrosEsperados = _livros.Select(MapeadorDeLivro.Mapear);

            var livrosObtidos = _consultaDeLivros.ConsultarPorTitulo(_tituloDoLivro);

            livrosEsperados.ToExpectedObject().ShouldMatch(livrosObtidos);
        }

        [Fact]
        public void Deve_obter_os_livros_do_repositorio_por_nome_do_autor()
        {
            _livroRepositorio.Setup(lr => lr.ObterPorNomeDoAutor(_nomeDoAutor)).Returns(_livros);

            _consultaDeLivros.ConsultarPorNomeDoAutor(_nomeDoAutor);

            _livroRepositorio.Verify(lr => lr.ObterPorNomeDoAutor(_nomeDoAutor));
        }

        [Fact]
        public void Deve_obter_todos_os_livros_do_autor_informado()
        {
            _livroRepositorio.Setup(lr => lr.ObterPorNomeDoAutor(_nomeDoAutor)).Returns(_livros);
            var livrosEsperados = _livros.Select(MapeadorDeLivro.Mapear);

            var livrosObtidos = _consultaDeLivros.ConsultarPorNomeDoAutor(_nomeDoAutor);

            livrosEsperados.ToExpectedObject().ShouldMatch(livrosObtidos);
        }
    }
}