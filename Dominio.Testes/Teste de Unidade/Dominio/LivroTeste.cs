using System;
using Biblioteca.Dominio.Autores;
using Biblioteca.Dominio.Livros;
using Biblioteca.Dominio._Comum;
using Biblioteca.Testes._Helper;
using ExpectedObjects;
using Nosbor.FluentBuilder.Br;
using Xunit;

namespace Biblioteca.Testes.Teste_de_Unidade.Dominio
{
    public class LivroTeste
    {
        private readonly Autor _autor;
        private readonly CategoriaDeLivros _categoria;
        private readonly int _quantidadeDisponivel;
        private readonly int _anoDeLancamento;
        private readonly string _tituloDoLivro;

        public LivroTeste()
        {
            _tituloDoLivro = "Harry Potter e o Prisioneiro de Askaban";
            _anoDeLancamento = 2003;
            _quantidadeDisponivel = 5;
            _categoria = CategoriaDeLivros.Fantasia;
            _autor = FluentBuilder<Autor>.Novo().Criar();
        }

        [Fact]
        public void Deve_criar_um_livro()
        {
            var livroEsperado = new
            {
                Titulo = _tituloDoLivro,
                AnoDeLancamento = _anoDeLancamento,
                Autor = _autor,
                Categoria = _categoria,
                QuantidadeDisponivel = _quantidadeDisponivel
            };

            var livroObtido = new Livro(_tituloDoLivro, _anoDeLancamento, _autor, _categoria, _quantidadeDisponivel);

            livroEsperado.ToExpectedObject().ShouldMatch(livroObtido);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Nao_deve_criar_com_titulo_invalido(string tituloInvalido)
        {
            Action acao = () => new Livro(tituloInvalido, _anoDeLancamento, _autor, _categoria, _quantidadeDisponivel);

            Assert.Throws<ExcecaoDeDominio<Livro>>(acao).ComMensagem("Título inválido");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-1000)]
        public void Nao_deve_criar_com_quantidade_invalida(int quantidadeDisponivelInvalida)
        {
            Action acao = () => new Livro(_tituloDoLivro, _anoDeLancamento, _autor, _categoria, quantidadeDisponivelInvalida);

            Assert.Throws<ExcecaoDeDominio<Livro>>(acao).ComMensagem("Quantidade disponível inválida");
        }

        [Theory]
        [InlineData(5, 10)]
        [InlineData(-5, 0)]
        public void Deve_alterar_a_quantidade_disponível(int quantidadeQueDeveSerAlterada, int quantidadeEsperada)
        {
            var livro = FluentBuilder<Livro>.Novo()
                .Com(l => l.QuantidadeDisponivel, _quantidadeDisponivel)
                .Criar();

            livro.AlterarQuantidadeDisponivel(quantidadeQueDeveSerAlterada);

            Assert.Equal(quantidadeEsperada, livro.QuantidadeDisponivel);
        }

        [Theory]
        [InlineData(-20)]
        [InlineData(-60)]
        public void Nao_deve_permitir_alterar_quantidade_disponivel_quando_nova_quantidade_for_invalida(int quantidadeQueDeveSerAlterada)
        {
            var livro = FluentBuilder<Livro>.Novo()
                .Com(l => l.QuantidadeDisponivel, _quantidadeDisponivel)
                .Criar();

            Action acao = () => livro.AlterarQuantidadeDisponivel(quantidadeQueDeveSerAlterada);

            Assert.Throws<ExcecaoDeDominio<Livro>>(acao).ComMensagem("Nova quantidade disponível é inválida");
        }

        [Fact]
        public void Deve_pegar_emprestado()
        {
            const int quantidadeDeLivrosParaSeremEmprestados = 268;
            const int quantidadeInicial = 500;
            const int quantidadeEsperada = quantidadeInicial - quantidadeDeLivrosParaSeremEmprestados;
            var livro = FluentBuilder<Livro>.Novo()
                .Com(l => l.QuantidadeDisponivel, quantidadeInicial)
                .Criar();

            livro.PegarEmprestado(quantidadeDeLivrosParaSeremEmprestados);

            Assert.Equal(quantidadeEsperada, livro.QuantidadeDisponivel);
        }

        [Theory]
        [InlineData(1, 1000)]
        [InlineData(1, 2)]
        public void Nao_deve_pegar_quantidade_invalida_de_livros_emprestados(int quantidadeInicial, int quantidadeInvalida)
        {
            var livro = FluentBuilder<Livro>.Novo()
                .Com(l => l.QuantidadeDisponivel, quantidadeInicial)
                .Criar();

            Action acao = () => livro.PegarEmprestado(quantidadeInvalida);

            Assert.Throws<ExcecaoDeDominio<Livro>>(acao).ComMensagem("Não há tantos livros assim! Diminua a quantidade por favor");
        }
    }
}