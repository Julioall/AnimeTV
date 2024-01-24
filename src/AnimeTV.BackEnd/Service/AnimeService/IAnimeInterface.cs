using AnimeTV.BackEnd.Models;
using AnimeTV.BackEnd.Models.Anime;

namespace AnimeTV.BackEnd.Service.AnimeService
{
    public interface IAnimeInterface
    {
        Task<ServiceResponse<List<Anime>>> GetAnimes();
        Task<ServiceResponse<Anime>> GetAnimeById(int id);
        Task<ServiceResponse<List<Anime>>> CreateAnime(Anime animeNovo);
        Task<ServiceResponse<List<Anime>>> UpdateAnime(Anime animeEditado);
        Task<ServiceResponse<List<Anime>>> DeleteAnime(int id);

    }
}
