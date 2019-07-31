using CopaMundoFilmes.Web.Repositories;
using CopaMundoFilmes.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CopaMundoFilmes.Web.Controllers
{
    public class FilmesController : Controller
    {
        private FilmesRepository filmesRepository;
        private EliminadorDeFilmes eliminadorFilmes;
        public FilmesController(IConfiguration config)
        {
            var copaFilmesUrl = config.GetSection("CopaFilmesURL").Value;

            filmesRepository = new FilmesRepository(copaFilmesUrl);
            eliminadorFilmes = new EliminadorDeFilmes();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var filmes = await filmesRepository.Obter();
            return View(filmes);
        }
        [HttpPost]
        public async Task<IActionResult> Vencedores(string[] filmeIds)
        {
            var filmes = await filmesRepository.ObterPorIds(filmeIds);

            var campeoes = eliminadorFilmes.ObterCampeoes(filmes);            

            return View(campeoes);
        }
    }
}
