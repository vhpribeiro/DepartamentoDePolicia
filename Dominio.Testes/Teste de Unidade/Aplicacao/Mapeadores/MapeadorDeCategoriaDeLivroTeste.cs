using Biblioteca.Aplicacao.Dtos;
using Biblioteca.Aplicacao.Mapeadores;
using Biblioteca.Dominio.Livros;
using Xunit;

namespace Biblioteca.Testes.Teste_de_Unidade.Aplicacao.Mapeadores
{
    public class MapeadorDeCategoriaDeLivroTeste
    {
        [Theory]
        [InlineData(CategoriaDeLivros.Fantasia, CategoriaDeLivrosDto.Fantasia)]
        [InlineData(CategoriaDeLivros.Aventura, CategoriaDeLivrosDto.Aventura)]
        [InlineData(CategoriaDeLivros.FiccaoCientifica, CategoriaDeLivrosDto.FiccaoCientifica)]
        [InlineData(CategoriaDeLivros.Romance, CategoriaDeLivrosDto.Romance)]
        public void Deve_mapear_uma_categoria_de_livro_para_dto(CategoriaDeLivros categoriaParaMapear,
            CategoriaDeLivrosDto categoriaDtoEsperada)
        {
            var categoriaDtoObtida = MapeadorDeCategoriaDeLivro.Mapear(categoriaParaMapear);

            Assert.Equal(categoriaDtoEsperada, categoriaDtoObtida);
        }

        [Theory]
        [InlineData(CategoriaDeLivrosDto.Fantasia, CategoriaDeLivros.Fantasia)]
        [InlineData(CategoriaDeLivrosDto.Aventura, CategoriaDeLivros.Aventura)]
        [InlineData(CategoriaDeLivrosDto.FiccaoCientifica, CategoriaDeLivros.FiccaoCientifica)]
        [InlineData(CategoriaDeLivrosDto.Romance, CategoriaDeLivros.Romance)]
        public void Deve_mapear_um_dto_para_uma_categoria_de_livro(CategoriaDeLivrosDto categoriaParaMapear,
            CategoriaDeLivros categoriaDtoEsperada)
        {
            var categoriaObtida = MapeadorDeCategoriaDeLivro.Mapear(categoriaParaMapear);

            Assert.Equal(categoriaDtoEsperada, categoriaObtida);
        }
    }
}