using Biblioteca.Aplicacao.Dtos;
using Biblioteca.Aplicacao.Mapeadores;
using Biblioteca.Dominio.Autores;
using ExpectedObjects;
using Nosbor.FluentBuilder.Br;
using Xunit;

namespace Biblioteca.Testes.Teste_de_Unidade.Aplicacao.Mapeadores
{
    public class MapeadorDeAutorTeste
    {
        private readonly string _nomeDoAutor;
        private readonly int _quantidadeDeLivrosVendidos;

        public MapeadorDeAutorTeste()
        {
            _nomeDoAutor = "J. K. Rowling";
            _quantidadeDeLivrosVendidos = 8000;
        }

        [Fact]
        public void Deve_mapear_um_autor_para_dto()
        {
            var autor = FluentBuilder<Autor>.Novo()
                .Com(a => a.Nome, _nomeDoAutor)
                .Com(a => a.QuantidadeDeLivrosVendidos, _quantidadeDeLivrosVendidos)
                .Criar();
            var autorDtoEsperado = new
            {
                Nome = _nomeDoAutor,
                QuantidadeDeLivrosVendidos = _quantidadeDeLivrosVendidos
            };

            var autorDtoObtido = MapeadorDeAutor.Mapear(autor);

            autorDtoEsperado.ToExpectedObject().ShouldMatch(autorDtoObtido);
        }

        [Fact]
        public void Deve_mapear_um_autor_dto_nulo_quando_autor_for_nulo()
        {
            Autor autorNulo = null;

            var autorObtido = MapeadorDeAutor.Mapear(autorNulo);

            Assert.Null(autorObtido);
        }

        [Fact]
        public void Deve_mapear_um_dto_para_um_autor()
        {
            var autorDto = new AutorDto
            {
                Nome = _nomeDoAutor,
                QuantidadeDeLivrosVendidos = _quantidadeDeLivrosVendidos
            };
            var autorEsperado = new Autor(_nomeDoAutor, _quantidadeDeLivrosVendidos);

            var autorObtido = MapeadorDeAutor.Mapear(autorDto);

            autorEsperado.ToExpectedObject().ShouldMatch(autorObtido);
        }

        [Fact]
        public void Deve_mapear_um_autor__nulo_quando_dto_for_nulo()
        {
            AutorDto autorDtoNulo = null;

            var autorObtido = MapeadorDeAutor.Mapear(autorDtoNulo);

            Assert.Null(autorObtido);
        }
    }
}