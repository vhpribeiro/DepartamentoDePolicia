using Biblioteca.Dominio.Autores;
using Biblioteca.Dominio.Livros;
using Biblioteca.Dominio.Livros.Specifications;
using Nosbor.FluentBuilder.Br;
using Xunit;

namespace Biblioteca.Testes.Teste_de_Unidade.Dominio.Livros.Specifications
{
    public class LivroPorNomeDoAutorSpecificationTeste
    {
        [Fact]
        public void Deve_atender_quando_existir_livro_com_nome_do_autor_informado()
        {
            const string nomeDoAutor = "J.K. Rowling";
            var autor = FluentBuilder<Autor>.Novo()
                .Com(a => a.Nome, nomeDoAutor).Criar();
            var livro = FluentBuilder<Livro>.Novo()
                .Com(l => l.Autor, autor).Criar();
            var specification = new LivroPorNomeDoAutorSpecification(nomeDoAutor);

            var resultado = specification.EhAtendidaPor().Compile()(livro);

            Assert.True(resultado);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Deve_atender_quando_for_informado_nome_invalido(string nomeInvalido)
        {
            var specification = new LivroPorNomeDoAutorSpecification(nomeInvalido);

            var resultado = specification.EhAtendidaPor().Compile()(null);

            Assert.True(resultado);
        }
    }
}