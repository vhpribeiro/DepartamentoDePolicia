using System;
using Biblioteca.Dominio.Autores;
using Biblioteca.Dominio._Comum;
using Biblioteca.Dominio._Helper;

namespace Biblioteca.Dominio.Livros
{
    public class Livro : Entidade<Livro>
    {
        public virtual string Titulo { get; protected set; }
        public virtual Autor Autor { get; protected set; }
        public virtual int AnoDeLancamento { get; protected set; }
        public virtual CategoriaDeLivros Categoria { get; protected set; }
        public virtual int QuantidadeDisponivel { get; protected set; }

        protected Livro() { }

        public Livro(string titulo, int anoDeLancamento, Autor autor, CategoriaDeLivros categoria, int quantidadeDisponivel)
        {
            ValidarDados(titulo, quantidadeDisponivel);

            Titulo = titulo;
            AnoDeLancamento = anoDeLancamento;
            Autor = autor;
            Categoria = categoria;
            QuantidadeDisponivel = quantidadeDisponivel;
        }

        private static void ValidarDados(string titulo, int quantidadeDisponivel)
        {
            Validacoes<Livro>.Criar()
                            .Quando(string.IsNullOrWhiteSpace(titulo), "Título inválido")
                            .Quando(quantidadeDisponivel < 0, "Quantidade disponível inválida")
                            .DispararSeHouverErros();
        }

        public virtual void AlterarQuantidadeDisponivel(int quantidadeQueDeveSerAlterada)
        {
            var moduloDaQuantidadeQueDeveSerAlteradaEhMaiorQueAtual =
                Math.Abs(quantidadeQueDeveSerAlterada) > QuantidadeDisponivel ? true : false;

            Validacao<Livro>.Quando(quantidadeQueDeveSerAlterada < 0
                                    && moduloDaQuantidadeQueDeveSerAlteradaEhMaiorQueAtual, "Nova quantidade disponível é inválida");

            QuantidadeDisponivel = QuantidadeDisponivel + quantidadeQueDeveSerAlterada;
        }

        public virtual void PegarEmprestado(int quantidadeDeLivrosParaSeremEmprestados)
        {
            Validacao<Livro>.Quando(QuantidadeDisponivel < quantidadeDeLivrosParaSeremEmprestados,
                "Não há tantos livros assim! Diminua a quantidade por favor");

            QuantidadeDisponivel = QuantidadeDisponivel - quantidadeDeLivrosParaSeremEmprestados;
        }
    }
}