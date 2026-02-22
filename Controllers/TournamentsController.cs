using Microsoft.AspNetCore.Mvc;
using TournamentApi.Models;
using System.Collections.Generic;

namespace TournamentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentsController : ControllerBase
    {
        // In-memory storage för demo / Swagger-test
        private static List<Tournament> _tournaments = new();
        private static int _nextId = 1;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tournaments);
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