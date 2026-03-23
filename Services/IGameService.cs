using TournamentApi.Dtos;

namespace TournamentApi.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameResponseDTO>> GetAllAsync(int? tournamentId = null);
        Task<GameResponseDTO?> GetByIdAsync(int id);
        Task<GameResponseDTO> CreateAsync(GameCreateDTO dto);
        Task<bool> UpdateAsync(int id, GameUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}