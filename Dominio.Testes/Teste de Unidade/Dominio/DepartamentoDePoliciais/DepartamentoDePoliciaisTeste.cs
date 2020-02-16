using System.Collections.Generic;
using Departamento.De.Policia.Dominio._Comum;
using Departamento.De.Policia.Dominio.Policiais;
using Departamento.De.Policia.Dominio.Viaturas;
using Departamento.De.Policia.Testes._Helper;
using Departamento.De.Policia.Testes._Helper.Builders;
using ExpectedObjects;
using Nosbor.FluentBuilder.Br;
using Xunit;

namespace Departamento.De.Policia.Testes.Teste_de_Unidade.Dominio.DepartamentoDePoliciais
{
    public class DepartamentoDePoliciaisTeste
    {
        private readonly int _anoDeCriacao;
        private readonly int _numeroDeRegistro;

        public DepartamentoDePoliciaisTeste()
        {
            _numeroDeRegistro = 456;
            _anoDeCriacao = 1996;
        }

        [Fact]
        public void Deve_criar_um_departamento()
        {
            var departamentoEsperado = new
            {
                AnoDeCriacao = _anoDeCriacao,
                NumeroDeRegistro = _numeroDeRegistro,
                Policiais = new List<Policial>(),
                Viaturas = new List<Viatura>()
            };

            var departamentoObtido = new Policia.Dominio.DepartamentosDePolicias.DepartamentoDePoliciais(_anoDeCriacao, _numeroDeRegistro);

            departamentoEsperado.ToExpectedObject().ShouldMatch(departamentoObtido);
        }

        [Theory]
        [InlineData(1959)]
        [InlineData(-1)]
        [InlineData(-2000)]
        public void Nao_deve_criar_departamento_com_ano_inferior_a_1960(int anoDeCriacaoInvalido)
        {
            const string mensagemEsperada = "É necessário informar um ano válido de criação do departamento.";

            void Acao() => new Policia.Dominio.DepartamentosDePolicias.DepartamentoDePoliciais(anoDeCriacaoInvalido, _numeroDeRegistro);

            Assert.Throws<ExcecaoDeDominio<Policia.Dominio.DepartamentosDePolicias.DepartamentoDePoliciais>>(Acao)
                .ComMensagem(mensagemEsperada);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2000)]
        public void Nao_deve_criar_departamento_com_numero_de_registro_invalido(int numeroDeRegistroInvalido)
        {
            const string mensagemEsperada = "É necessário informar um número de registro válido para o departamento.";

            void Acao() => new Policia.Dominio.DepartamentosDePolicias.DepartamentoDePoliciais(_anoDeCriacao, numeroDeRegistroInvalido);

            Assert.Throws<ExcecaoDeDominio<Policia.Dominio.DepartamentosDePolicias.DepartamentoDePoliciais>>(Acao)
                .ComMensagem(mensagemEsperada);
        }

        [Fact]
        public void Deve_contratar_um_policial()
        {
            var departamentoDePoliciais = FluentBuilder<Policia.Dominio.DepartamentosDePolicias.DepartamentoDePoliciais>
                .Novo().Criar();
            var policial = PolicialBuilder.UmNovoPolicial().Criar();
            var policiaisEsperados = new List<Policial>{policial};

            departamentoDePoliciais.ContratarPolicial(policial);

            Assert.Equal(departamentoDePoliciais.Policiais, policiaisEsperados);
        }

        [Fact]
        public void Deve_adquirir_uma_nova_viatura()
        {
            var departamentoDePoliciais = FluentBuilder<Policia.Dominio.DepartamentosDePolicias.DepartamentoDePoliciais>
                .Novo().Criar();
            var viatura = FluentBuilder<Viatura>.Novo().Criar();
            var viaturasEsperadas = new List<Viatura> { viatura };

            departamentoDePoliciais.ComprarNovaViatura(viatura);

            Assert.Equal(departamentoDePoliciais.Viaturas, viaturasEsperadas);
        }
    }
}