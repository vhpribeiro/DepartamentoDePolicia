using System.Collections.Generic;
using Departamento.De.Policia.Aplicacao;
using Departamento.De.Policia.Dominio.Armas;
using Departamento.De.Policia.Dominio.Policiais;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DepartamentoDePolicia.API.Controllers
{
    [Route("/api/[controller]")]
    public class DepartamentosDePoliciaisController : Controller
    {
        private readonly IServicoDeDistribuicaoDePoliciais _servicoDeDistribuicaoDePoliciais;

        public DepartamentosDePoliciaisController(IServicoDeDistribuicaoDePoliciais servicoDeDistribuicaoDePoliciais)
        {
            _servicoDeDistribuicaoDePoliciais = servicoDeDistribuicaoDePoliciais;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void DistribuirNovosPoliciasParaSeusDepartamentos()
        {
            const int numeroDoDepartamento = 456;
            var arma = new Arma("P90", TiposDeArmas.SMG, 30);
            var policiais = new List<Policial>
            {
                new Policial("Vitor Hugo P. Ribeiro", "100023156", 23, 0, arma)
            };
            _servicoDeDistribuicaoDePoliciais.EncaminharPoliciasParaDepartamento(numeroDoDepartamento, policiais);
        }
    }
}