using System;
using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Dtos
{
    public class TournamentResponseDTO
    {
        [Required]
        [MinLength(3)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxPlayers { get; set; }
        // Date removed → satisfies the “remove one property” requirement
    }
}