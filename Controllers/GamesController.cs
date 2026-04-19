using Microsoft.AspNetCore.Mvc;
using TournamentApi.Dtos;
using TournamentApi.Services;

namespace TournamentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _service;

        public GamesController(IGameService service)
        {
            _service = service;
        }

        // GET /api/games
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var games = await _service.GetAllAsync();
            return Ok(games);
        }

        // GET /api/games/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var game = await _service.GetByIdAsync(id);
            if (game == null)
                return NotFound();

            return Ok(game);
        }

        // POST /api/games
        [HttpPost]
        public async Task<ActionResult<GameResponseDTO>> Create(GameCreateDTO dto)
        {
            var result = await _service.CreateAsync(dto);
            if (result == null)
            {
                return BadRequest($"Creation failed: Tournament ID{dto.TournamentId} does not exist.");
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        

        // PUT /api/games/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GameUpdateDTO dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success)
                return NotFound();

            return NoContent();
        }

        // DELETE /api/games/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}