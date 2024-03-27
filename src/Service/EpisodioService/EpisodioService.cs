using AnimeTV.DataContext;
using AnimeTV.Models;
using AnimeTV.Models.Anime;
using Microsoft.EntityFrameworkCore;

namespace AnimeTV.Service.EpisodioService
{
    public class EpisodioService : IEpisodioInterface
    {
        private readonly AppDbContext _context;
        public EpisodioService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<AnimeEpisodio>>> GetEpisodios()
        {
            ServiceResponse<List<AnimeEpisodio>> response = new ServiceResponse<List<AnimeEpisodio>>();
            try
            {
                response.Dados = _context.Episodios.ToList();
                if (response.Dados.Count == 0)
                {
                    response.Mensagem = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }
        public async Task<ServiceResponse<AnimeEpisodio>> GetEpisodioById(int id)
        {
            ServiceResponse<AnimeEpisodio> response = new ServiceResponse<AnimeEpisodio>();
            try
            {
                AnimeEpisodio episodio = _context.Episodios.FirstOrDefault(ep => ep.Id == id);
                if (episodio == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Episodio não localizado!";
                    response.Sucesso = false;
                    return response;
                }
                response.Dados = episodio;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;

        }
        public async Task<ServiceResponse<List<AnimeEpisodio>>> CreateEpisodio(AnimeEpisodio episodioNovo)
        {
            ServiceResponse<List<AnimeEpisodio>> response = new ServiceResponse<List<AnimeEpisodio>>();
            try
            {
                if (episodioNovo == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Informar dados!";
                    response.Sucesso = false;
                    return response;
                }
                if (!_context.Animes.Any(a => a.Id == episodioNovo.Id))
                {
                    response.Dados = null;
                    response.Mensagem = "É preciso ter um anime cadastrado para adicionar episódios!";
                    response.Sucesso = false;
                    return response;
                };
                _context.Episodios.Add(episodioNovo);
                await _context.SaveChangesAsync();
                response.Dados = _context.Episodios.ToList();
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;

        }

        public async Task<ServiceResponse<List<AnimeEpisodio>>> UpdateEpisodio(AnimeEpisodio episodioEditado)
        {
            ServiceResponse<List<AnimeEpisodio>> response = new ServiceResponse<List<AnimeEpisodio>>();
            try
            {
                AnimeEpisodio episodio = _context.Episodios.AsNoTracking().FirstOrDefault(x => x.Id == episodioEditado.Id);
                if (episodio == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Episodio não localizado!";
                    response.Sucesso = false;
                    return response;
                }
                if (!_context.Animes.Any(a => a.Id == episodioEditado.Id))
                {
                    response.Dados = null;
                    response.Mensagem = "O anime desse episódio precisa ter sido cadastrado!";
                    response.Sucesso = false;
                    return response;
                };
                _context.Episodios.Update(episodioEditado);
                await _context.SaveChangesAsync();
                response.Dados = _context.Episodios.ToList();

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }
        public async Task<ServiceResponse<List<AnimeEpisodio>>> DeleteEpisodio(int id)
        {
            ServiceResponse<List<AnimeEpisodio>> response = new ServiceResponse<List<AnimeEpisodio>>();
            try
            {
                AnimeEpisodio episodio = _context.Episodios.FirstOrDefault(ep => ep.Id == id);
                if (episodio == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Episodio não localizado!";
                    response.Sucesso = false;
                    return response;
                }
                _context.Remove(episodio);
                await _context.SaveChangesAsync();
                response.Dados = _context.Episodios.ToList();
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<AnimeEpisodio>>> GetEpisodioByIdAnime(int animeId)
        {
            ServiceResponse<List<AnimeEpisodio>> response = new ServiceResponse<List<AnimeEpisodio>>();
            try
            {
                response.Dados = _context.Episodios.Where(e => e.Id == animeId).ToList();
                if (response.Dados.Count == 0)
                {
                    response.Mensagem = "Nenhum dado encontrado!";
                    response.Dados = null;
                    response.Sucesso = false;
                    return response;
                }

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }
    }

}

