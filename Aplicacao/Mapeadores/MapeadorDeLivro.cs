using Biblioteca.Aplicacao.Dtos;
using Biblioteca.Dominio.Livros;

namespace Biblioteca.Aplicacao.Mapeadores
{
    public static class MapeadorDeLivro
    {
        public static LivroDto Mapear(Livro livro)
        {
            if (livro == null)
                return null;

            return new LivroDto
            {
                Titulo = livro.Titulo,
                QuantidadeDisponivel = livro.QuantidadeDisponivel,
                AnoDeLancamento = livro.AnoDeLancamento,
                Categoria = MapeadorDeCategoriaDeLivro.Mapear(livro.Categoria),
                Autor = MapeadorDeAutor.Mapear(livro.Autor)
            };
        }

        public static Livro Mapear(LivroDto livroDto)
        {
            if (livroDto == null)
                return null;

            var autor = MapeadorDeAutor.Mapear(livroDto.Autor);
            var categoria = MapeadorDeCategoriaDeLivro.Mapear(livroDto.Categoria);

            return new Livro(livroDto.Titulo, livroDto.AnoDeLancamento, autor, categoria, livroDto.QuantidadeDisponivel);
        }
    }
}