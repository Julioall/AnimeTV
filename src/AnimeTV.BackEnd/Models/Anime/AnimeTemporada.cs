using AnimeTV.BackEnd.Models.Anime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class AnimeTemporada
{
    [Key]
    public int Id { get; set; }
    public int AnimeId { get; set; }  
    public Anime Anime { get; set; } 
    public string Nome { get; set; }
    public int Numero { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string Descricao { get; set; }
}