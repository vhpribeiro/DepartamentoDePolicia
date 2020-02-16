using System;
using Departamento.De.Policia.Dominio._Comum;
using Departamento.De.Policia.Dominio._Helper;

namespace Departamento.De.Policia.Dominio.Armas
{
    public class Arma : Entidade<Arma>
    {
        public virtual string Nome { get; protected set; }
        public virtual TiposDeArmas Tipo { get; protected set; }
        public virtual int QuantidadeDeBalasNoPente { get; protected set; }
        public virtual int QuantidadeDeBalasRestantesNoPente { get; protected set; }

        protected Arma() { }

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

        public virtual void RecarregarPente(int quantidadeDeBalasRecarregadas)
        {
            Validacoes<Arma>.Criar()
                .Quando(quantidadeDeBalasRecarregadas + QuantidadeDeBalasRestantesNoPente > QuantidadeDeBalasNoPente,
                    "A quantidade a ser recarregada é maior do que o pente suporta.")
                .Quando(QuantidadeDeBalasNoPente == QuantidadeDeBalasRestantesNoPente, "O pente já está cheio.")
                .DispararSeHouverErros();

            QuantidadeDeBalasRestantesNoPente += quantidadeDeBalasRecarregadas;
        }
    }
}