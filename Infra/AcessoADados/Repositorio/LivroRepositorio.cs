﻿using System.Collections.Generic;
using System.Linq;
using Biblioteca.Aplicacao.Livros;
using Biblioteca.Dominio.Livros;
using NHibernate;

namespace Biblioteca.Infra.AcessoADados.Repositorio
{
    public class LivroRepositorio : RepositorioBase<Livro>, ILivroRepositorio
    {
        public LivroRepositorio(ISession sessao) : base(sessao) { }

        public IList<Livro> ObterPorTitulo(string titulo)
        {
            return Entidades().Where(l => l.Titulo.Contains(titulo)).ToList();
        }

        public IList<Livro> ObterPorNomeDoAutor(string nomeDoAutor)
        {
            return Entidades().Where(l => l.Autor.Nome.Contains(nomeDoAutor)).ToList();
        }
    }
}