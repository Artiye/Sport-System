using Microsoft.AspNetCore.Mvc;
using Sport_System.Application.DTOs.SportDTOs;
using Sport_System.Application.Services.Interfaces;

namespace Sport_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly ISportService _sportService;
        public SportController(ISportService sportService)
        {
            _sportService = sportService;
        }

        [HttpPost]
        public async Task<IActionResult> AddSport([FromForm] AddSportDTO dto)
        {
            var response = await _sportService.AddSport(dto);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> EditSport([FromForm] EditSportDTO dto)
        {
            var response = await _sportService.EditSport(dto);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSport(int id)
        {
            var response = await _sportService.DeleteSport(id);
            return response.Status == 200 ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{sportId}")]
        public async Task<IActionResult> GetSportById(int sportId)
        {
            var response = await _sportService.GetSportById(sportId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSports()
        {
            var response = await _sportService.GetAllSports();
            return Ok(response);
        }
    }
}
