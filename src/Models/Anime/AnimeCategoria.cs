using AnimeTV.Enums;
using System.ComponentModel.DataAnnotations;

namespace AnimeTV.Models.Anime
{
    public class AnimeCategoria
    {
        [Key]
        public int AnimeId { get; set; }

        [Key]
        public CategoriaEnum Categoria { get; set; }

        public Anime Anime { get; set; }
    }
}

