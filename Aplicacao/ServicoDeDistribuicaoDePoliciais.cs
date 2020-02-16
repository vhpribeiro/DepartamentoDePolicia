using Departamento.De.Policia.Dominio.DepartamentosDePolicias;
using Departamento.De.Policia.Dominio.Policiais;
using System.Collections.Generic;

namespace Departamento.De.Policia.Aplicacao
{
    public class ServicoDeDistribuicaoDePoliciais : IServicoDeDistribuicaoDePoliciais
    {
        private readonly IDepartamentoDePoliciaisRepositorio _departamentoDePoliciaisRepositorio;

        public ServicoDeDistribuicaoDePoliciais(IDepartamentoDePoliciaisRepositorio departamentoDePoliciaisRepositorio)
        {
            _departamentoDePoliciaisRepositorio = departamentoDePoliciaisRepositorio;
        }

        public void EncaminharPoliciasParaDepartamento(int numeroDeRegistroDoDP, IEnumerable<Policial> policiais)
        {
            var departamento = 
                _departamentoDePoliciaisRepositorio.ObterDepartamentoDePoliciaPorNumeroDeRegistro(numeroDeRegistroDoDP);

            foreach (var policial in policiais)
                departamento.ContratarPolicial(policial);
            
            _departamentoDePoliciaisRepositorio.Salvar(departamento);
        }
    }
}