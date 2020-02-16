using System.Collections.Generic;
using Departamento.De.Policia.Dominio.Policiais;

namespace Departamento.De.Policia.Aplicacao
{
    public interface IServicoDeDistribuicaoDePoliciais
    {
        void EncaminharPoliciasParaDepartamento(int numeroDeRegistroDoDP, IEnumerable<Policial> policiais);
    }
}