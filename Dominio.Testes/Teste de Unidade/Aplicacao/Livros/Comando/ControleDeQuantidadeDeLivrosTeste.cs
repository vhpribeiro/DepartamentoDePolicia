using System;
using Biblioteca.Aplicacao.Livros;
using Biblioteca.Aplicacao.Livros.Comando;
using Biblioteca.Aplicacao._Comum;
using Biblioteca.Dominio.Livros;
using ExpectedObjects;
using Moq;
using Nosbor.FluentBuilder.Br;
using Xunit;

namespace Biblioteca.Testes.Teste_de_Unidade.Aplicacao.Livros.Comando
{
    public class ControleDeQuantidadeDeLivrosTeste
    {
        private readonly Mock<ILivroRepositorio> _livroRepositorio;
        private readonly ControleDeQuantidadeDeLivros _controleDeQuantidadeDeLivros;
        private readonly Livro _livro;
        private readonly int _idDoLivro;
        private readonly int _quantidadeSolicitada;

        public ControleDeQuantidadeDeLivrosTeste()
        {
            _idDoLivro = 5;
            _quantidadeSolicitada = 2;
            _livroRepositorio = new Mock<ILivroRepositorio>();
            _controleDeQuantidadeDeLivros = new ControleDeQuantidadeDeLivros(_livroRepositorio.Object);
            _livro = FluentBuilder<Livro>.Novo()
                .Com(l => l.Titulo, "Harry Potter")
                .Com(l => l.AnoDeLancamento, 2000)
                .Com(l => l.QuantidadeDisponivel, 5)
                .Criar();
        }

        [Fact]
        public void Deve_obter_o_livro_pelo_id()
        {
            _livroRepositorio.Setup(lr => lr.ObterPor(_idDoLivro)).Returns(_livro);

            _controleDeQuantidadeDeLivros.Emprestar(_idDoLivro, _quantidadeSolicitada);

            _livroRepositorio.Verify(lr => lr.ObterPor(_idDoLivro));
        }

        [Fact]
        public void Deve_informar_quando_nao_encontrar_o_lviro()
        {
            Livro livro =  null;
            _livroRepositorio.Setup(lr => lr.ObterPor(_idDoLivro)).Returns(livro);
            const string mensagemDeErroEsperada = "Livro não encontrado!";

            Action acao = () => _controleDeQuantidadeDeLivros.Emprestar(_idDoLivro, _quantidadeSolicitada);

            var mensagemDeErroObtida = Assert.Throws<ExcecaoDeAplicacao>(acao).Message;
            Assert.Equal(mensagemDeErroEsperada, mensagemDeErroObtida);
        }

        [Fact]
        public void Deve_salvar_livro_apos_alterar_quantidade_disponivel_do_livro()
        {
            const int quantidadeInicial = 5;
            const int quantidadeSolicitada = 2;
            const int quantidadeEsperada = quantidadeInicial - quantidadeSolicitada;
            var livro = FluentBuilder<Livro>.Novo()
                .Com(l => l.QuantidadeDisponivel, quantidadeInicial)
                .Criar();
            var livroAposAlteracaoDeQuantidade = FluentBuilder<Livro>.Novo()
                .Com(l => l.QuantidadeDisponivel, quantidadeEsperada)
                .Criar();
            _livroRepositorio.Setup(lr => lr.ObterPor(_idDoLivro)).Returns(livro);

            _controleDeQuantidadeDeLivros.Emprestar(_idDoLivro, quantidadeSolicitada);

            _livroRepositorio.Verify(lr => lr.Salvar(It.Is<Livro>(l => livroAposAlteracaoDeQuantidade.ToExpectedObject().Equals(livro))));
        }
    }
}