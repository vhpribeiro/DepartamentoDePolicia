using Departamento.De.Policia.Aplicacao._Comum;
using Departamento.De.Policia.Dominio.DepartamentosDePolicia;

namespace Departamento.De.Policia.Aplicacao
{
    public interface IDepartamentoDePoliciaRepositorio : IRepositorioBase<DepartamentoDePoliciais>
    {
        DepartamentoDePoliciais ObterDepartamentoDePoliciaPorNumeroDeRegistro(int numeroDeRegistro);
    }
}