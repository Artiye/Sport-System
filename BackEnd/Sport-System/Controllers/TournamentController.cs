using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sport_System.Application.DTOs.TournamentDTOs;
using Sport_System.Application.Services.Interfaces;

namespace Sport_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;
        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTournament([FromForm] AddTournamentDTO dto)
        {
            var response = await _tournamentService.AddTournament(dto);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> EditTournamnet(EditTournamentDTO dto)
        {
            var response = await _tournamentService.EditTournament(dto);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpPut("TournamentLogo")]
        public async Task<IActionResult> EditTournamentLogo([FromForm] EditTournamentLogoDTO dto)
        {
            var response = await _tournamentService.EditTournamentLogo(dto);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{tournamentId}")]
        public async Task<IActionResult> DeleteTournament(int tournamentId)
        {
            var response = await _tournamentService.DeleteTournament(tournamentId);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{tournamentId}")]
        public async Task<IActionResult> GetTournamentById(int tournamentId)
        {
            var response = await _tournamentService.GetTournamentById(tournamentId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTournaments()
        {
            var response = await _tournamentService.GetAllTournaments();
            return Ok(response);
        }

        [HttpGet("ByUserId/{userId}")]
        public async Task<IActionResult> GetTournamentsByUserId(string userId)
        {
            var response = await _tournamentService.GetTournamentsByUserId(userId);
            return Ok(response);
        }

        [HttpPut("AddTeam")]
        public async Task<IActionResult> AddTeamToTournament(int tournamentId, int teamId)
        {
            var response = await _tournamentService.AddTeamToTournament(tournamentId, teamId);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpPut("RemoveTeam")]
        public async Task<IActionResult> RemovePlayerFromTournament(int tournamentId, int teamId)
        {
            var response = await _tournamentService.RemoveTeamFromTournament(tournamentId, teamId);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpGet("SearchTournaments/{searchTerm}")]
        public async Task<IActionResult> SearchTournnament(string searchTerm)
        {
            var response = await _tournamentService.SearchTournaments(searchTerm);
            return Ok(response);
        }
    }
}