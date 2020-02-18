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

            gerenciadorDeAlarme.DisparouAlarme += departamento.DisparouAlarmeHandler;

            gerenciadorDeAlarme.LigarAlarme();
        }
    }
}