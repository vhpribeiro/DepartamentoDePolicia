using DepartamentoDePolicia.Dominio.Viaturas;
using ExpectedObjects;
using Nosbor.FluentBuilder.Br;
using Xunit;

namespace DepartamentoDePolicia.Testes.Teste_de_Unidade.Dominio.Viaturas
{
    public class ViaturaTeste
    {
        [Fact]
        public void Deve_criar_uma_viatura()
        {
            const int ano = 2019;
            const int quantidadeMaximaDoTanqueEmLitros = 50;
            const bool sireneEstaAtiva = false;
            const int quantidadeDeGasolinaEmLitros = 10;

            var viaturaEsperada = new
            {
                Ano = ano,
                QuantidadeMaximaDoTanqueEmLitros = quantidadeMaximaDoTanqueEmLitros,
                SireneEstaAtiva = sireneEstaAtiva,
                QuantidadeDeGasolinaEmLitros = quantidadeDeGasolinaEmLitros

            };

            var viaturaObtida = new Viatura(ano, quantidadeMaximaDoTanqueEmLitros, quantidadeDeGasolinaEmLitros);

            viaturaEsperada.ToExpectedObject().ShouldMatch(viaturaObtida);
        }

        [Fact]
        public void Deve_encher_o_tanque()
        {
            var viatura = FluentBuilder<Viatura>.Novo()
                .Com(v => v.QuantidadeDeGasolinaEmLitros, 10)
                .Com(v => v.QuantidadeMaximaDoTanqueEmLitros, 50)
                .Criar();

            viatura.EncherOTanque();

            Assert.Equal(viatura.QuantidadeDeGasolinaEmLitros, viatura.QuantidadeMaximaDoTanqueEmLitros);
        }
    }
}