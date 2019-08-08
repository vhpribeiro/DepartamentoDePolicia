using Biblioteca.Aplicacao.Livros.Comando;
using Biblioteca.Aplicacao.Livros.Consulta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [ApiController]
    [Authorize("Bearer", Roles = "User")]
    [Route("/api/[controller]")]
    public class LivrosController : Controller
    {
        private readonly IConsultaDeLivros _consultaDeLivros;
        private readonly IControleDeQuantidadeDeLivros _controleDeQuantidadeDeLivros;

        public LivrosController(IConsultaDeLivros consultaDeLivros,
            IControleDeQuantidadeDeLivros controleDeQuantidadeDeLivros)
        {
            _consultaDeLivros = consultaDeLivros;
            _controleDeQuantidadeDeLivros = controleDeQuantidadeDeLivros;
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public ActionResult ObterLivrosPorFiltros(string titulo = "", string nomeDoAutor = "")
        {
            var livros = _consultaDeLivros.ConsultarPorFiltros(titulo, nomeDoAutor);

            return Json(livros);
        }

        [HttpPut]
        [Route("{idDoLivro}")]
        [Authorize(Roles = "Admin")]
        public ActionResult PegarEmprestado(int idDoLivro, int quantidadeSolicitada)
        {
            _controleDeQuantidadeDeLivros.Emprestar(idDoLivro, quantidadeSolicitada);

            return Ok();
        }
    }
}