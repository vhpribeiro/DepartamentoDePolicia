using Departamento.De.Policia.Dominio.DepartamentosDePolicias;
using NHibernate;
using System.Linq;

namespace Departamento.De.Policia.Infra.AcessoADados.Repositorio
{
    public class DepartamentosDePoliciaisRepositorio : RepositorioBase<DepartamentoDePoliciais>, IDepartamentoDePoliciaisRepositorio
    {
        public DepartamentosDePoliciaisRepositorio(ISession sessao) : base(sessao)
        {
        }

        public DepartamentoDePoliciais ObterDepartamentoDePoliciaPorNumeroDeRegistro(int numeroDeRegistro)
        {
            return Sessao.Query<DepartamentoDePoliciais>().FirstOrDefault(dp => dp.NumeroDeRegistro == numeroDeRegistro);
        }
    }
}