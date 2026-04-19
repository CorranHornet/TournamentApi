using Microsoft.EntityFrameworkCore;
using TournamentApi.Data;
using TournamentApi.Dtos;
using TournamentApi.Models;

namespace TournamentApi.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;

        public GameService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GameResponseDTO>> GetAllAsync(int? tournamentId = null)
        {
            var query = _context.Games.AsQueryable();

            if (tournamentId.HasValue)
                query = query.Where(g => g.TournamentId == tournamentId.Value);

            return await query
                .Select(g => new GameResponseDTO
                {
                    Id = g.Id,
                    Title = g.Title,
                    Time = g.Time,
                    TournamentId = g.TournamentId
                })
                .ToListAsync();
        }

        public async Task<GameResponseDTO?> GetByIdAsync(int id)
        {
            return await _context.Games
                .Where(g => g.Id == id)
                .Select(g => new GameResponseDTO
                {
                    Id = g.Id,
                    Title = g.Title,
                    Time = g.Time,
                    TournamentId = g.TournamentId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<GameResponseDTO> CreateAsync(GameCreateDTO dto)
        {
            //Validate that the Tournament exists before trying to link a Game to it
            var tournamentExist = await _context.Tournaments.AnyAsync(t => t.Id == dto.TournamentId);
            
            if (!tournamentExist)
            {
                return null;
            }
            
            var game = new Game
            {
                Title = dto.Title,
                Time = dto.Time,
                TournamentId = dto.TournamentId
            };

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return new GameResponseDTO
            {
                Id = game.Id,
                Title = game.Title,
                Time = game.Time,
                TournamentId = game.TournamentId
            };
        }

        public async Task<bool> UpdateAsync(int id, GameUpdateDTO dto)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null) return false;

            game.Title = dto.Title;
            game.Time = dto.Time;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null) return false;

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}