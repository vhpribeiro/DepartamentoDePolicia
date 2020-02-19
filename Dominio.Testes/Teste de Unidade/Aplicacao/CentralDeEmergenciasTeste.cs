using Departamento.De.Policia.Aplicacao;
using Departamento.De.Policia.Aplicacao._Comum;
using Departamento.De.Policia.Dominio.DepartamentosDePolicias;
using Moq;
using Xunit;

namespace Departamento.De.Policia.Testes.Teste_de_Unidade.Aplicacao
{
    public class CentralDeEmergenciasTeste
    {
        [Fact]
        public void Nao_deve_acionar_alarme_quando_nao_achar_o_departamento()
        {
            const int numeroDeRegistroDoDepartamento = 1;
            DepartamentoDePoliciais departamentoDePoliciasInvalido = null;
            var departamentoDePoliciasRepositorio = new Mock<IDepartamentoDePoliciaisRepositorio>();
            var centralDeEmergencias = new CentralDeEmergencias(departamentoDePoliciasRepositorio.Object);
            departamentoDePoliciasRepositorio
                .Setup(dp => dp.ObterDepartamentoDePoliciaPorNumeroDeRegistro(numeroDeRegistroDoDepartamento))
                .Returns(departamentoDePoliciasInvalido);
            const string mensagemEsperada = "Não foi encontrado nenhum departamento com o número informado.";

            void Acao() => centralDeEmergencias.AcionarAlarme(numeroDeRegistroDoDepartamento);

            var mensagemObtida = Assert.Throws<ExcecaoDeAplicacao>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagemObtida);
        }
    }
}