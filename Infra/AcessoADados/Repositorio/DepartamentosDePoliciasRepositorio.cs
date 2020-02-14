using System.Collections.Generic;
using Departamento.De.Policia.Aplicacao;
using Departamento.De.Policia.Dominio.DepartamentosDePolicia;

namespace Departamento.De.Policia.Infra.AcessoADados.Repositorio
{
    public class DepartamentosDePoliciasRepositorio : IDepartamentoDePoliciaRepositorio, RepositorioBase
    {
        public DepartamentoDePoliciais ObterPor(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DepartamentoDePoliciais> ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        public void Salvar(DepartamentoDePoliciais entidade)
        {
            throw new System.NotImplementedException();
        }

        public DepartamentoDePoliciais ObterDepartamentoDePoliciaPorNumeroDeRegistro(int numeroDeRegistro)
        {
            throw new System.NotImplementedException();
        }
    }
}