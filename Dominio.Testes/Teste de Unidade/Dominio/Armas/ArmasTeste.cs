using DepartamentoDePolicia.Dominio._Comum;
using DepartamentoDePolicia.Dominio.Armas;
using DepartamentoDePolicia.Testes._Helper;
using ExpectedObjects;
using Xunit;

namespace DepartamentoDePolicia.Testes.Teste_de_Unidade.Dominio.Armas
{
    public class ArmasTeste
    {
        private readonly string _nome;
        private readonly int _quantidadeDeBalasNoPente;
        private readonly TiposDeArmas _tipoDaArma;

        public ArmasTeste()
        {
            _tipoDaArma = TiposDeArmas.SMG;
            _nome = "P90";
            _quantidadeDeBalasNoPente = 100;
        }

        [Fact]
        public void Deve_criar_uma_arma()
        {
            var armaEsperada = new
            {
                Nome = _nome,
                Tipo = TiposDeArmas.SMG,
                QuantidadeDeBalasNoPente = 100
            };

            var armaObtida = new Arma(_nome, _tipoDaArma, _quantidadeDeBalasNoPente);

            armaEsperada.ToExpectedObject().ShouldMatch(armaObtida);
        }

        [Fact]
        public void Deve_criar_uma_arma_descarregada()
        {
            const int quantidadeEsperada = 0;

            var arma = new Arma(_nome, _tipoDaArma, _quantidadeDeBalasNoPente);

            Assert.Equal(quantidadeEsperada, arma.QuantidadeDeBalasRestantesNoPente);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Nao_deve_criar_uma_arma_com_nome_invalidando(string nomeInvalido)
        {
            const string mensagemEsperada = "É necessário informar um nome válido para a arma.";

            void Acao() => new Arma(nomeInvalido, _tipoDaArma, _quantidadeDeBalasNoPente);

            Assert.Throws<ExcecaoDeDominio<Arma>>(Acao).ComMensagem(mensagemEsperada);
        }

        [Theory]
        [InlineData((TiposDeArmas) 80)]
        [InlineData((TiposDeArmas)90)]
        [InlineData((TiposDeArmas)10)]
        public void Nao_deve_criar_uma_arma_com_tipo_invalido(TiposDeArmas tipoInvalido)
        {
            const string mensagemEsperada = "É necessário informar um tipo válido para a arma.";

            void Acao() => new Arma(_nome, tipoInvalido, _quantidadeDeBalasNoPente);

            Assert.Throws<ExcecaoDeDominio<Arma>>(Acao).ComMensagem(mensagemEsperada);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(-52)]
        public void Nao_deve_criar_uma_arma_com_quantidade_de_balas_no_pente_invalida(int quantidadeDeBalasNoPenteInvalida)
        {
            const string mensagemDeErroEsperada = "É necessário informar uma quantidade válidade de balas no pente.";

            void Acao() => new Arma(_nome, _tipoDaArma, quantidadeDeBalasNoPenteInvalida);

            Assert.Throws<ExcecaoDeDominio<Arma>>(Acao).ComMensagem(mensagemDeErroEsperada);
        }

        [Fact]
        public void Deve_recarregar_arma()
        {
            const int quantidadeDeBalasRecarregadas = 30;
            var arma = new Arma(_nome, _tipoDaArma, _quantidadeDeBalasNoPente);

            arma.RecarregarPente(quantidadeDeBalasRecarregadas);

            Assert.Equal(quantidadeDeBalasRecarregadas, arma.QuantidadeDeBalasRestantesNoPente);
        }

        [Fact]
        public void Nao_deve_recarregar_a_arma_com_mais_balas_do_que_o_pente_suporta()
        {
            const string mensagemDeErroEsperada = "A quantidade a ser recarregada é maior do que o pente suporta.";
            const int quantidadeDeBalasRecarregadas = 101;
            var arma = new Arma(_nome, _tipoDaArma, _quantidadeDeBalasNoPente);

            void Acao() => arma.RecarregarPente(quantidadeDeBalasRecarregadas);

            Assert.Throws<ExcecaoDeDominio<Arma>>(Acao).ComMensagem(mensagemDeErroEsperada);
        }
    }
}