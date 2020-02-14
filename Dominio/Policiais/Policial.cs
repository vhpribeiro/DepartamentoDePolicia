using Departamento.De.Policia.Dominio._Comum;
using Departamento.De.Policia.Dominio._Helper;
using Departamento.De.Policia.Dominio.Armas;
using Departamento.De.Policia.Dominio.Viaturas;

namespace Departamento.De.Policia.Dominio.Policiais
{
    public class Policial : Entidade<Policial>
    {
        public string Nome { get; protected set; }
        public string NumeroDoDistintivo { get; protected set; }
        public int Idade { get; protected set; }
        public int AnosNaAcademia { get; protected set; }
        public Arma Arma { get; protected set; }
        public int Experiencia { get; protected set; }
        public int Nivel { get; protected set; }
        public Viatura Viatura { get; protected set; }

        public Policial(string nome, string numeroDoDistintivo, int idade, int anosNaAcademia, Arma arma)
        {
            Validacoes<Policial>.Criar()
                .Obrigando(nome, "É necessário informar um nome válido para o policial.")
                .Obrigando(numeroDoDistintivo, "É necessário informar um número do distintivo válido para o policial.")
                .Quando(idade < 20, "A idade mínima para se formar na academia é 20 anos de idade.")
                .Quando(anosNaAcademia < 0, "É necessário informar um tempo de experiência válido.")
                .Obrigando(arma, "Todo policial precisa possuir uma arma.")
                .DispararSeHouverErros();

            Nome = nome;
            NumeroDoDistintivo = numeroDoDistintivo;
            Idade = idade;
            AnosNaAcademia = anosNaAcademia;
            Arma = arma;
            Experiencia = 0;
            Nivel = 1;
        }

        public void LimparOPatio()
        {
            Experiencia += 5;
            if (Experiencia == 100)
                SubirDeNivel();
        }

        public void FazerRonda()
        {
            var ehNecessarioRecarregarAArma = Arma.QuantidadeDeBalasNoPente > Arma.QuantidadeDeBalasRestantesNoPente;
            if(ehNecessarioRecarregarAArma)
                RecarregarArma();

            var ehNecessarioEncherOTanque =
                Viatura.QuantidadeMaximaDoTanqueEmLitros > Viatura.QuantidadeDeGasolinaEmLitros;
            if (Viatura != null && ehNecessarioEncherOTanque)
                Viatura.EncherOTanque();

            Experiencia += 15;
            if (Experiencia == 100)
                SubirDeNivel();
        }

        public void ReceberViatura(Viatura viatura)
        {
            Validacoes<Policial>.Criar()
                .Obrigando(viatura, "É necessário dar uma viatura válida para o policial.")
                .Quando(Nivel < 3, "Não é possível dar uma viatura para um policial abaixo do nível três.")
                .DispararSeHouverErros();

            Viatura = viatura;
        }

        private void RecarregarArma()
        {
            var quantidadeDeBalasNecessariaParaEncherOPente =
                Arma.QuantidadeDeBalasNoPente - Arma.QuantidadeDeBalasRestantesNoPente;
            Arma.RecarregarPente(quantidadeDeBalasNecessariaParaEncherOPente);
        }

        private void SubirDeNivel()
        {
            Experiencia = 0;
            Nivel += 1;
        }
    }
}