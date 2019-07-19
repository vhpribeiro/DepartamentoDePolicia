using Biblioteca.Aplicacao.Dtos;
using Biblioteca.Aplicacao.Mapeadores;
using Biblioteca.Aplicacao._Comum;

namespace Biblioteca.Aplicacao.Livros.Comando
{
    public class CadastroDeLivros : ICadastroDeLivros
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public CadastroDeLivros(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public void Cadastrar(LivroDto livroDto)
        {
            var livros = _livroRepositorio.ObterPorTitulo(livroDto.Titulo);

            if (livros != null)
                throw new ExcecaoDeAplicacao("Já existe um livro cadastrado com este nome!");

            var livro = MapeadorDeLivro.Mapear(livroDto);
            _livroRepositorio.Salvar(livro);
        }
    }
}