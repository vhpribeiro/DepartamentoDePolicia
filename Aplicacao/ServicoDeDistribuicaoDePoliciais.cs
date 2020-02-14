using System.Collections.Generic;
using Departamento.De.Policia.Dominio.Policiais;

namespace Departamento.De.Policia.Aplicacao
{
    public class ServicoDeDistribuicaoDePoliciais : IServicoDeDistribuicaoDePoliciais
    {
        public ServicoDeDistribuicaoDePoliciais()
        {
        }

        public void EncaminharPoliciasParaDepartamento(int numeroDeRegistroDoDP, IEnumerable<Policial> policiais)
        {

        }
    }

    public interface IServicoDeDistribuicaoDePoliciais
    {
    }
}