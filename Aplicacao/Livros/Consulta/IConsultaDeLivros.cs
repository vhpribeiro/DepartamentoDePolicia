using System.Collections.Generic;
using Biblioteca.Aplicacao.Dtos;

namespace Biblioteca.Aplicacao.Livros.Consulta
{
    public interface IConsultaDeLivros
    {
        IEnumerable<LivroDto> ConsultarPorFiltros(string titulo, string nomeDoAutor);
    }
}