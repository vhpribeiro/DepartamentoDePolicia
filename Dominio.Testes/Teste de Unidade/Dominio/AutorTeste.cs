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
    public class AutorTeste
    {
        private readonly string _nomeDoAutor;
        private readonly int _quantidadeDeLivrosVendidos;
        private readonly Livro _livroUm;
        private readonly Livro _livroDois;
        private readonly Autor _autor;

        public AutorTeste()
        {
            _nomeDoAutor = "J. R. R. Tolkien";
            _quantidadeDeLivrosVendidos = 1000;
            _autor = FluentBuilder<Autor>.Novo()
                .Com(a => a.Nome, _nomeDoAutor)
                .Com(a => a.QuantidadeDeLivrosVendidos, _quantidadeDeLivrosVendidos)
                .Criar();
            _livroUm = FluentBuilder<Livro>.Novo()
                .Com(l => l.Autor, _autor)
                .Com(l => l.Titulo, "Senhor dos Anéis: O Retorno do Rei")
                .Com(l => l.AnoDeLancamento, 1996)
                .Com(l => l.Categoria, CategoriaDeLivros.Fantasia)
                .Criar();
            _livroDois = FluentBuilder<Livro>.Novo()
                .Com(l => l.Autor, _autor)
                .Com(l => l.Titulo, "Senhor dos Anéis: O Retorno do Rei")
                .Com(l => l.AnoDeLancamento, 1996)
                .Com(l => l.Categoria, CategoriaDeLivros.Fantasia)
                .Criar();
        }

        [Fact]
        public void Deve_criar_um_autor()
        {
            var autorEsperado = new
            {
                Nome = _nomeDoAutor,
                QuantidadeDeLivrosVendidos = _quantidadeDeLivrosVendidos
            };

            var autorObtido = new Autor(autorEsperado.Nome, autorEsperado.QuantidadeDeLivrosVendidos);

            autorEsperado.ToExpectedObject().ShouldMatch(autorObtido);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Nao_deve_criar_um_autor_com_nome_invalido(string nomeInvalido)
        {
            Action acao = () => new Autor(nomeInvalido, _quantidadeDeLivrosVendidos);

            Assert.Throws<ExcecaoDeDominio<Autor>>(acao).ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10000)]
        public void Nao_deve_criar_um_autor_com_quantidade_de_livros_vendidos_negativa(int quantidadeDeLivrosVendidosInvalida)
        {
            Action acao = () => new Autor(_nomeDoAutor, quantidadeDeLivrosVendidosInvalida);

            Assert.Throws<ExcecaoDeDominio<Autor>>(acao).ComMensagem("Quantidade de livros vendidos inválida");
        }
    }
}