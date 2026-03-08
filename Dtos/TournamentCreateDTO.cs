using System;
using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Dtos
{
    // DTO acts like a filter for the model, controlling what data is sent to or received from the API.
    // This way, sensitive or internal fields are not exposed to the client.
    public class TournamentCreateDTO
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int MaxPlayers { get; set; }

        public DateTime Date { get; set; }
    }
}