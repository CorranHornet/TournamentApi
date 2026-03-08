using Microsoft.AspNetCore.Mvc;
using TournamentApi.Services;
using TournamentApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TournamentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentsController : ControllerBase
    {
        private readonly ITournamentService _service;
        public TournamentsController(ITournamentService service)
        {
            _service = service;
        }

       
     // In-memory storage för demo / Swagger-test
        private static List<Tournament> _tournaments = new();
        private static int _nextId = 1;

        [HttpGet]
        public async Task<IActionResult> GetALl(string? search)
        {
            var tournaments = await _service.GetAllAsync(search);
            return Ok(tournaments);
        }

        [HttpPost]
        public IActionResult Create(Tournament tournament)
        {
            tournament.Id = _nextId++;
            _tournaments.Add(tournament);
            return Ok(tournament);
        }
    }
}