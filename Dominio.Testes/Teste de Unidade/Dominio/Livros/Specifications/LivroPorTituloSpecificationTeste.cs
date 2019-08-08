using Biblioteca.Dominio.Livros;
using Biblioteca.Dominio.Livros.Specifications;
using Nosbor.FluentBuilder.Br;
using Xunit;

namespace Biblioteca.Testes.Teste_de_Unidade.Dominio.Livros.Specifications
{
    public class LivroPorTituloSpecificationTeste
    {
        [Fact]
        public void Deve_atender_quando_existir_livro_com_nome_informado()
        {
            const string tituloDoLivro = "Harry";
            var livro = FluentBuilder<Livro>.Novo().Com(l => l.Titulo, tituloDoLivro).Criar();
            var specification = new LivroPorTituloSpecification(tituloDoLivro);

            var resultado = specification.EhAtendidaPor().Compile()(livro);

            Assert.True(resultado);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Deve_atender_quando_nao_for_informado_titulo(string tituloInvalido)
        {
            var specification = new LivroPorTituloSpecification(tituloInvalido);

            var resultado = specification.EhAtendidaPor().Compile()(null);

            Assert.True(resultado);
        }
    }
}