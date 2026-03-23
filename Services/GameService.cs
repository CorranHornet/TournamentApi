using TournamentApi.Data;
using TournamentApi.Dtos;
using TournamentApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentApi.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;

        public GameService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GameResponseDTO>> GetAllAsync(int? tournamentId = null, string? search = null)
        {
            var query = _context.Games.AsQueryable();

            if (tournamentId.HasValue)
                query = query.Where(g => g.TournamentId == tournamentId.Value);

            if (!string.IsNullOrWhiteSpace(search))
            {
                string pattern = $"%{search.Trim()}%";
                query = query.Where(g => EF.Functions.Like(g.Title, pattern));
            }

            var result = await query
                .Select(g => new GameResponseDTO
                {
                    Id = g.Id,
                    Title = g.Title,
                    Time = g.Time,
                    TournamentId = g.TournamentId
                })
                .ToListAsync();

            return result;
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