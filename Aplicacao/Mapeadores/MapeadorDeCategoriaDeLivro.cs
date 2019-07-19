using System.Collections.Generic;
using Biblioteca.Aplicacao.Dtos;
using Biblioteca.Dominio.Livros;

namespace Biblioteca.Aplicacao.Mapeadores
{
    public static class MapeadorDeCategoriaDeLivro
    {
        private static readonly Dictionary<CategoriaDeLivros, CategoriaDeLivrosDto> MapaDeCategoriasDeLivrosDto =
            new Dictionary<CategoriaDeLivros, CategoriaDeLivrosDto>()
            {
                {CategoriaDeLivros.Fantasia, CategoriaDeLivrosDto.Fantasia },
                {CategoriaDeLivros.Aventura, CategoriaDeLivrosDto.Aventura },
                {CategoriaDeLivros.FiccaoCientifica, CategoriaDeLivrosDto.FiccaoCientifica },
                {CategoriaDeLivros.Romance, CategoriaDeLivrosDto.Romance }
            };

        private static readonly Dictionary<CategoriaDeLivrosDto, CategoriaDeLivros> MapaDeCategoriasDeLivros =
            new Dictionary<CategoriaDeLivrosDto, CategoriaDeLivros>()
            {
                {CategoriaDeLivrosDto.Fantasia, CategoriaDeLivros.Fantasia },
                {CategoriaDeLivrosDto.Aventura, CategoriaDeLivros.Aventura },
                {CategoriaDeLivrosDto.FiccaoCientifica, CategoriaDeLivros.FiccaoCientifica },
                {CategoriaDeLivrosDto.Romance, CategoriaDeLivros.Romance }
            };

        public static CategoriaDeLivrosDto Mapear(CategoriaDeLivros categoriaDoLivro)
        {
            if (!MapaDeCategoriasDeLivrosDto.ContainsKey(categoriaDoLivro))
                throw new ExcecaoDeMapeamento("Não foi possível mapear a categoria do livro");

            return MapaDeCategoriasDeLivrosDto[categoriaDoLivro];
        }

        public static CategoriaDeLivros Mapear(CategoriaDeLivrosDto categoriaDoLivroDto)
        {
            if (!MapaDeCategoriasDeLivros.ContainsKey(categoriaDoLivroDto))
                throw new ExcecaoDeMapeamento("Não foi possível mapear a categoria do livro");

            return MapaDeCategoriasDeLivros[categoriaDoLivroDto];
        }
    }
}