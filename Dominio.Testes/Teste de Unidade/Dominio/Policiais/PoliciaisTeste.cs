using DepartamentoDePolicia.Dominio._Comum;
using DepartamentoDePolicia.Dominio._Helper;
using DepartamentoDePolicia.Dominio.Armas;
using DepartamentoDePolicia.Testes._Helper;
using DepartamentoDePolicia.Testes._Helper.Builders;
using ExpectedObjects;
using Xunit;

namespace DepartamentoDePolicia.Testes.Teste_de_Unidade.Dominio.Policiais
{
    public class PoliciaisTeste
    {
        private readonly string _nome;
        private readonly string _numeroDoDistintivo;
        private readonly int _idade;
        private readonly int _anosNaAcademia;
        private readonly Arma _arma;

        public PoliciaisTeste()
        {
            _nome = "Vitor H. P. Ribeiro";
            _numeroDoDistintivo = "10004545";
            _idade = 23;
            _anosNaAcademia = 2;
            _arma = ArmaBuilder.UmNovaArma().Criar();
        }

        [Fact]
        public void Deve_formar_um_policial()
        {
            var policialEsperado = new
            {
                Nome = _nome,
                NumeroDoDistintivo = _numeroDoDistintivo,
                Idade = _idade,
                AnosNaAcademia = _anosNaAcademia,
                Arma = _arma
            };

            var policialObtido = new Policial(_nome, _numeroDoDistintivo, _idade, _anosNaAcademia, _arma);

            policialEsperado.ToExpectedObject().ShouldMatch(policialObtido);
        }

        [Fact]
        public void Deve_formar_um_policial_inicial_sem_experiencia_e_no_nivel_um()
        {
            var policialEsperado = new
            {
                Nome = _nome,
                NumeroDoDistintivo = _numeroDoDistintivo,
                Idade = _idade,
                AnosNaAcademia = _anosNaAcademia,
                Arma = _arma,
                Experiencia = 0,
                Nivel = 1
            };

            var policialObtido = new Policial(_nome, _numeroDoDistintivo, _idade, _anosNaAcademia, _arma);

            policialEsperado.ToExpectedObject().ShouldMatch(policialObtido);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Nao_deve_formar_um_policial_com_nome_invalido(string nomeInvalido)
        {
            const string mensagemEsperada = "É necessário informar um nome válido para o policial.";

            void Acao() => new Policial(nomeInvalido, _numeroDoDistintivo, _idade, _anosNaAcademia, _arma);

            Assert.Throws<ExcecaoDeDominio<Policial>>(Acao).ComMensagem(mensagemEsperada);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Nao_deve_formar_um_policial_com_numero_do_distintivo_invalido(string numeroDoDistintivoInvalido)
        {
            const string mensagemEsperada = "É necessário informar um número do distintivo válido para o policial.";

            void Acao() => new Policial(_nome, numeroDoDistintivoInvalido, _idade, _anosNaAcademia, _arma);

            Assert.Throws<ExcecaoDeDominio<Policial>>(Acao).ComMensagem(mensagemEsperada);
        }
    }

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
                .DispararSeHouverErros();

            Nome = nome;
            NumeroDoDistintivo = numeroDoDistintivo;
            Idade = idade;
            AnosNaAcademia = anosNaAcademia;
            Arma = arma;
            Experiencia = 0;
            Nivel = 1;
        }
    }
}