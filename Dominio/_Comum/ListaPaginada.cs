using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Dominio._Comum
{
    public class ListaPaginada<TEntity> where TEntity: class
    {
        private readonly List<TEntity> _itens;
        public IEnumerable<TEntity> Itens => _itens;
        public int TotalDeItens { get; }
        public int QuantidadeDeItensPorPagina { get; }
        public int TotalDePaginas { get; }
        public int PaginaAtual { get; }

        public ListaPaginada(IEnumerable<TEntity> itens, int quantidadeDeItensPorPagina, int paginaAtual)
        {
            TotalDeItens = itens.Count();
            PaginaAtual = paginaAtual;
            QuantidadeDeItensPorPagina = quantidadeDeItensPorPagina;
            TotalDePaginas = (int)Math.Ceiling((decimal)(TotalDeItens/QuantidadeDeItensPorPagina));
        }

        private void Paginar(int quantidadeDeItensPorPagina, int paginaAtual)
        {
            var itensPaginados = paginaAtual == 1
                ? Itens.Take(quantidadeDeItensPorPagina).ToList()
                : Itens.Take(paginaAtual * quantidadeDeItensPorPagina).ToList();
            _itens.AddRange(itensPaginados);
        }
    }
}