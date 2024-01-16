using Microsoft.AspNetCore.Mvc;
using Sport_.Application.DTOs.PlayerDTOs;
using Sport_System.Application.DTOs.PlayerDTOs;
using Sport_System.Application.Services.Interfaces;


namespace SportsManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer([FromForm] AddPlayerDTO dto)
        {
            var response = await _playerService.AddPlayer(dto);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> EditPlayer([FromForm] EditPlayerDTO dto)
        {
            var response = await _playerService.EditPlayer(dto);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var response = await _playerService.DeletePlayer(id);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{playerId}")]
        public async Task<IActionResult> GetPlayerById(int playerId)
        {
            var response = await _playerService.GetPlayerById(playerId);
            return Ok(response);
        }
        [HttpGet("PlayersByUser/{userId}")]
        public async Task<IActionResult> GetPlayersByUser(string userId)
        {
            var response = await _playerService.GetPlayersByUser(userId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var response = await _playerService.GetAllPlayers();
            return Ok(response);
        }

        [HttpGet("PlayersByTeam/{teamId}")]
        public async Task<IActionResult> GetAllPlayersByTeam(int teamId)
        {
            var response = await _playerService.GetAllPlayersByTeam(teamId);
            return Ok(response);
        }





    }
}
