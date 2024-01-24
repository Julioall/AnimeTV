using AnimeTV.BackEnd.DataContext;
using AnimeTV.BackEnd.Models;
using AnimeTV.BackEnd.Models.Anime;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace AnimeTV.BackEnd.Service.AnimeService
{
    public class AnimeService : IAnimeInterface
    {
        private readonly AppDbContext _context;
        public AnimeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Anime>>> CreateAnime(Anime animeNovo)
        {
            ServiceResponse<List<Anime>> response = new ServiceResponse<List<Anime>>();
            try
            {
                if (animeNovo == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Informar dados!";
                    response.Sucesso = false;
                    return response;

                }
                _context.Add(animeNovo);
                await _context.SaveChangesAsync();
                response.Dados = _context.Animes.ToList();
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Anime>>> DeleteAnime(int id)
        {
            ServiceResponse<List<Anime>> response = new ServiceResponse<List<Anime>>();
            try
            {
                Anime anime = _context.Animes.FirstOrDefault(x => x.Id == id);
                if (anime == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Anime não localizado!";
                    response.Sucesso = false;
                    return response;

                }
                _context.Remove(anime);
                await _context.SaveChangesAsync();
                response.Dados = _context.Animes.ToList();
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }

        public async Task<ServiceResponse<Anime>> GetAnimeById(int id)
        {
            ServiceResponse<Anime> response = new ServiceResponse<Anime>();
            try
            {
                Anime anime = _context.Animes.FirstOrDefault(x => x.Id == id);
                if (anime == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Anime não localizado!";
                    response.Sucesso = false;
                    return response;

                }
                response.Dados = anime;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Anime>>> GetAnimes()
        {
            ServiceResponse<List<Anime>> response = new ServiceResponse<List<Anime>>();
            try
            {
                response.Dados = _context.Animes.ToList();
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

        public async Task<ServiceResponse<List<Anime>>> UpdateAnime(Anime animeEditado)
        {
            ServiceResponse<List<Anime>> response = new ServiceResponse<List<Anime>>();
            try
            {
                Anime anime = _context.Animes.AsNoTracking().FirstOrDefault(x => x.Id == animeEditado.Id);
                if (anime == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Anime não localizado!";
                    response.Sucesso = false;
                    return response;

                }
                _context.Animes.Update(animeEditado);
                await _context.SaveChangesAsync();
                response.Dados = _context.Animes.ToList();
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
