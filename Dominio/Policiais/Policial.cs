using DepartamentoDePolicia.Dominio._Comum;
using DepartamentoDePolicia.Dominio._Helper;
using DepartamentoDePolicia.Dominio.Armas;

namespace DepartamentoDePolicia.Dominio.Policiais
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
            Experiencia += 15;
            if (Experiencia == 100)
                SubirDeNivel();
        }

        private void SubirDeNivel()
        {
            Experiencia = 0;
            Nivel += 1;
        }
    }
}