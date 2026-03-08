using TournamentApi.Data;
using TournamentApi.Models;

namespace TournamentApi.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly AppDbContext _context;

        public TournamentService(AppDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Tournament>> GetAllAsync(string? search = null)
        {
            throw new NotImplementedException();
        }

        public Task<Tournament?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tournament> CreateAsync(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}