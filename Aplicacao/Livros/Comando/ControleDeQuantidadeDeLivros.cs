using Biblioteca.Aplicacao._Comum;

namespace Biblioteca.Aplicacao.Livros.Comando
{
    public class ControleDeQuantidadeDeLivros : IControleDeQuantidadeDeLivros
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public ControleDeQuantidadeDeLivros(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public void Emprestar(int idDoLivro, int quantidadeSolicitada)
        {
            var livro = _livroRepositorio.ObterPor(idDoLivro);

            if(livro == null)
                throw new ExcecaoDeAplicacao("Livro não encontrado!");

            livro.PegarEmprestado(quantidadeSolicitada);

            _livroRepositorio.Salvar(livro);
        }
    }
}