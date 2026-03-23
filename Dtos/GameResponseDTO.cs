using System;

namespace TournamentApi.Dtos
{
    public class GameResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public int TournamentId { get; set; }
    }
}