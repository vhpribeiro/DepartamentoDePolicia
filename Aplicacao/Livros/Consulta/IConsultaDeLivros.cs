using Biblioteca.Aplicacao.Dtos;
using Biblioteca.Dominio._Comum;

namespace Biblioteca.Aplicacao.Livros.Consulta
{
    public interface IConsultaDeLivros
    {
        ListaPaginada<LivroDto> ConsultarPorFiltros(string titulo, string nomeDoAutor,
            int pagina, int quantidadeDeItensPorPagina);
    }
}