using DepartamentoDePolicia.Dominio._Comum;

namespace DepartamentoDePolicia.Dominio.Armas
{
    public class Arma : Entidade<Arma>
    {
        public string Nome { get; protected set; }
        public TiposDeArmas Tipo { get; protected set; }
        public int QuantidadeDeBalasNoPente { get; protected set; }

        public Arma(string nomeDaArma, TiposDeArmas tipo, int quantidadeDeBalasNoPente)
        {
            Nome = nomeDaArma;
            Tipo = tipo;
            QuantidadeDeBalasNoPente = quantidadeDeBalasNoPente;
        }
    }
}