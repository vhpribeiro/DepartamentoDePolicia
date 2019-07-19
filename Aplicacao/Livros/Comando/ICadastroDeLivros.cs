using Biblioteca.Aplicacao.Dtos;

namespace Biblioteca.Aplicacao.Livros.Comando
{
    public interface ICadastroDeLivros
    {
        void Cadastrar(LivroDto livroDto);
    }
}