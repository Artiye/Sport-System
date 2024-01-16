using Microsoft.AspNetCore.Mvc;
using Sport_System.Application.DTOs.TeamDTOs;
using Sport_System.Application.Services.Interfaces;

namespace Sport_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam([FromForm] AddTeamDTO dto)
        {
            var response = await _teamService.AddTeam(dto);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> EditTeam(EditTeamDTO dto)
        {
            var response = await _teamService.EditTeam(dto);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpPut("TeamLogo")]
        public async Task<IActionResult> EditTeamLogo([FromForm] EditTeamLogoDTO dto)
        {
            var response = await _teamService.EditTeamLogo(dto);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{teamId}")]
        public async Task<IActionResult> DeleteTeam(int teamId)
        {
            var response = await _teamService.DeleteTeam(teamId);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{teamId}")]
        public async Task<IActionResult> GetTeamById(int teamId)
        {
            var response = await _teamService.GetTeamById(teamId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var response = await _teamService.GetAllTeams();
            return Ok(response);
        }

        [HttpGet("SearchTeams/{searchTerm}")]
        public async Task<IActionResult> SearchTeam(string searchTerm)
        {
            var response = await _teamService.SearchTeams(searchTerm);
            return Ok(response);
        }
    }
}
