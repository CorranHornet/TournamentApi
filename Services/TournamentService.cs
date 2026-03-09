using Microsoft.EntityFrameworkCore;
using TournamentApi.Data;
using TournamentApi.Dtos;
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

        public async Task<IEnumerable<TournamentResponseDTO>> GetAllAsync(string? search = null)
        {
            var query = _context.Tournaments.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(t => t.Title.ToLower().Contains(search));

            return await query
                .Select(t => new TournamentResponseDTO
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    MaxPlayers = t.MaxPlayers,
                })
                .ToListAsync();
        }

        public async Task<TournamentResponseDTO?> GetByIdAsync(int id)
        {
            return await _context.Tournaments
                .Where(t => t.Id == id)
                .Select(t => new TournamentResponseDTO
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    MaxPlayers = t.MaxPlayers,
                    
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TournamentResponseDTO> CreateAsync(TournamentCreateDTO dto)
        {
            var tournament = new Tournament
            {
                Title = dto.Title,
                Description = dto.Description,
                MaxPlayers = dto.MaxPlayers,
                Date = dto.Date
            };

            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();

            return new TournamentResponseDTO
            {
                Id = tournament.Id,
                Title = tournament.Title,
                Description = tournament.Description,
                MaxPlayers = tournament.MaxPlayers,
            };
        }

        public async Task<bool> UpdateAsync(int id, TournamentUpdateDTO dto)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            
            if (tournament == null) 
                return false;

            tournament.Title = dto.Title;
            tournament.Description = dto.Description;
            tournament.MaxPlayers = dto.MaxPlayers;
            tournament.Date = dto.Date;

            await _context.SaveChangesAsync();
            return true;
        }

        public  async Task<bool> DeleteAsync(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null) 
                return false;

            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}