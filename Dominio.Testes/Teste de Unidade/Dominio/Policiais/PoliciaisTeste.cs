using DepartamentoDePolicia.Dominio._Comum;
using DepartamentoDePolicia.Dominio.Armas;
using DepartamentoDePolicia.Dominio.Policiais;
using DepartamentoDePolicia.Testes._Helper;
using DepartamentoDePolicia.Testes._Helper.Builders;
using ExpectedObjects;
using Nosbor.FluentBuilder.Br;
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

        [Theory]
        [InlineData(19)]
        [InlineData(10)]
        [InlineData(0)]
        [InlineData(-20)]
        public void Nao_deve_formar_um_policial_com_idade_inferior_a_20_anos(int idadeInvalida)
        {
            const string mensagemEsperada = "A idade mínima para se formar na academia é 20 anos de idade.";

            void Acao() => new Policial(_nome, _numeroDoDistintivo, idadeInvalida, _anosNaAcademia, _arma);

            Assert.Throws<ExcecaoDeDominio<Policial>>(Acao).ComMensagem(mensagemEsperada);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-100)]
        public void Nao_deve_informar_anos_de_academia_invalida(int anosDeAcademiaInvalido)
        {
            const string mensagemEsperada = "É necessário informar um tempo de experiência válido.";

            void Acao() => new Policial(_nome, _numeroDoDistintivo, _idade, anosDeAcademiaInvalido, _arma);

            Assert.Throws<ExcecaoDeDominio<Policial>>(Acao).ComMensagem(mensagemEsperada);
        }

        [Fact]
        public void Nao_deve_aceitar_um_policial_que_nao_possui_arma()
        {
            Arma armaInvalida = null;
            const string mensagemEsperada = "Todo policial precisa possuir uma arma.";

            void Acao() => new Policial(_nome, _numeroDoDistintivo, _idade, _anosNaAcademia, armaInvalida);

            Assert.Throws<ExcecaoDeDominio<Policial>>(Acao).ComMensagem(mensagemEsperada);
        }

        [Fact]
        public void Deve_ganhar_cinco_de_experiencia_ao_limpar_o_patio()
        {
            const int experienciaEsperada = 5;
            var policial = PolicialBuilder.UmNovoPolicial().Criar();

            policial.LimparOPatio();

            Assert.Equal(experienciaEsperada, policial.Experiencia);
        }

        [Fact]
        public void Deve_subir_de_nivel_e_zerar_a_experiencia_ao_alcancar_cem_de_experiência_quando_limpar_o_patio()
        {
            const int nivelInicial = 0;
            const int nivelEsperado = 1;
            const int experienciaInicial = 95;
            const int experienciaEsperada = 0;
            var policial = FluentBuilder<Policial>
                .Novo()
                .Com(p => p.Experiencia, experienciaInicial)
                .Com(p => p.Nivel, nivelInicial)
                .Criar();

            policial.LimparOPatio();

            Assert.Equal(nivelEsperado, policial.Nivel);
            Assert.Equal(experienciaEsperada, policial.Experiencia);
        }

        [Fact]
        public void Deve_ganhar_quinze_de_experiencia_ao_fazer_uma_ronda()
        {
            const int experienciaInicial = 0;
            const int experienciaEsperada = 15;
            var policial = FluentBuilder<Policial>
                .Novo()
                .Com(p => p.Experiencia, experienciaInicial)
                .Criar();

            policial.FazerRonda();

            Assert.Equal(experienciaEsperada, policial.Experiencia);
        }

        [Fact]
        public void Deve_subir_de_nivel_e_zerar_a_experiencia_ao_alcancar_cem_de_experiência_quando_fizer_uma_ronda()
        {
            const int nivelInicial = 0;
            const int nivelEsperado = 1;
            const int experienciaInicial = 85;
            const int experienciaEsperada = 0;
            var policial = FluentBuilder<Policial>
                .Novo()
                .Com(p => p.Experiencia, experienciaInicial)
                .Com(p => p.Nivel, nivelInicial)
                .Criar();

            policial.FazerRonda();

            Assert.Equal(nivelEsperado, policial.Nivel);
            Assert.Equal(experienciaEsperada, policial.Experiencia);
        }
    }
}