namespace Biblioteca.Aplicacao.Livros.Comando
{
    public interface IControleDeQuantidadeDeLivros
    {
        void Emprestar(int idDoLivro, int quantidadeSolicitada);
    }
}