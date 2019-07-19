using Biblioteca.Aplicacao.Dtos;
using Biblioteca.Dominio.Autores;

namespace Biblioteca.Aplicacao.Mapeadores
{
    public static class MapeadorDeAutor
    {
        public static AutorDto Mapear(Autor autor)
        {
            if (autor == null)
                return null;

            return new AutorDto
            {
                Nome = autor.Nome,
                QuantidadeDeLivrosVendidos = autor.QuantidadeDeLivrosVendidos
            };
        }

        public static Autor Mapear(AutorDto autorDto)
        {
            if (autorDto == null)
                return null;

            return new Autor(autorDto.Nome, autorDto.QuantidadeDeLivrosVendidos);
        }
    }
}