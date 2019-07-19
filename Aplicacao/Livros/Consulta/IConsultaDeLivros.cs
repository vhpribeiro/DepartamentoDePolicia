using System.Collections.Generic;
using Biblioteca.Aplicacao.Dtos;

namespace Biblioteca.Aplicacao.Livros.Consulta
{
    public interface IConsultaDeLivros
    {
        IEnumerable<LivroDto> ConsultarPorTitulo(string tituloDoLivro);
        IEnumerable<LivroDto> ConsultarPorNomeDoAutor(string nomeDoAutor);
    }
}