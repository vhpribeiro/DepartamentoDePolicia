using Departamento.De.Policia.Aplicacao._Comum;

namespace Departamento.De.Policia.Dominio.DepartamentosDePolicias
{
    public interface IDepartamentoDePoliciaisRepositorio : IRepositorioBase<DepartamentoDePoliciais>
    {
        DepartamentoDePoliciais ObterDepartamentoDePoliciaPorNumeroDeRegistro(int numeroDeRegistro);
    }
}