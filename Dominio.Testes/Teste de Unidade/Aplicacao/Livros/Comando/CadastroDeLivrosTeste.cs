using System;
using System.Collections.Generic;
using Biblioteca.Aplicacao.Dtos;
using Biblioteca.Aplicacao.Livros;
using Biblioteca.Aplicacao.Livros.Comando;
using Biblioteca.Aplicacao._Comum;
using Biblioteca.Dominio.Livros;
using Moq;
using Nosbor.FluentBuilder.Br;
using Xunit;

namespace Biblioteca.Testes.Teste_de_Unidade.Aplicacao.Livros.Comando
{
    public class CadastroDeLivrosTeste
    {
        private readonly LivroDto _livroDto;
        private readonly Mock<ILivroRepositorio> _livroRepositorio;
        private readonly CadastroDeLivros _cadastroDeLivro;
        private readonly AutorDto _autorDto;
        private readonly CategoriaDeLivrosDto _categoriaDeLivrosDto;

        public CadastroDeLivrosTeste()
        {
            _livroRepositorio = new Mock<ILivroRepositorio>();
            _categoriaDeLivrosDto = CategoriaDeLivrosDto.Fantasia;
            _autorDto = new AutorDto
            {
                Nome = "Rick Riordan",
                QuantidadeDeLivrosVendidos = 90000
            };
            _livroDto = new LivroDto
            {
                Titulo = "Percy Jackson, o ladrão de Raios",
                AnoDeLancamento = 2008,
                Autor = _autorDto,
                Categoria = _categoriaDeLivrosDto,
                QuantidadeDisponivel = 5
            };
            _cadastroDeLivro = new CadastroDeLivros(_livroRepositorio.Object);
            _livroRepositorio.Setup(lr => lr.ObterPorTitulo(_livroDto.Titulo)).Returns((IList<Livro>)null);
        }

        [Fact]
        public void Deve_tentar_obter_o_livro_do_repositorio()
        {
            _cadastroDeLivro.Cadastrar(_livroDto);

            _livroRepositorio.Verify(lr => lr.ObterPorTitulo(_livroDto.Titulo));
        }

        [Fact]
        public void Nao_deve_adicionar_um_livro_que_já_foi_cadastrado()
        {
            const string mensagemEsperada = "Já existe um livro cadastrado com este nome!";
            var livro = FluentBuilder<Livro>.Novo().Criar();
            var livros = new[] { livro };
            _livroRepositorio.Setup(lr => lr.ObterPorTitulo(_livroDto.Titulo)).Returns(livros);

            Action acao = () => _cadastroDeLivro.Cadastrar(_livroDto);

            var mensagemObtida = Assert.Throws<ExcecaoDeAplicacao>(acao).Message;
            Assert.Equal(mensagemEsperada, mensagemObtida);
        }

        [Fact]
        public void Deve_cadastrar_um_novo_livro()
        {
            _cadastroDeLivro.Cadastrar(_livroDto);

            _livroRepositorio.Verify(lr => lr.Salvar(It.Is<Livro>(l => l.Titulo == _livroDto.Titulo &&
                 l.AnoDeLancamento == _livroDto.AnoDeLancamento && l.QuantidadeDisponivel == _livroDto.QuantidadeDisponivel
                 && l.Autor.Nome == _autorDto.Nome)));
        }
    }
}