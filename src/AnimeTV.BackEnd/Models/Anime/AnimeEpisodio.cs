using System;
using System.ComponentModel.DataAnnotations;

namespace AnimeTV.BackEnd.Models.Anime
{
    public class AnimeEpisodio
    {
        [Key]
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }

        public int Numero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string LinkVideo { get; set; }
        public DateTime DataLancamento { get; set; }
        public TimeSpan Duracao { get; set; }
    }
}
