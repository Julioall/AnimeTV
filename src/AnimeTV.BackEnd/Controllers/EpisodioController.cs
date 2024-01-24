using AnimeTV.BackEnd.Models;
using AnimeTV.BackEnd.Models.Anime;
using AnimeTV.BackEnd.Service.EpisodioService;
using Microsoft.AspNetCore.Mvc;

namespace AnimeTV.BackEnd.Controllers
{
    [Route("api/episodio")]
    [ApiController]
    public class EpisodioController : ControllerBase
    {
        private readonly IEpisodioInterface _episodio;
        public EpisodioController(IEpisodioInterface episodio)
        {
            _episodio = episodio;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<AnimeEpisodio>>>> GetEpisodios()
        {
            ServiceResponse<List<AnimeEpisodio>> response = await _episodio.GetEpisodios();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<AnimeEpisodio>>> GetEpisodioById(int id)
        {
            ServiceResponse<AnimeEpisodio> response = await _episodio.GetEpisodioById(id);
            return Ok(response);
        }

        [HttpGet("filtrar={animeId}")]
        public async Task<ActionResult<ServiceResponse<List<AnimeEpisodio>>>> GetEpisodioByIdAnime(int animeId)
        {
            ServiceResponse<List<AnimeEpisodio>> response = await _episodio.GetEpisodioByIdAnime(animeId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<AnimeEpisodio>>>> CreateEpisodio(AnimeEpisodio episodioNovo)
        {
            ServiceResponse<List<AnimeEpisodio>> response = await _episodio.CreateEpisodio(episodioNovo);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<AnimeEpisodio>>>> UpdateEpisodio(AnimeEpisodio episodioEditado)
        {
            ServiceResponse<List<AnimeEpisodio>> response = await _episodio.UpdateEpisodio(episodioEditado);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<AnimeEpisodio>>>> DeleteEpisodio(int id)
        {
            ServiceResponse<List<AnimeEpisodio>> response = await _episodio.DeleteEpisodio(id);
            return Ok(response);
        }
    }
}
