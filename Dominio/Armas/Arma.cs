using System;
using DepartamentoDePolicia.Dominio._Comum;
using DepartamentoDePolicia.Dominio._Helper;

namespace DepartamentoDePolicia.Dominio.Armas
{
    public class Arma : Entidade<Arma>
    {
        public string Nome { get; protected set; }
        public TiposDeArmas Tipo { get; protected set; }
        public int QuantidadeDeBalasNoPente { get; protected set; }
        public int QuantidadeDeBalasRestantesNoPente { get; protected set; }

        public Arma(string nomeDaArma, TiposDeArmas tipo, int quantidadeDeBalasNoPente)
        {
            ValidarInformacoes(nomeDaArma, tipo, quantidadeDeBalasNoPente);

            Nome = nomeDaArma;
            Tipo = tipo;
            QuantidadeDeBalasNoPente = quantidadeDeBalasNoPente;
            QuantidadeDeBalasRestantesNoPente = 0;
        }

        private static void ValidarInformacoes(string nomeDaArma, TiposDeArmas tipo, int quantidadeDeBalasNoPente)
        {
            var tipoEstaDefinido = Enum.IsDefined(typeof(TiposDeArmas), tipo);

            Validacoes<Arma>.Criar()
                .Obrigando(nomeDaArma, "É necessário informar um nome válido para a arma.")
                .Quando(!tipoEstaDefinido, "É necessário informar um tipo válido para a arma.")
                .Quando(quantidadeDeBalasNoPente < 0, "É necessário informar uma quantidade válidade de balas no pente.")
                .DispararSeHouverErros();
        }

        public void RecarregarPente(int quantidadeDeBalasRecarregadas)
        {
            Validacoes<Arma>.Criar()
                .Quando(quantidadeDeBalasRecarregadas > QuantidadeDeBalasNoPente,
                    "A quantidade a ser recarregada é maior do que o pente suporta.")
                .Quando(QuantidadeDeBalasNoPente == QuantidadeDeBalasRestantesNoPente, "O pente já está cheio.")
                .DispararSeHouverErros();

            QuantidadeDeBalasRestantesNoPente = quantidadeDeBalasRecarregadas;
        }
    }
}