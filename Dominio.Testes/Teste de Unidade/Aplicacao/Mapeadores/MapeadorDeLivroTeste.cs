using Biblioteca.Aplicacao.Dtos;
using Biblioteca.Aplicacao.Mapeadores;
using Biblioteca.Dominio.Autores;
using Biblioteca.Dominio.Livros;
using ExpectedObjects;
using Nosbor.FluentBuilder.Br;
using Xunit;

namespace Biblioteca.Testes.Teste_de_Unidade.Aplicacao.Mapeadores
{
    public class MapeadorDeLivroTeste
    {
        private readonly CategoriaDeLivros _categoria;
        private readonly int _anoDeLancamento;
        private readonly int _quantidadeDisponivel;
        private readonly string _nomeDoLivro;
        private readonly int _quantidadeDeLivrosVendidos;
        private readonly string _nomeDoAutor;

        public MapeadorDeLivroTeste()
        {
            _nomeDoAutor = "J. K. Rowling";
            _quantidadeDeLivrosVendidos = 7000;
            _nomeDoLivro = "Harry Potter e o Cálice de Fogo";
            _quantidadeDisponivel = 50;
            _anoDeLancamento = 2006;
            _categoria = CategoriaDeLivros.Fantasia;
        }

        [Fact]
        public void Deve_mapear_um_livro_para_dto()
        {
            var autor = FluentBuilder<Autor>.Novo()
                .Com(a => a.Nome, _nomeDoAutor)
                .Com(a => a.QuantidadeDeLivrosVendidos, _quantidadeDeLivrosVendidos)
                .Criar();
            var livro = FluentBuilder<Livro>.Novo()
                .Com(l => l.Titulo, _nomeDoLivro)
                .Com(l => l.QuantidadeDisponivel, _quantidadeDisponivel)
                .Com(l => l.AnoDeLancamento, _anoDeLancamento)
                .Com(l => l.Categoria, _categoria)
                .Com(l => l.Autor, autor)
                .Criar();
            var livroMapeadoEsperado = new
            {
                Titulo = _nomeDoLivro,
                QuantidadeDisponivel = _quantidadeDisponivel,
                AnoDeLancamento = _anoDeLancamento,
                Categoria = MapeadorDeCategoriaDeLivro.Mapear(CategoriaDeLivros.Fantasia),
                Autor = MapeadorDeAutor.Mapear(autor)
            };

            var livroMapeadoObtido = MapeadorDeLivro.Mapear(livro);

            livroMapeadoEsperado.ToExpectedObject().ShouldMatch(livroMapeadoObtido);
        }

        [Fact]
        public void Deve_mapear_um_livro_dto_nulo_quando_livro_for_nulo()
        {
            Livro livroNulo = null;

            var livroDtoMapeado = MapeadorDeLivro.Mapear(livroNulo);

            Assert.Null(livroDtoMapeado);
        }

        [Fact]
        public void Deve_mapear_um_dto_para_um_livro()
        {
            var autorDto = new AutorDto
            {
                Nome = _nomeDoAutor,
                QuantidadeDeLivrosVendidos = _quantidadeDeLivrosVendidos
            };
            var livroDto = new LivroDto
            {
                Titulo = _nomeDoLivro,
                AnoDeLancamento = _anoDeLancamento,
                Autor = autorDto,
                Categoria = CategoriaDeLivrosDto.Fantasia,
                QuantidadeDisponivel = _quantidadeDisponivel
            };
            var categoriaDeLivros = MapeadorDeCategoriaDeLivro.Mapear(CategoriaDeLivrosDto.Fantasia);
            var autor = MapeadorDeAutor.Mapear(autorDto);
            var livroEsperado = new Livro(_nomeDoLivro, _anoDeLancamento,
                autor, categoriaDeLivros, _quantidadeDisponivel);

            var livroObtido = MapeadorDeLivro.Mapear(livroDto);

            livroEsperado.ToExpectedObject().ShouldMatch(livroObtido);
        }

        [Fact]
        public void Deve_mapear_um_livro__nulo_quando_dto_for_nulo()
        {
            LivroDto livroDtoNulo = null;

            var livroMapeado = MapeadorDeLivro.Mapear(livroDtoNulo);

            Assert.Null(livroMapeado);
        }
    }
}