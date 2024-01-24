using AnimeTV.BackEnd.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimeTV.BackEnd.Models.Anime
{
    public class Anime
    {
        [Key]
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Lancamento { get; set; }
        public string ClassificacaoEtaria { get; set; }
        public double Avaliacao { get; set; }
        public string EstudioAnimacao { get; set; }
        public string Status { get; set; }
        public List<AnimeEpisodio> Episodios { get; set; }
        public List<AnimeTemporada> Temporadas { get; set; }
        public List<AnimeCategoria> Categorias { get; set; }
    }
}
