using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimeTV.Domain.Models.User
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string LastName { get; init; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string Bio { get; set; }

        public List<string> FavoriteAnime { get; set; } = new List<string>();

        public List<string> Watchlist { get; set; } = new List<string>();

        public List<string> Roles { get; set; } = new List<string>();

        public DateTime DateJoined { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }

        public Dictionary<string, string> Preferences { get; set; } = new Dictionary<string, string>();

        public int Followers { get; set; }

        public int Following { get; set; }

        public string Settings { get; set; }
    }
}
