using System;
using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Dtos
{
    public class TournamentUpdateDTO
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int MaxPlayers { get; set; }

        public DateTime Date { get; set; }
    }
}