using TournamentApi.Data;
using TournamentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TournamentApi.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly AppDbContext _context;

        public TournamentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tournament>> GetAllAsync(string? search = null)
        {
            var query = _context.Tournaments.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(t => t.Title.Contains(search));
            
            return await query.ToListAsync();
        }

        public async Task<Tournament?> GetByIdAsync(int id)
        {
            return await _context.Tournaments.FindAsync();
        }

        public async Task<Tournament> CreateAsync(Tournament tournament)
        {
            await _context.Tournaments.AddAsync(tournament);
            await _context.SaveChangesAsync();
            return tournament;    
        }

        public async Task<bool> UpdateAsync(int id, Tournament tournament)
        {
            var existing = await _context.Tournaments.FindAsync(id);
            if (existing == null) return false;

            existing.Title = tournament.Title;
            existing.Description = tournament.Description;
            existing.MaxPlayers = tournament.MaxPlayers;
            existing.Date = tournament.Date;

            await _context.SaveChangesAsync();
            return true;

            
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}