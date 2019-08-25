using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Dominio._Comum
{
    public class ListaPaginada<TEntity> where TEntity: class
    {
        private readonly List<TEntity> _itens = new List<TEntity>();
        public IEnumerable<TEntity> Itens => _itens;
        public int TotalDeItens { get; }
        public int QuantidadeDeItensPorPagina { get; }
        public int TotalDePaginas { get; }
        public int PaginaAtual { get; }

        public ListaPaginada(IEnumerable<TEntity> itens, int quantidadeDeItensPorPagina, int paginaAtual)
        {
            PaginaAtual = paginaAtual;
            QuantidadeDeItensPorPagina = quantidadeDeItensPorPagina;
            TotalDePaginas = (int)Math.Ceiling((decimal)(TotalDeItens/QuantidadeDeItensPorPagina));
            Paginar(itens, quantidadeDeItensPorPagina, paginaAtual);
        }

        public void Paginar(IEnumerable<TEntity> itens, int quantidadeDeItensPorPagina, int paginaAtual)
        {
            var itensPaginados = paginaAtual == 1
                ? itens.Take(quantidadeDeItensPorPagina).ToList()
                : itens.Skip((paginaAtual - 1) * quantidadeDeItensPorPagina).Take(quantidadeDeItensPorPagina);
            _itens.AddRange(itensPaginados);
        }
    }
}