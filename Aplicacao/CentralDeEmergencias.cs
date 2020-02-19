using Departamento.De.Policia.Aplicacao._Comum;
using Departamento.De.Policia.Dominio.DepartamentosDePolicias;

namespace Departamento.De.Policia.Aplicacao
{
    public class CentralDeEmergencias : ICentralDeEmergencias
    {
        private readonly IDepartamentoDePoliciaisRepositorio _departamentoDePoliciasRepositorio;

        public CentralDeEmergencias(IDepartamentoDePoliciaisRepositorio departamentoDePoliciaisRepositorio)
        {
            _departamentoDePoliciasRepositorio = departamentoDePoliciaisRepositorio;
        }

        public void AcionarAlarme(int numeroDeRegistro)
        {
            var gerenciadorDeAlarme = new GerenciadorDeAlarme(); //Publisher
            var departamento =
                _departamentoDePoliciasRepositorio.ObterDepartamentoDePoliciaPorNumeroDeRegistro(numeroDeRegistro); //Subscriber

            if(departamento == null)
                throw new ExcecaoDeAplicacao("Não foi encontrado nenhum departamento com o número informado.");

            gerenciadorDeAlarme.DisparouAlarme += departamento.DisparouAlarmeHandler;

            gerenciadorDeAlarme.AcionarAlarme();
        }
    }
}