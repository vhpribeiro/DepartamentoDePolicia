using Biblioteca.Dominio._Comum;
using Biblioteca.Dominio._Helper;

namespace Biblioteca.Dominio.Autores
{
    public class Autor : Entidade<Autor>
    {
        public virtual string Nome { get; protected set; }
        public virtual int QuantidadeDeLivrosVendidos { get; protected set; }

        protected Autor() { }

        public Autor(string nome, int quantidadeDeLivrosVendidos)
        {
            ValidarDados(nome, quantidadeDeLivrosVendidos);

            Nome = nome;
            QuantidadeDeLivrosVendidos = quantidadeDeLivrosVendidos;
        }

        private static void ValidarDados(string nome, int quantidadeDeLivrosVendidos)
        {
            Validacoes<Autor>.Criar()
                .Quando(string.IsNullOrWhiteSpace(nome), "Nome inválido")
                .Quando(quantidadeDeLivrosVendidos < 0, "Quantidade de livros vendidos inválida")
                .DispararSeHouverErros();
        }
    }
}