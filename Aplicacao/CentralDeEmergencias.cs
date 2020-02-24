using Departamento.De.Policia.Aplicacao._Comum;
using Departamento.De.Policia.Dominio.DepartamentosDePolicias;

namespace Departamento.De.Policia.Aplicacao
{
    public class CentralDeEmergencias : ICentralDeEmergencias
    {
        private readonly IDepartamentoDePoliciaisRepositorio _departamentoDePoliciaisRepositorio;

        public CentralDeEmergencias(IDepartamentoDePoliciaisRepositorio departamentoDePoliciaisRepositorio)
        {
            _departamentoDePoliciaisRepositorio = departamentoDePoliciaisRepositorio;
        }

        public void AcionarAlarme(int numeroDeRegistro)
        {
            var gerenciadorDeAlarme = new GerenciadorDeAlarme(); //Subject
            var departamento =
                _departamentoDePoliciaisRepositorio.ObterDepartamentoDePoliciaPorNumeroDeRegistro(numeroDeRegistro); //Observer

            if(departamento == null)
                throw new ExcecaoDeAplicacao("Não foi encontrado nenhum departamento com o número informado.");

            gerenciadorDeAlarme.DisparouAlarme += departamento.DisparouAlarmeHandler; //Subscrição

            gerenciadorDeAlarme.AcionarAlarme();
        }
    }
}