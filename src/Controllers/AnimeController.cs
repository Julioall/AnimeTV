using AnimeTV.Models;
using AnimeTV.Models.Anime;
using AnimeTV.Service.AnimeService;
using Microsoft.AspNetCore.Mvc;

namespace AnimeTV.Controllers
{
    [Route("api/anime")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeInterface _anime;
        public AnimeController(IAnimeInterface anime)
        {
            _anime = anime;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Anime>>>> GetAnimes()
        {
            ServiceResponse<List<Anime>> response = await _anime.GetAnimes();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Anime>>>> CreateAnime(Anime animeNovo)
        {
            ServiceResponse<List<Anime>> response = await _anime.CreateAnime(animeNovo);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Anime>>> GetAnimeById(int id)
        {
            ServiceResponse<Anime> response = await _anime.GetAnimeById(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Anime>>>> UpdateUsuario(Anime animeEditado)
        {
            ServiceResponse<List<Anime>> response = await _anime.UpdateAnime(animeEditado);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<Anime>>>> DeleteAnime(int id)
        {
            ServiceResponse<List<Anime>> response = await _anime.DeleteAnime(id);
            return Ok(response);
        }
    }
}
