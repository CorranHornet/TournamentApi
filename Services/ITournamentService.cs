using TournamentApi.Models;

namespace TournamentApi.Services
{
    public interface ITournamentService
    {
        Task<IEnumerable<Tournament>> GetAllAsync(string? search = null );
        Task<Tournament?> GetByIdAsync(int id);
        Task<Tournament> CreateAsync(Tournament tournament);
        Task<bool> UpdateAsync(int id, Tournament tournament);
        Task<bool> DeleteAsync(int id);
    }
}
