using DepartamentoDePolicia.Dominio.Armas;
using ExpectedObjects;
using Xunit;

namespace DepartamentoDePolicia.Testes.Teste_de_Unidade.Dominio.Armas
{
    public class ArmasTeste
    {
        [Fact]
        public void Deve_criar_uma_arma()
        {
            var armaEsperada = new
            {
                Nome = "P90",
                Tipo = TiposDeArmas.SMG,
                QuantidadeDeBalasNoPente = 100
            };

            var armaObtida = new Arma("P90", TiposDeArmas.SMG, 100);

            armaEsperada.ToExpectedObject().ShouldMatch(armaObtida);
        }
    }
}