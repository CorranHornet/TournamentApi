using System;
using System.ComponentModel.DataAnnotations;

namespace TournamentApi.Dtos
{
    public class TournamentUpdateDTO
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters")]
        public string Title { get; set; }

        public string Description { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "MaxPlayers must be at least 1")]
        public int MaxPlayers { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [FutureDate(ErrorMessage = "Date cannot be in the past")]
        public DateTime Date { get; set; }
    }
}