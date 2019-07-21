using Biblioteca.Aplicacao.Livros.Comando;
using Biblioteca.Aplicacao.Livros.Consulta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LivrosController : Controller
    {
        private readonly IConsultaDeLivros _consultaDeLivros;
        private readonly IControleDeQuantidadeDeLivros _controleDeQuantidadeDeLivros;

        public LivrosController(IConsultaDeLivros consultaDeLivros, IControleDeQuantidadeDeLivros controleDeQuantidadeDeLivros)
        {
            _consultaDeLivros = consultaDeLivros;
            _controleDeQuantidadeDeLivros = controleDeQuantidadeDeLivros;
        }

        [HttpGet]
        [AllowAnonymous]
        //Melhorar a rota, péssima prática do REST
        [Route("{titulo}")]
        public ActionResult ObterLivrosPorTitulo(string titulo)
        {
            var livros = _consultaDeLivros.ConsultarPorTitulo(titulo);

            return Json(livros);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("")]
        public ActionResult ObterLivrosPorNomeDoAutor(string nomeDoAutor)
        {
            var livros = _consultaDeLivros.ConsultarPorNomeDoAutor(nomeDoAutor);

            return Json(livros);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("{idDoLivro}")]
        public ActionResult PegarEmprestado(int idDoLivro, int quantidadeSolicitada)
        {
            _controleDeQuantidadeDeLivros.Emprestar(idDoLivro, quantidadeSolicitada);

            return Ok();
        }
    }
}