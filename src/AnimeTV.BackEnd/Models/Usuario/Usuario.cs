using System.ComponentModel.DataAnnotations;

namespace AnimeTV.BackEnd.Models.Usuario
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; init; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }

    }
}
