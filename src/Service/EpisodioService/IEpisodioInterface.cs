using AnimeTV.Models;
using AnimeTV.Models.Anime;

namespace AnimeTV.Service.EpisodioService
{
    public interface IEpisodioInterface
    {

        Task<ServiceResponse<List<AnimeEpisodio>>> GetEpisodios();
        Task<ServiceResponse<AnimeEpisodio>> GetEpisodioById(int id);
        Task<ServiceResponse<List<AnimeEpisodio>>> GetEpisodioByIdAnime(int id);
        Task<ServiceResponse<List<AnimeEpisodio>>> CreateEpisodio(AnimeEpisodio episodioNovo);
        Task<ServiceResponse<List<AnimeEpisodio>>> UpdateEpisodio(AnimeEpisodio episodioEditado);
        Task<ServiceResponse<List<AnimeEpisodio>>> DeleteEpisodio(int id);

    }
}
